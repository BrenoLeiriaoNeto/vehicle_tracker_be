using VehicleTracker.Domain.Enums;

namespace VehicleTracker.Application.Contracts.Models.InputModels;

public record CreateUserInputModel(
    string Name,
    string Email,
    string Password,
    UserRole Role,
    string? OwnerId = null
    );