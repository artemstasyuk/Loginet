using Loginet.BLL.Entities.Albums;

namespace Loginet.BLL.Interfaces;

public interface IAlbumService
{
    Task<List<Album>> GetAlbumsAsync();
    Task<List<Album>> GetUserAlbumsAsync(int userId);
    Task<Album> GetAlbumById(int id);
}