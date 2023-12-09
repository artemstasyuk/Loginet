using System.Net;
using Loginet.BLL.Entities.Common;

namespace Loginet.BLL.Entities.Users.Errors;

public class UserNotFoundException: Exception, IApplicationException
{
    public HttpStatusCode StatusCode => HttpStatusCode.NotFound;
    public string ErrorMessage => "User not found";
    public string ProblemDetails => "User not found in db";
}