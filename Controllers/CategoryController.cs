namespace _.Controllers;

using Microsoft.AspNetCore.Mvc;
using _.DTOs;
using _.Models;
using _.ServiceContracts;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;

[ApiController]
[Route("api/[controller]")]
public class CategoriesController : ControllerBase
{
    private readonly ICategoryService _categoryservice;
    private readonly IMapper _mapper;

    public CategoriesController(ICategoryService service, IMapper mapper)
    {
        _categoryservice = service;
        _mapper = mapper;
    }

    [Authorize]
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var categories = await _categoryservice.GetAllCategorysAsync();
        var categoriesDto = _mapper.Map<IEnumerable<CategoryDTO>>(categories);
        return Ok(categoriesDto);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var category = await _categoryservice.GetCategoryByIdAsync(id);
        if (category == null) return NotFound();
        var categoryDto = _mapper.Map<CategoryDTO>(category);
        return Ok(categoryDto);
    }

    [Authorize(Roles = "Admin")]
    [HttpPost]
    public async Task<IActionResult> Create(CategoryDTO categoryDto)
    {
        var category = _mapper.Map<Category>(categoryDto);
        await _categoryservice.AddCategoryAsync(category);
        return CreatedAtAction(nameof(GetById), new { id = category.Id }, categoryDto);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, CategoryDTO categoryDto)
    {
        if (id != categoryDto.Id) return BadRequest();
        var category = _mapper.Map<Category>(categoryDto);
        await _categoryservice.UpdateCategoryAsync(category);
        return NoContent();
    }

    [Authorize(Roles = "Admin")]
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _categoryservice.DeleteCategoryAsync(id);
        return NoContent();
    }
}
