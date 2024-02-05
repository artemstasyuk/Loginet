using HttpClientTmpl.BLL.Contracts.Albums;
using HttpClientTmpl.BLL.Contracts.Users;
using HttpClientTmpl.BLL.Interfaces.Clients;
using Newtonsoft.Json;
using Serilog;

namespace HttpClientTmpl.Infrastructure.Clients.JsonPlaceholder;

public class JsonPlaceholderClient : HttpClient, IJsonPlaceholderClient
{
    private readonly HttpClient _client;

    public JsonPlaceholderClient(HttpClient client)
    {
        _client = client ?? throw new ArgumentNullException(nameof(client));
    }

    public async Task<List<UserJsonPlaceholderResponse>?> GetUsersAsync()
    {
        var response = await SendRequestAsync($"{_client.BaseAddress}/users");
        return JsonConvert.DeserializeObject<List<UserJsonPlaceholderResponse>>(response);
    }
    
    public async Task<UserJsonPlaceholderResponse?> GetUserByIdAsync(int id)
    {
        var response = await SendRequestAsync($"{_client.BaseAddress}/users/{id}");
        return JsonConvert.DeserializeObject<UserJsonPlaceholderResponse>(response);
    }
    
    public async Task<List<AlbumJsonPlaceholderResponse>?> GetAlbumsAsync()
    {
        var response =  await SendRequestAsync($"{_client.BaseAddress}/albums");
        return JsonConvert.DeserializeObject<List<AlbumJsonPlaceholderResponse>>(response);
    }

    public async Task<List<AlbumJsonPlaceholderResponse>?> GetUserAlbumsAsync(int userId)
    {
        var response =  await SendRequestAsync($"{_client.BaseAddress}/albums?userId={userId}");
        return JsonConvert.DeserializeObject<List<AlbumJsonPlaceholderResponse>>(response);
    }
    
    public async Task<AlbumJsonPlaceholderResponse?> GetAlbumByIdAsync(int id)
    {
        var response = await SendRequestAsync($"{_client.BaseAddress}/albums/{id}");
        return JsonConvert.DeserializeObject<AlbumJsonPlaceholderResponse>(response);
    }
    
    private async Task<string> SendRequestAsync(string apiUrl)
    {
        var response = await _client.GetAsync(apiUrl);
        Log.Information($"Send request {apiUrl}");
        
        if (response.IsSuccessStatusCode)
            return await response.Content.ReadAsStringAsync();

        throw new HttpRequestException($"Error: {response.ReasonPhrase}");
    }
}