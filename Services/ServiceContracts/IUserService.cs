namespace _.ServiceContracts;


using _.Models;

public interface IUserService
{
    IEnumerable<ApplicationUser> GetUsersList();
}
