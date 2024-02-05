using HttpClientTmpl.BLL.Contracts.Albums;
using HttpClientTmpl.BLL.Entities.Albums;

namespace HttpClientTmpl.BLL.Mappers;

public static class AlbumMappers
{
    public static Album ToAlbum(this AlbumJsonPlaceholderResponse album)
    {
        return new Album(album.Id, album.UserId, album.Title);
    }

    public static List<Album> ToAlbums(this IEnumerable<AlbumJsonPlaceholderResponse> albums) =>
        albums.Select(x => x.ToAlbum()).ToList();

    public static AlbumResponse ToAlbumResponse(this Album album)
    {
        return new AlbumResponse(album.Id, album.UserId, album.Title);
    }

    public static List<AlbumResponse> ToAlbumResponses(this IEnumerable<Album> albums) =>
        albums.Select(x => x.ToAlbumResponse()).ToList();
}