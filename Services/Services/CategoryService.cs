namespace _.Services;

using _.Data;
using _.Models;
using _.Repositories;
using _.ServiceContracts;

public class CategoryService : ICategoryService
{
    private readonly IRepository<Category> _categoryRepository;

    public CategoryService(IRepository<Category> categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }

    public async Task<IEnumerable<Category>> GetAllCategorysAsync()
    {
        return await _categoryRepository.GetAllAsync();
    }

    public async Task<Category> GetCategoryByIdAsync(int id)
    {
        return await _categoryRepository.GetByIdAsync(id);
    }

    public async Task AddCategoryAsync(Category Category)
    {
        await _categoryRepository.AddAsync(Category);
    }

    public async Task UpdateCategoryAsync(Category Category)
    {
        await _categoryRepository.UpdateAsync(Category);
    }

    public async Task DeleteCategoryAsync(int id)
    {
        await _categoryRepository.DeleteAsync(id);
    }

    public async Task<bool> CategoryExistsAsync(int id)
    {
        return await _categoryRepository.GetByIdAsync(id) != null;
    }
}
