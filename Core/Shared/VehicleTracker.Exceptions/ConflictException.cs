namespace VehicleTracker.Exceptions;

public class ConflictException(string message) 
    : VehicleTrackerException("Erro de negócio", message, 409)
{}