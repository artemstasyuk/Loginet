using Loginet.BLL.Entities.Users;

namespace Loginet.BLL.Interfaces.Persistence;

public interface IUserRepository
{
    Task<List<User>> ListAsync();
    Task<User?> GetByIdAsync(int id);
    Task CreateAsync(User user);
    Task AddRangeAsync(IEnumerable<User> user);
    void UpdateAsync(User user);
    void DeleteAsync(User user);
    Task<bool> AnyAsync();
    Task<List<int>> GetUserIdsAsync(IEnumerable<int> userIdsToCheck);
}
