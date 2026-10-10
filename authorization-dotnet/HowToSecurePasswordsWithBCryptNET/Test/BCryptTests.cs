namespace Test;

using BCrypt.Net;
using HowToSecurePasswordsWithBCryptNET;

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

    [Fact]
    public void WhenWorkFactorBelowMinimum_ThenPasswordNeedsRehashReturnsTrue()
    {
        var passwordHash = BCrypt.HashPassword("Password123!", workFactor: 6);

        var result = BCrypt.PasswordNeedsRehash(passwordHash, 11);

        Assert.True(result);
    }

    [Fact]
    public void WhenWorkFactorAtMinimum_ThenPasswordNeedsRehashReturnsFalse()
    {
        var passwordHash = BCrypt.HashPassword("Password123!", workFactor: 11);

        var result = BCrypt.PasswordNeedsRehash(passwordHash, 11);

        Assert.False(result);
    }

    [Fact]
    public void WhenInterrogatingHash_ThenReturnsVersionAndWorkFactor()
    {
        var passwordHash = BCrypt.HashPassword("Password123!");

        var info = BCrypt.InterrogateHash(passwordHash);

        Assert.Equal("2a", info.Version);
        Assert.Equal("11", info.WorkFactor);
        Assert.Equal("$2a$11", info.Settings);
        Assert.Equal(60, passwordHash.Length);
    }

    [Fact]
    public void WhenVerifyingPhpGenerated2yHash_ThenVerificationSucceeds()
    {
        // The password_verify() example from the PHP manual.
        const string phpHash = "$2y$10$.vGA1O9wmRjrwAVXD98HNOgsNpDczlqm3Jq7KnEd1rVAGv3Fykk1a";

        Assert.True(BCrypt.Verify("rasmuslerdorf", phpHash));
        Assert.False(BCrypt.Verify("Wr0ngPassword!", phpHash));
    }

    [Theory]
    [InlineData('a')]
    [InlineData('b')]
    [InlineData('x')]
    [InlineData('y')]
    public void WhenUsingSupportedRevision_ThenHashVerifies(char revision)
    {
        var salt = BCrypt.GenerateSalt(6, revision);
        var passwordHash = BCrypt.HashPassword("Password123!", salt);

        Assert.StartsWith($"$2{revision}$", passwordHash);
        Assert.True(BCrypt.Verify("Password123!", passwordHash));
    }

    [Fact]
    public void WhenVerifyingUnsupportedRevision_ThenThrowsSaltParseException()
    {
        const string hash = "$2c$10$.vGA1O9wmRjrwAVXD98HNOgsNpDczlqm3Jq7KnEd1rVAGv3Fykk1a";

        Assert.Throws<SaltParseException>(() => BCrypt.Verify("rasmuslerdorf", hash));
    }

    [Fact]
    public void WhenVerifyingEnhancedHashWithPlainVerify_ThenVerificationFails()
    {
        var passwordHash = BCrypt.EnhancedHashPassword("Password123!");

        Assert.StartsWith("$2a$11$", passwordHash);
        Assert.False(BCrypt.Verify("Password123!", passwordHash));
        Assert.True(BCrypt.EnhancedVerify("Password123!", passwordHash));
        Assert.False(BCrypt.EnhancedVerify("Password123!", passwordHash, HashType.SHA512));
    }

    [Fact]
    public void WhenPasswordsShareFirst72Bytes_ThenEitherVerifiesAgainstEitherHash()
    {
        var prefix = new string('p', 72);
        var firstPassword = prefix + "ONE";
        var secondPassword = prefix + "TWO";

        var firstHash = BCrypt.HashPassword(firstPassword, workFactor: 6);
        var secondHash = BCrypt.HashPassword(secondPassword, workFactor: 6);

        Assert.True(BCrypt.Verify(secondPassword, firstHash));
        Assert.True(BCrypt.Verify(firstPassword, secondHash));
    }

    [Fact]
    public void WhenPasswordsShareFirst72Bytes_ThenEnhancedVerifyTellsThemApart()
    {
        var prefix = new string('p', 72);
        var firstHash = BCrypt.EnhancedHashPassword(prefix + "ONE", workFactor: 6);

        Assert.False(BCrypt.EnhancedVerify(prefix + "TWO", firstHash));
    }

    [Theory]
    [InlineData(3)]
    [InlineData(32)]
    public void WhenWorkFactorOutOfRange_ThenThrowsArgumentOutOfRangeException(int workFactor)
    {
        var exception = Assert.Throws<ArgumentOutOfRangeException>(
            () => BCrypt.HashPassword("Password123!", workFactor));

        Assert.Equal("workFactor", exception.ParamName);
    }

    [Fact]
    public void WhenWorkFactorAtBounds_ThenSaltIsGenerated()
    {
        // Never hash at work factor 31: that is 2^31 rounds. The salt alone proves the bound.
        Assert.StartsWith("$2a$04$", BCrypt.GenerateSalt(4));
        Assert.StartsWith("$2a$31$", BCrypt.GenerateSalt(31));
    }

    [Fact]
    public void WhenStoredHashIsUnderCost_ThenLoginReturnsUpgradedHash()
    {
        var service = new PasswordLoginService();
        var storedHash = BCrypt.HashPassword("Password123!", workFactor: 6);

        var newHash = service.LoginAndUpgrade("Password123!", storedHash);

        Assert.NotNull(newHash);
        Assert.StartsWith("$2a$11$", newHash);
        Assert.True(BCrypt.Verify("Password123!", newHash));
    }

    [Fact]
    public void WhenStoredHashIsCurrent_ThenLoginReturnsNull()
    {
        var service = new PasswordLoginService();
        var storedHash = BCrypt.HashPassword("Password123!", workFactor: 11);

        Assert.Null(service.LoginAndUpgrade("Password123!", storedHash));
    }

    [Fact]
    public void WhenPasswordIsWrong_ThenLoginReturnsNull()
    {
        var service = new PasswordLoginService();
        var storedHash = BCrypt.HashPassword("Password123!", workFactor: 6);

        Assert.Null(service.LoginAndUpgrade("Wr0ngPassword!", storedHash));
    }
}
