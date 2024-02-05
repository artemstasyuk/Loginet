using HttpClientTmpl.BLL.Entities.Albums;

namespace HttpClientTmpl.BLL.Interfaces.Persistence;

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