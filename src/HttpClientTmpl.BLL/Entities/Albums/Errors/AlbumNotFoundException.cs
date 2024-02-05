using System.Net;
using HttpClientTmpl.BLL.Entities.Common;

namespace HttpClientTmpl.BLL.Entities.Albums.Errors;

public class AlbumNotFoundException : Exception, IApplicationException
{
    public HttpStatusCode StatusCode => HttpStatusCode.NotFound;
    public string ErrorMessage => "Album not found";
    public string ProblemDetails => "Album not found in db";
}