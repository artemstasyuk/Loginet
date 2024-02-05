using HttpClientTmpl.BLL.Interfaces;
using HttpClientTmpl.BLL.Mappers;
using Microsoft.AspNetCore.Mvc;

namespace HttpClientTmpl.Api.Controllers;

[Route("api/v{apiVersion:apiVersion}/albums")]
[ApiController]
public class AlbumController : ControllerBase
{
    private readonly IAlbumService _albumService;

    public AlbumController(IAlbumService albumService)
    {
        _albumService = albumService;
    }

    /// <summary>
    /// Get all albums 
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    public async Task<IActionResult> GetAlbums()
    {
        var albums = await _albumService.GetAlbumsAsync();
        return Ok(albums.ToAlbumResponses());
    }

    /// <summary>
    /// Get album by id
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet("{id}")]
    public async Task<IActionResult> GetAlbumById(int id)
    {
        var album = await _albumService.GetAlbumById(id);
        return Ok(album.ToAlbumResponse());
    }

    /// <summary>
    /// Get user albums
    /// </summary>
    /// <param name="userId"></param>
    /// <returns></returns>
    [HttpGet("user/{userId}")]
    public async Task<IActionResult> GetUserAlbums(int userId)
    {
        var albums = await _albumService.GetUserAlbumsAsync(userId);
        return Ok(albums.ToAlbumResponses());
    }
}