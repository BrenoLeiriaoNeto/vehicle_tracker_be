namespace VehicleTracker.Domain.Interfaces;

public interface IBusinessValues
{
    string CreatedBy { get; set; }
    string CreatedById { get; set; }
    DateTime CreatedAt { get; set; }
    
    string? UpdatedBy { get; set; }
    string? UpdatedById { get; set; }
    DateTime? UpdatedAt { get; set; }
    
    string? DeletedBy { get; set; }
    string? DeletedById { get; set; }
    DateTime? DeletedAt { get; set; }
}