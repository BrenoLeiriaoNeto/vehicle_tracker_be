using System.Diagnostics.CodeAnalysis;
using VehicleTracker.Domain.Enums;

namespace VehicleTracker.Domain.Models;

public class User : BusinessValues
{
    // Auth related stuff
    public required string Id { get; set; }
    public required string Email { get; set; }
    public required string PasswordHash { get; set; }
    public required string Name { get; set; }
    public required UserRole Role { get; set; }

    public string? OwnerId { get; set; }

    // Profile related stuff
    public string? AvatarUrl { get; set; }
    public int TripsCompleted { get; set; } = 0;
    public double SumKilometers { get; set; } = 0.0;
    public int TotalVehicles { get; set; } = 0;
    public string? Bio { get; set; }

    public User() {}

    [SetsRequiredMembers]
    public User(string id, string email, string passwordHash, string name, UserRole role, string? ownerId)
    {
        Id = id;
        Email = email;
        PasswordHash = passwordHash;
        Name = name;
        Role = role;
        OwnerId = ownerId;
        
        SystemGenerated();
    }
}