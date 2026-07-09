namespace VehicleTracker.Application.Contracts.Models.InputModels;

public record CreateDriverByInviteInputModel(string Name,
    string Email,
    string Password,
    string InviteCode);