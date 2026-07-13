namespace VehicleTracker.Exceptions;

public class InvitationExpiredException(string message) 
    : VehicleTrackerException("Erro de negócio", message, 410){}