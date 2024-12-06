namespace _.Controllers;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[ApiController]
[Route("api/[controller]")]
public class RoleManagementController : ControllerBase
{
    private readonly RoleManager<IdentityRole> _roleManager;

    public RoleManagementController(RoleManager<IdentityRole> roleManager)
    {
        _roleManager = roleManager;
    }

    // Endpoint pour obtenir tous les rôles
    [HttpGet]
    [Authorize(Roles = "Admin")] // Seul l'Admin peut lister les rôles
    public async Task<IActionResult> GetAllRoles()
    {
        var roles = await _roleManager.Roles.ToListAsync();
        return Ok(roles);
    }

    [HttpPost]
    [Authorize(Roles = "Admin")]  // Seuls les admins peuvent ajouter des rôles
    public async Task<IActionResult> CreateRole([FromBody] string roleName)
    {
        if (string.IsNullOrWhiteSpace(roleName))
        {
            return BadRequest("Le nom du rôle ne peut pas être vide.");
        }

        var roleExist = await _roleManager.RoleExistsAsync(roleName);
        if (roleExist)
        {
            return Conflict("Le rôle existe déjà.");
        }

        var result = await _roleManager.CreateAsync(new IdentityRole(roleName));
        if (result.Succeeded)
        {
            return Ok($"Le rôle {roleName} a été créé avec succès.");
        }

        return StatusCode(500, "Une erreur s'est produite lors de la création du rôle.");
    }
}
