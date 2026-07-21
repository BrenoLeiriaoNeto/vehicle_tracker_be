namespace VehicleTracker.Exceptions.User;

public class InvitationExpiredException(string message) 
    : VehicleTrackerException("Erro de negócio", message, 410){}