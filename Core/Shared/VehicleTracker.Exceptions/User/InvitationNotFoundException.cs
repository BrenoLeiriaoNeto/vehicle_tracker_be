namespace VehicleTracker.Exceptions;

public class InvitationNotFoundException(string message) 
    : VehicleTrackerException("Erro de negócio", message, 404){}