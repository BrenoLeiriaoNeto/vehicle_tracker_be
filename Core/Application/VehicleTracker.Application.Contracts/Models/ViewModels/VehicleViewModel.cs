using VehicleTracker.Domain.Enums;

namespace VehicleTracker.Application.Contracts.Models.ViewModels;

public record VehicleViewModel (
    string Plate,
    string Brand,
    string Model,
    string Year,
    double CurrentKm,
    VehicleStatus Status
    );