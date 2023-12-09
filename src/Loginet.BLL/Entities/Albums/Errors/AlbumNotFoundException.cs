using System.Net;
using Loginet.BLL.Entities.Common;

namespace Loginet.BLL.Entities.Albums.Errors;

public class AlbumNotFoundException : Exception, IApplicationException
{
    public HttpStatusCode StatusCode => HttpStatusCode.NotFound;
    public string ErrorMessage => "Album not found";
    public string ProblemDetails => "Album not found in db";
}