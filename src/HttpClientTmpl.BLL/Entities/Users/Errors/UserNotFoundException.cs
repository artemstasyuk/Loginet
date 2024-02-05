using System.Net;
using HttpClientTmpl.BLL.Entities.Common;

namespace HttpClientTmpl.BLL.Entities.Users.Errors;

public class UserNotFoundException: Exception, IApplicationException
{
    public HttpStatusCode StatusCode => HttpStatusCode.NotFound;
    public string ErrorMessage => "User not found";
    public string ProblemDetails => "User not found in db";
}