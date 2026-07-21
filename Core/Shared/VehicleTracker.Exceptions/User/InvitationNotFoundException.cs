namespace VehicleTracker.Exceptions.User;

public class InvitationNotFoundException(string message) 
    : VehicleTrackerException("Erro de negócio", message, 404){}