namespace _.Models;

using Microsoft.AspNetCore.Identity;

public class ApplicationUser : IdentityUser
{
    // Ajoutez des champs personnalisés ici, par exemple :
    public string? Nom { get; set; }
}
