using HttpClientTmpl.BLL.Entities.Users;

namespace HttpClientTmpl.BLL.Interfaces;

public interface IUserService
{
    Task<List<User>> GetUsersAsync();
    Task<User> GetUserByIdAsync(int id);
}