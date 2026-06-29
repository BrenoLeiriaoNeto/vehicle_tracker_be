namespace VehicleTracker.Application.Exceptions;

public class CustomValidationException(IDictionary<string, string[]> errors)
    : Exception("Um ou mais erros de validação ocorreram.")
{
    public IDictionary<string, string[]> Errors { get; } = errors;
}