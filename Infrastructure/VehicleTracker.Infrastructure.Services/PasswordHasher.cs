using System.Security.Cryptography;
using System.Text;
using Konscious.Security.Cryptography;
using VehicleTracker.Application.Contracts.Interfaces.Services;

namespace VehicleTracker.Infrastructure.Services;

public class PasswordHasher : IPasswordHasher
{
    private const int SaltSize = 16;
    private const int HashSize = 32;
    private const int Iterations = 3;
    private const int MemorySize = 65536;
    private const int DegreeOfParallelism = 4;
    
    public string HashPassword(string password)
    {
        var salt = RandomNumberGenerator.GetBytes(SaltSize);

        using var argon2 = new Argon2id(Encoding.UTF8.GetBytes(password))
        {
            Salt = salt,
            DegreeOfParallelism = DegreeOfParallelism,
            Iterations = Iterations,
            MemorySize = MemorySize
        };

        var hash = argon2.GetBytes(HashSize);

        return $"{Convert.ToBase64String(salt)}.{Convert.ToBase64String(hash)}";
    }

    public bool VerifyPassword(string password, string hashedPassword)
    {
        var parts = hashedPassword.Split('.');
        if (parts.Length != 2) return false;

        var salt = Convert.FromBase64String(parts[0]);
        var expectedHash = Convert.FromBase64String(parts[1]);

        using var argon2 = new Argon2id(Encoding.UTF8.GetBytes(password))
        {
            Salt = salt,
            DegreeOfParallelism = DegreeOfParallelism,
            Iterations = Iterations,
            MemorySize = MemorySize
        };

        var testHash = argon2.GetBytes(HashSize);

        return CryptographicOperations.FixedTimeEquals(testHash, expectedHash);
    }
}