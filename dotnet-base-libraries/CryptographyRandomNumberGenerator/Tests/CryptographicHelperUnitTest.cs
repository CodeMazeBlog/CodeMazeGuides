namespace Tests;

public class CryptographicHelperUnitTest
{
    [Theory]
    [InlineData(32)]
    public void WhenRandomNumberGeneratorApiIsInvokedEveryTime_ThenItReturnsAUniqueRandomNumber(int bytesCount)
    {
        var randomNumberOne = CryptographicHelpers.GenerateSecureRandomKey(bytesCount);
        var randomNumberTwo = CryptographicHelpers.GenerateSecureRandomKey(bytesCount);

        Assert.NotEmpty(randomNumberOne);
        Assert.NotEmpty(randomNumberTwo);
        Assert.NotEqual(randomNumberOne, randomNumberTwo);
    }

    [Theory]
    [InlineData(1, 100)]
    public void WhenRandomNumberRangeIsProvided_ThenRandomNumberGeneratedShouldBeInTheRange(int minValue, int maxValue)
    {
        var randomNumber = CryptographicHelpers.GenerateSecureRandomInteger(minValue, maxValue);

        Assert.InRange(randomNumber, minValue, maxValue - 1);
    }
    
    [Theory]
    [InlineData(1, 100)]
    public void WhenPseudoRandomNumberRangeIsProvided_ThenRandomNumberGeneratedShouldBeInTheRange(int minValue, int maxValue)
    {
        var randomNumber = CryptographicHelpers.GenerateGeneralRandomInteger(minValue, maxValue);

        Assert.InRange(randomNumber, minValue, maxValue - 1);
    }

    [Theory]
    [InlineData(32)]
    public void WhenHexKeyIsGenerated_ThenItHasTheRequestedLengthAndOnlyLowercaseHexCharacters(int length)
    {
        var hexKey = CryptographicHelpers.GenerateHexKey(length);

        Assert.Equal(length, hexKey.Length);
        Assert.Matches("^[0-9a-f]+$", hexKey);
    }

    [Theory]
    [InlineData(16)]
    public void WhenTokenIsGenerated_ThenItHasTheRequestedLengthAndOnlyCharactersFromTheAlphabet(int length)
    {
        const string alphabet = "ABCDEFGHJKLMNPQRSTUVWXYZ23456789";

        var token = CryptographicHelpers.GenerateToken(length);

        Assert.Equal(length, token.Length);
        Assert.All(token, character => Assert.Contains(character, alphabet));
    }
}