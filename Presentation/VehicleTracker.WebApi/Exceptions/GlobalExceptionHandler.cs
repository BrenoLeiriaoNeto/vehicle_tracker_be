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

        var (statusCode, title, detail) = exception switch
        {
            CustomValidationException => (
                StatusCodes.Status400BadRequest,
                "Erro de Validação",
                "Preencha os campos corretamente."
            ),

            VehicleTrackerException baseEx => (
                baseEx.StatusCode,
                baseEx.Title,
                baseEx.Message
                ),

            _ => (
                StatusCodes.Status500InternalServerError,
                "Erro Interno no Servidor",
                "Ocorreu um erro inesperado. Por favor, tente novamente mais tarde")
        };

        if (statusCode == StatusCodes.Status500InternalServerError)
        {
            logger.LogError(exception, "🚨 Erro não tratado capturado: {Message}",
                exception.Message);
        }
        else
        {
            logger.LogWarning("⚠️ Aviso de negócio ({StatusCode}): {Message}", statusCode,
                exception.Message);
        }

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