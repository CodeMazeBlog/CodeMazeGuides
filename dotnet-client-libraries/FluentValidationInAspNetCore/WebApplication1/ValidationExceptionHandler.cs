using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Diagnostics;

namespace WebApplication1;

public class ValidationExceptionHandler : IExceptionHandler
{
    public async ValueTask<bool> TryHandleAsync(
        HttpContext httpContext,
        Exception exception,
        CancellationToken cancellationToken)
    {
        if (exception is not ValidationException validationException)
            return false;

        var errors = new ValidationResult(validationException.Errors).ToDictionary();

        await Results.ValidationProblem(errors).ExecuteAsync(httpContext);

        return true;
    }
}
