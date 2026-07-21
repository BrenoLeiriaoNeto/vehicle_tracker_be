namespace VehicleTracker.Exceptions.Profile;

public class ProfileNotFoundException(string message)
    : VehicleTrackerException("Erro de negócio", message, 400)
{
    
}