namespace VehicleTracker.Domain.Models;

public class Invitation : BusinessValues
{
    public string Id { get; private set; } = null!;
    public string InviteCode { get; private set; } = null!;
    public string OwnerId { get; private set; } = null!;
    public string DriverEmail { get; private set; } = null!;
    public DateTime ExpiresAt { get; private set; }
    public bool IsUsed { get; private set; }

    public Invitation()
    {
        
    }

    public Invitation(string ownerId, string driverEmail)
    {
        OwnerId = ownerId;
        DriverEmail = driverEmail;
        ExpiresAt = DateTime.UtcNow.AddDays(1);
        IsUsed = false;
        InviteCode = $"INV-{Guid.NewGuid().ToString()[..5].ToUpper()}";
    }

    public bool CanBeAccepted(string email)
    {
        return !IsUsed && DateTime.UtcNow <= ExpiresAt && string.Equals(DriverEmail,
            email.ToLower().Trim(), StringComparison.OrdinalIgnoreCase);
    }

    public void MarkAsUsed()
    {
        IsUsed = true;
    }
}