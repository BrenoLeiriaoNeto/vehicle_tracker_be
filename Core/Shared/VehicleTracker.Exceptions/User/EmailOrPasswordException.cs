namespace VehicleTracker.Exceptions;

public class EmailOrPasswordException(string message) 
    : VehicleTrackerException("Erro de negócio", message, 400){}