namespace VehicleTracker.Exceptions.User;

public class EmailOrPasswordException(string message) 
    : VehicleTrackerException("Erro de negócio", message, 400){}