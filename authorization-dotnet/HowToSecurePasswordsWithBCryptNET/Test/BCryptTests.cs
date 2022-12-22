namespace Test;

using BCrypt.Net;

public class BCryptTests
{
    [Fact]
    public void WhenHashingPassword_ThenReturnsNotNullString()
    {
        var passwordHash = BCrypt.HashPassword("Password123!");

        Assert.NotNull(passwordHash);
    }

    [Fact]
    public void WhenVerifyingPassword_ThenVerificationSucceeds()
    {
        var passwordHash = BCrypt.HashPassword("Password123!");

        var result = BCrypt.Verify("Password123!", passwordHash);

        Assert.True(result);
    }

    [Fact]
    public void WhenVerifyingWrongPassword_ThenVerificationFails()
    {
        var passwordHash = BCrypt.HashPassword("Password123!");

        var result = BCrypt.Verify("Wr0ngPassword!", passwordHash);

        Assert.False(result);
    }

    [Fact]
    public void WhenVerifyingPasswordWithEnhancedEntropy_ThenVerificationSucceeds()
    {
        var passwordHash = BCrypt.EnhancedHashPassword("Password123!");
        var result = BCrypt.EnhancedVerify("Password123!", passwordHash);

        Assert.True(result);
    }

    [Fact]
    public void WhenVerifyingPasswordWithEnhancedEntropyAndSHA512_ThenVerificationSucceeds()
    {
        var passwordHash = BCrypt.EnhancedHashPassword("Password123!", HashType.SHA512);
        var result = BCrypt.EnhancedVerify("Password123!", passwordHash, HashType.SHA512);

        Assert.True(result);
    }

    [Fact]
    public void WhenHashingPasswordWithHigherWorkFactor_ThenReturnsNotNullString()
    {
        var passwordHash = BCrypt.HashPassword("Password123!", workFactor: 13);

        Assert.NotNull(passwordHash);
    }
}