using VehicleTracker.Domain.Interfaces;

namespace VehicleTracker.Domain;

public abstract class BusinessValues : IBusinessValues
{
    public string CreatedBy { get; set; } = string.Empty;
    public string CreatedById { get; set; } = string.Empty;
    public required DateTime CreatedAt { get; set; }
    
    public string? UpdatedBy { get; set; }
    public string? UpdatedById { get; set; }
    public DateTime? UpdatedAt { get; set; }
    
    public string? DeletedBy { get; set; }
    public string? DeletedById { get; set; }
    public DateTime? DeletedAt { get; set; }

    public void SystemGenerated()
    {
        CreatedBy = "System";
        CreatedById = "System";
        CreatedAt = DateTime.UtcNow;
    }

    public void MarkCreated(string createdBy, string createdById, DateTime createdAt)
    {
        CreatedBy = createdBy;
        CreatedById = createdById;
        CreatedAt = createdAt;
    }

    public void MarkUpdated(string updatedBy, string updatedById, DateTime updatedAt)
    {
        UpdatedBy = updatedBy;
        UpdatedById = updatedById;
        UpdatedAt = updatedAt;
    }
    
    public void MarkDeleted(string deletedBy, string deletedById, DateTime deletedAt)
    {
        DeletedBy = deletedBy;
        DeletedById = deletedById;
        DeletedAt = deletedAt;
    }
}