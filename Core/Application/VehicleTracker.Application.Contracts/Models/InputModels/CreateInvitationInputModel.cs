namespace VehicleTracker.Application.Contracts.Models.InputModels;

public class CreateInvitationInputModel
{
    public string DriverEmail { get; set; } = string.Empty;
    public string OwnerId { get; set; } = string.Empty;
}