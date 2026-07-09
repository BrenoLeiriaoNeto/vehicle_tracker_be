using VehicleTracker.Domain.Enums;

namespace VehicleTracker.Application.Contracts.Models.InputModels;

public record CreateVehicleInputModel(
    string Plate,
    string Brand,
    string Model,
    string Year,
    double CurrentKm,
    VehicleStatus Status,
    string OwnerId
    );