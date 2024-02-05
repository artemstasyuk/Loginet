using System.Net;

namespace HttpClientTmpl.BLL.Entities.Common;

public interface IApplicationException
{
    public HttpStatusCode StatusCode { get; }
    public string ErrorMessage { get; }
    public string ProblemDetails { get; }
}