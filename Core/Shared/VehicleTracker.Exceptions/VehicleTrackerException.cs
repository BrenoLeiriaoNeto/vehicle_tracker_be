namespace VehicleTracker.Exceptions;

public abstract class VehicleTrackerException(string title, string message, int statusCode) : Exception(message)
{
    public int StatusCode { get; } = statusCode;
    public string Title { get; } = title;
}