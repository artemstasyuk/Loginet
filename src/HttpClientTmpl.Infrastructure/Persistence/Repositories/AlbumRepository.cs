using HttpClientTmpl.BLL.Entities.Albums;
using HttpClientTmpl.BLL.Interfaces.Persistence;
using Microsoft.EntityFrameworkCore;

namespace HttpClientTmpl.Infrastructure.Persistence.Repositories;

public class AlbumRepository : IAlbumRepository
{
    private readonly AppDbContext _context;

    public AlbumRepository(AppDbContext context)
    {
        _context = context;
    }

    public Task<List<Album>> ListAsync() =>
        _context.Albums.ToListAsync();

    public Task<Album?> GetByIdAsync(int id) =>
        _context.Albums.FirstOrDefaultAsync(c => c.Id == id);

    public async Task CreateAsync(Album album)
    {
        await _context.AddAsync(album);
        await _context.SaveChangesAsync();
    }

    public async Task<List<Album>> GetUserAlbumsAsync(int userId) => 
        await _context.Albums.Where(x => x.UserId == userId).ToListAsync();

    public async Task AddRangeAsync(IEnumerable<Album> albums)
    {
        await _context.AddRangeAsync(albums);
        await _context.SaveChangesAsync();
    }

    public void UpdateAsync(Album album)
    {
        _context.Update(album);
        _context.SaveChanges();
    }

    public void DeleteAsync(Album album)
    {
        _context.Remove(album);
        _context.SaveChanges();
    }

    public async Task<bool> AnyAsync() =>
        await _context.Albums.AnyAsync();
}