using System.Diagnostics.CodeAnalysis;
using VehicleTracker.Domain.Enums;

namespace VehicleTracker.Domain.Models;

public class User : BusinessValues
{
    // Auth related stuff
    public string Id { get; set; } = string.Empty;
    public string Email { get; private set; }
    public string PasswordHash { get; private set; }
    public string Name { get; private set; }
    public UserRole Role { get; private set; }
    public UserStatus Status { get; set; } = UserStatus.Active;

    public string? OwnerId { get; set; }

    // Profile related stuff
    public string? AvatarUrl { get; set; }
    public int TripsCompleted { get; set; } = 0;
    public double SumKilometers { get; set; } = 0.0;
    public int TotalVehicles { get; set; } = 0;
    public string? Bio { get; set; }

    public User() {}
    
    public User(string email, string passwordHash, string name, UserRole? role = null)
    {
        Email = email;
        PasswordHash = passwordHash;
        Name = name;
        Role = role ?? UserRole.Driver;
        
        SystemGenerated();
    }
    
    public void SetOwner(string ownerId)
    {
        OwnerId = ownerId;
    }
}