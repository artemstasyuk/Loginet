using Loginet.BLL.Contracts.Albums;
using Loginet.BLL.Contracts.Users;

namespace Loginet.BLL.Interfaces.Clients;

public interface IJsonPlaceholderClient
{
    Task<List<UserJsonPlaceholderResponse>?> GetUsersAsync();
    Task<UserJsonPlaceholderResponse?> GetUserByIdAsync(int id);
    Task<AlbumJsonPlaceholderResponse?> GetAlbumByIdAsync(int id);
    Task<List<AlbumJsonPlaceholderResponse>?> GetAlbumsAsync();
    Task<List<AlbumJsonPlaceholderResponse>?> GetUserAlbumsAsync(int userId);
}