using VehicleTracker.Domain.Enums;

namespace VehicleTracker.Domain.Models;

public class Vehicle : BusinessValues
{
    public string Id { get; private set; } = string.Empty;
    public string Plate { get; private set; } = string.Empty;
    public string Brand { get; private set; } = string.Empty;
    public string Model { get;  private set; } = string.Empty;
    public string Year { get; private set; } = string.Empty;
    public double CurrentKm { get; private set; } = 0.0;
    public VehicleStatus Status { get; private set; } = VehicleStatus.Available;

    public string OwnerId { get; private set; } = string.Empty;
    public bool IsDeleted { get; private set; } = false;

    public Vehicle() {}
    
    public Vehicle(string plate, string brand, string model, string year, double currentKm,
        VehicleStatus status, string ownerId)
    {
        Plate = plate;
        Brand = brand;
        Model = model;
        Year = year;
        CurrentKm = currentKm;
        Status = status;
        OwnerId = ownerId;
    }
}