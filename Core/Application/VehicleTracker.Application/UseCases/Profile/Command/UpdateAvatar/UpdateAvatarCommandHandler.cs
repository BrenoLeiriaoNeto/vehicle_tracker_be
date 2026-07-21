using MediatR;
using VehicleTracker.Application.Contracts.Interfaces.Command;
using VehicleTracker.Application.Contracts.Interfaces.Services;

namespace VehicleTracker.Application.UseCases.Profile.Command.UpdateAvatar;

public class UpdateAvatarCommandHandler(
    IProfileCommandRepository commandRepository,
    IStorageService storageService
    ) : IRequestHandler<UpdateAvatarCommand, string>
{
    public async Task<string> Handle(UpdateAvatarCommand request, CancellationToken cancellationToken)
    {
        var extension = Path.GetExtension(request.Update.FileName);
        var internalFileName =
            $"avatars/{request.Update.UserId}/profile_{DateTime.UtcNow.Ticks}{extension}";

        var avatarUrl = await storageService.UploadFileAsync(
            request.Update.FileStream,
            internalFileName,
            request.Update.ContentType,
            cancellationToken
        );

        await commandRepository.UpdateProfilePictureAsync(request.Update.UserId, avatarUrl,
            cancellationToken);

        return avatarUrl;
    }
}