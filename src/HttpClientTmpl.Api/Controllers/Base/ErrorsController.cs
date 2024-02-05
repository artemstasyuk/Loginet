using HttpClientTmpl.BLL.Entities.Common;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace HttpClientTmpl.Api.Controllers.Base;

[ApiExplorerSettings(IgnoreApi = true)]
public class ErrorsController : ControllerBase
{
    [Route("/error")]
    public IActionResult Error()
    {
        var exception = HttpContext.Features.Get<IExceptionHandlerFeature>()?.Error;

        /*//catch the validation error
        if (exception?.GetType() == typeof(ValidationException))
        {
            var validationException = (ValidationException)exception;
            return ValidationProblem(validationException.Errors);
        }*/

        var (statusCode, message, details) = exception switch
        {
            IApplicationException appException => ((int)appException.StatusCode, appException.ErrorMessage,
                appException.ProblemDetails),
            _ => (StatusCodes.Status500InternalServerError, "An unexpected error occurred", "")
        };

        Log.Error("Status Code {StatusCode}: {Message} ({Details})", statusCode, message, details);
        return Problem(statusCode: statusCode, title: message, detail: details);
    }

    /*private IActionResult ValidationProblem(IEnumerable<ValidationFailure> errors)
    {
        var modelStateDictionary = new ModelStateDictionary();

        //all validation errors
        foreach (var failure in errors)
            modelStateDictionary.AddModelError(failure.PropertyName, failure.ErrorMessage);
        
        return ValidationProblem(modelStateDictionary);
    }*/
}