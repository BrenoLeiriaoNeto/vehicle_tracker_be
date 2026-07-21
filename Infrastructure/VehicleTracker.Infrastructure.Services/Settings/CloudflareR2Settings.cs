namespace VehicleTracker.Infrastructure.Services.Settings;

public class CloudflareR2Settings
{
    public const string SectionName = "CloudflareR2";

    public string ServiceUrl { get; set; } = string.Empty;
    public string PublicUrlDomain { get; set; } = string.Empty;
    public string BucketName { get; set; } = string.Empty;
    public string AccessKeyId { get; set; } = string.Empty;
    public string SecretAccessKey { get; set; } = string.Empty;
}