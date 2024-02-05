using HttpClientTmpl.BLL.Entities.Albums;

namespace HttpClientTmpl.BLL.Interfaces;

public interface IAlbumService
{
    Task<List<Album>> GetAlbumsAsync();
    Task<List<Album>> GetUserAlbumsAsync(int userId);
    Task<Album> GetAlbumById(int id);
}