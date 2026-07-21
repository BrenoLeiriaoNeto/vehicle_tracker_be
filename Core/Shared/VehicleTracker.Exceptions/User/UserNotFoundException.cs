namespace VehicleTracker.Exceptions.User;

public class UserNotFoundException(string message)
    : VehicleTrackerException("Erro de negócio", message, 404)
{
    
}