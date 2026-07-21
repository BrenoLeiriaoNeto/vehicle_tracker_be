using Amazon.S3;
using Amazon.S3.Model;
using VehicleTracker.Application.Contracts.Interfaces.Services;

namespace VehicleTracker.Infrastructure.Services;

public class CloudflareR2StorageService(IAmazonS3 s3Client) : IStorageService
{
    private const string BucketName = "vehicle-tracker-avatar";
    private const string PublicUrl = "some url";

    public async Task<string> UploadFileAsync(Stream stream, string fileName, string contentType,
        CancellationToken ct)
    {
        var uploadRequest = new PutObjectRequest
        {
            InputStream = stream,
            BucketName = BucketName,
            Key = fileName,
            ContentType = contentType
        };

        await s3Client.PutObjectAsync(uploadRequest, ct);

        return $"{PublicUrl}/{fileName}";
    }
}