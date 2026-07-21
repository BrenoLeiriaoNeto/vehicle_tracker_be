using Amazon.S3;
using Amazon.S3.Model;
using Microsoft.Extensions.Options;
using VehicleTracker.Application.Contracts.Interfaces.Services;
using VehicleTracker.Infrastructure.Services.Settings;

namespace VehicleTracker.Infrastructure.Services;

public class CloudflareR2StorageService(
    IAmazonS3 s3Client,
    IOptions<CloudflareR2Settings> options) : IStorageService
{
    private readonly CloudflareR2Settings _settings = options.Value;

    public async Task<string> UploadFileAsync(Stream stream, string fileName, string contentType,
        CancellationToken ct)
    {
        var uploadRequest = new PutObjectRequest
        {
            InputStream = stream,
            BucketName = _settings.BucketName,
            Key = fileName,
            ContentType = contentType
        };

        await s3Client.PutObjectAsync(uploadRequest, ct);

        var baseUrl = _settings.PublicUrlDomain.TrimEnd('/');

        return $"{baseUrl}/{fileName}";
    }
}