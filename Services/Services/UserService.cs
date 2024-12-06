namespace _.Services;


using Microsoft.AspNetCore.Identity;
using _.Models;
using _.ServiceContracts;

public class UserService : IUserService
{
    private readonly UserManager<ApplicationUser> _userManager;

    public UserService(UserManager<ApplicationUser> userManager)
    {
        _userManager = userManager;
    }

    public IEnumerable<ApplicationUser> GetUsersList()
    {
        return _userManager.Users;  // Retourne tous les utilisateurs
    }
}
