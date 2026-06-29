using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using VehicleTracker.Application.Exceptions;
using VehicleTracker.Exceptions;

namespace VehicleTracker.WebApi.Exceptions;

public class GlobalExceptionHandler(
    ILogger<GlobalExceptionHandler> logger) : IExceptionHandler
{
    public async ValueTask<bool> TryHandleAsync(
        HttpContext httpContext,
        Exception exception,
        CancellationToken cancellationToken)
    {
        
        logger.LogError(exception, "Execução capturada: {Message}", exception.Message);

        var (statusCode, title, detail) = exception switch
        {
            CustomValidationException valEx => (
                StatusCodes.Status400BadRequest,
                "Erro de Validação",
                "Preencha os campos corretamente."
            ),

            ConflictException => (
                StatusCodes.Status409Conflict,
                "Conflito de dados",
                exception.Message),

            _ => (
                StatusCodes.Status500InternalServerError,
                "Erro Interno no Servidor",
                "Ocorreu um erro inesperado.")
        };

        var problemDetails = new ProblemDetails
        {
            Status = statusCode,
            Title = title,
            Detail = detail,
            Instance = httpContext.Request.Path
        };

        if (exception is CustomValidationException validationException)
        {
            problemDetails.Extensions.Add("errors", validationException.Errors);
        }

        httpContext.Response.StatusCode = statusCode;
        await httpContext.Response.WriteAsJsonAsync(problemDetails, cancellationToken);

        return true;
    }
}