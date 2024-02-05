using HttpClientTmpl.BLL.Mappers;
using HttpClientTmpl.BLL.Entities.Albums;
using HttpClientTmpl.BLL.Entities.Common.Errors;
using HttpClientTmpl.BLL.Entities.Users.Errors;
using HttpClientTmpl.BLL.Interfaces;
using HttpClientTmpl.BLL.Interfaces.Clients;
using HttpClientTmpl.BLL.Interfaces.Persistence;

namespace HttpClientTmpl.BLL.Services;

public class AlbumService : IAlbumService
{
    private readonly IJsonPlaceholderClient _jsonPlaceholderClient;
    private readonly IAlbumRepository _albumRepository;
    private readonly IUserRepository _userRepository;
    
    public AlbumService(IJsonPlaceholderClient jsonPlaceholderClient, IAlbumRepository albumRepository, IUserRepository userRepository)
    {
        _jsonPlaceholderClient = jsonPlaceholderClient;
        _albumRepository = albumRepository;
        _userRepository = userRepository;
    }
    
    
    public async Task<List<Album>> GetAlbumsAsync()
    {
        if (!await _albumRepository.AnyAsync())
            return await _albumRepository.ListAsync();
        
        
        if (await _jsonPlaceholderClient.GetAlbumsAsync() is not {} clientAlbums)
            throw new IncorrectDataException();
        
        var existingUserIds = await _userRepository.GetUserIdsAsync(clientAlbums.Select(
            album => album.UserId)
            .Distinct().ToList());

        if (clientAlbums.Any(album => !existingUserIds.Contains(album.UserId)))
            throw new UserNotFoundException();

        await _albumRepository.AddRangeAsync(clientAlbums.ToAlbums());
        return clientAlbums.ToAlbums();
    }
    
    public async Task<Album> GetAlbumById(int id)
    {
        if (await _albumRepository.GetByIdAsync(id) is { } album)
            return album;
       
        if (await _jsonPlaceholderClient.GetAlbumByIdAsync(id) is not {} clientAlbum)
            throw new IncorrectDataException();

        if (await _userRepository.GetByIdAsync(clientAlbum.Id) is null)
            throw new UserNotFoundException();
        
        var newAlbum = clientAlbum.ToAlbum();
        await _albumRepository.CreateAsync(newAlbum);

        return newAlbum;
    }
    
    public async Task<List<Album>> GetUserAlbumsAsync(int userId)
    {
        if (await _userRepository.GetByIdAsync(userId) is not { } user)
            throw new UserNotFoundException();
        
        if (await _albumRepository.GetUserAlbumsAsync(user.Id) is { } albums)
            return albums;
        
        if (await _jsonPlaceholderClient.GetUserAlbumsAsync(user.Id) is not {} clientAlbum)
            throw new IncorrectDataException();

        var entityAlbums = clientAlbum.ToAlbums();
        await _albumRepository.AddRangeAsync(entityAlbums);

        return entityAlbums;
    }
}