using Loginet.BLL.Entities.Users;

namespace Loginet.BLL.Interfaces;

public interface IUserService
{
    Task<List<User>> GetUsersAsync();
    Task<User> GetUserByIdAsync(int id);
}