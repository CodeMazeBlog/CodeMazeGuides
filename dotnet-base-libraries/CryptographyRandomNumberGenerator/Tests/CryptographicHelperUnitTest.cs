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

        Assert.InRange(randomNumber, minValue, maxValue);
    }
    
    [Theory]
    [InlineData(1, 100)]
    public void WhenPseudoRandomNumberRangeIsProvided_ThenRandomNumberGeneratedShouldBeInTheRange(int minValue, int maxValue)
    {
        var randomNumber = CryptographicHelpers.GenerateGeneralRandomInteger(minValue, maxValue);

        Assert.InRange(randomNumber, minValue, maxValue);
    }
}