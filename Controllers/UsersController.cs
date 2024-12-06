namespace _.Controllers;

using Microsoft.AspNetCore.Mvc;
using _.ServiceContracts;

[ApiController]
[Route("api/[controller]")]
public class UsersController : ControllerBase
{
    private readonly IUserService _userService;

    public UsersController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpGet("user")]
    public IActionResult GetUsers()
    {
        var users = _userService.GetUsersList();
        return Ok(users);
    }
}
