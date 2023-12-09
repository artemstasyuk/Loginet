using Loginet.BLL.Entities.Albums;

namespace Loginet.BLL.Interfaces.Persistence;

public interface IAlbumRepository
{
    Task<List<Album>> ListAsync();
    Task<Album?> GetByIdAsync(int id);
    Task<List<Album>> GetUserAlbumsAsync(int userId);
    Task CreateAsync(Album album);
    Task AddRangeAsync(IEnumerable<Album> albums);
    void UpdateAsync(Album album);
    void DeleteAsync(Album album);
    Task<bool> AnyAsync();
}