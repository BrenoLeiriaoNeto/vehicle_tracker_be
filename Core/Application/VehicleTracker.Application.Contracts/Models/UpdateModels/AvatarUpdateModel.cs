namespace VehicleTracker.Application.Contracts.Models.UpdateModels;

public record AvatarUpdateModel(
    string UserId,
    Stream FileStream,
    string FileName,
    string ContentType
    );