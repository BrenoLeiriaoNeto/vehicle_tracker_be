namespace VehicleTracker.Domain.Embedded;

public class ProfileMetrics
{
    public int TripsCompleted { get; set; } = 0;
    public DateTime? LastTripDate { get; set; }
    public double SumKilometers { get; set; } = 0.0;
    public int TotalVehicles { get; set; } = 0;

    public ProfileMetrics()
    {
        
    }
    
    public ProfileMetrics(int tripsCompleted, double sumKilometers, int totalVehicles)
    {
        TripsCompleted = tripsCompleted;
        SumKilometers = sumKilometers;
        TotalVehicles = totalVehicles;
    }
}