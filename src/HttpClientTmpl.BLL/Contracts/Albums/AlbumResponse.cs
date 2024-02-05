namespace HttpClientTmpl.BLL.Contracts.Albums;

public record AlbumResponse(
    int Id,
    int UserId,
    string Title
);