using System.Net;

namespace HttpClientTmpl.BLL.Entities.Common.Errors;

public class IncorrectDataException : Exception, IApplicationException
{
    public HttpStatusCode StatusCode => HttpStatusCode.Conflict;
    public string ErrorMessage => "Incorrect data";
    public string ProblemDetails => "Incorrect data exception";
}