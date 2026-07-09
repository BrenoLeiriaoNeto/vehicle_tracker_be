using VehicleTracker.Domain.Interfaces;

namespace VehicleTracker.Domain;

public abstract class BusinessValues : IBusinessValues
{
    public string CreatedBy { get; set; } = string.Empty;
    public string CreatedById { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    
    public string? UpdatedBy { get; set; }
    public string? UpdatedById { get; set; }
    public DateTime? UpdatedAt { get; set; }
    
    public string? DeletedBy { get; set; }
    public string? DeletedById { get; set; }
    public DateTime? DeletedAt { get; set; }

    protected void SystemGenerated()
    {
        CreatedBy = "System";
        CreatedById = "System";
        CreatedAt = DateTime.UtcNow;
    }

    public void MarkCreated(string createdBy, string createdById)
    {
        CreatedBy = createdBy;
        CreatedById = createdById;
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