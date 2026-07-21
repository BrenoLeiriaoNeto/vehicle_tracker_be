using VehicleTracker.Domain.Embedded;
using VehicleTracker.Domain.Enums;

namespace VehicleTracker.Domain.Models;

public class User : BusinessValues
{
    public string Id { get; set; } = string.Empty;
    public string Name { get; private set; } = string.Empty;
    public string? AvatarUrl { get; set; }
    public string Bio { get; set; } = string.Empty;
    public string? OwnerId { get; set; }
    
    // Auth related stuff
    public UserAuth Auth { get; private set; } = null!;

    // Profile related stuff
    public ProfileMetrics Metrics { get; set; } = new();

    public User() {}

    public User(int tripsCompleted, double sumKilometers, int totalVehicles) =>
        Metrics = new ProfileMetrics(tripsCompleted, sumKilometers, totalVehicles);

    public User(string name, string bio)
    {
        Name = name;
        Bio = bio;
    }
    
    
    public User(
        string email,
        string passwordHash,
        string name,
        UserRole? role = null,
        bool? mustChangePassword = null)
    {
        Name = name;
        Auth = new UserAuth(
            email,
            passwordHash,
            role ?? UserRole.Driver,
            mustChangePassword ?? false);
        
        SystemGenerated();
    }
    
    public void SetOwner(string ownerId) => OwnerId = ownerId;
    
}