using Loginet.BLL.Entities.Users;
using Loginet.BLL.Interfaces.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Loginet.Infrastructure.Persistence.Repositories;

public class UserRepository : IUserRepository
{
    private readonly AppDbContext _context;
    
    public UserRepository(AppDbContext context)
    {
        _context = context;
    }
    
    public async Task<List<User>> ListAsync() =>
        await _context.Users.ToListAsync();

    public async Task<User?> GetByIdAsync(int id) =>
        await _context.Users.FirstOrDefaultAsync(c => c.Id == id);

    public async Task CreateAsync(User user)
    {
        await _context.AddAsync(user);
        await _context.SaveChangesAsync();
    }

    public async Task AddRangeAsync(IEnumerable<User> user)
    {
        await _context.AddRangeAsync(user);
        await _context.SaveChangesAsync();
    }

    public void UpdateAsync(User user)
    {
        _context.Update(user);
        _context.SaveChanges();
    }

    public void DeleteAsync(User user)
    {
        _context.Remove(user);
        _context.SaveChanges();
    }
    
    public async Task<bool> AnyAsync() =>
        await _context.Users.AnyAsync();

    public async Task<List<int>> GetUserIdsAsync(IEnumerable<int> userIdsToCheck) =>
        await _context.Users
            .Where(user => userIdsToCheck.Contains(user.Id))
            .Select(user => user.Id)
            .ToListAsync();

}