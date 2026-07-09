namespace VehicleTracker.Application.Contracts.Models.InputModels;

public record CreateUserInputModel(
    string Name,
    string Email,
    string Password,
    string? OwnerId = null
    );