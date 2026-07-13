namespace VehicleTracker.Exceptions.Vehicle;

public class VehicleNotFoundException(string message) 
    : VehicleTrackerException("Erro de negócio", message, 400)
{
    
}