namespace VehicleTracker.Exceptions;

public class UserNotFoundException(string message)
    : VehicleTrackerException("Erro de negócio", message, 404)
{
    
}