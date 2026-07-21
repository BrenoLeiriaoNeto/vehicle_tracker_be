namespace VehicleTracker.Application.Contracts.Interfaces.Services;

public interface IStorageService
{
    Task<string> UploadFileAsync(Stream stream, string fileName, string contentType,
        CancellationToken ct);
}