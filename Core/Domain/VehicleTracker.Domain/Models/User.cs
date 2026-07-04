using System.Diagnostics.CodeAnalysis;
using VehicleTracker.Domain.Embedded;
using VehicleTracker.Domain.Enums;

namespace VehicleTracker.Domain.Models;

public class User : BusinessValues
{
    public string Id { get; set; } = string.Empty;
    public string Name { get; private set; } = string.Empty;
    public string? OwnerId { get; set; }
    
    // Auth related stuff
    public UserAuth Auth { get; private set; } = null!;

    // Profile related stuff
    public string? AvatarUrl { get; set; }
    public int TripsCompleted { get; set; } = 0;
    public double SumKilometers { get; set; } = 0.0;
    public int TotalVehicles { get; set; } = 0;
    public string? Bio { get; set; }

    public User() {}
    
    public User(string email, string passwordHash, string name, UserRole? role = null)
    {
        Name = name;
        Auth = new UserAuth(email, passwordHash, role ?? UserRole.Driver);
        
        SystemGenerated();
    }
    
    public void SetOwner(string ownerId) => OwnerId = ownerId;
    
}