using HttpClientTmpl.BLL.Contracts.Albums;
using HttpClientTmpl.BLL.Contracts.Users;

namespace HttpClientTmpl.BLL.Interfaces.Clients;

public interface IJsonPlaceholderClient
{
    Task<List<UserJsonPlaceholderResponse>?> GetUsersAsync();
    Task<UserJsonPlaceholderResponse?> GetUserByIdAsync(int id);
    Task<AlbumJsonPlaceholderResponse?> GetAlbumByIdAsync(int id);
    Task<List<AlbumJsonPlaceholderResponse>?> GetAlbumsAsync();
    Task<List<AlbumJsonPlaceholderResponse>?> GetUserAlbumsAsync(int userId);
}