using App;

namespace Tests;

public class CryptographicHelperUnitTest
{
    [Theory]
    [InlineData(32)]
    public void WhenRandomNumberGeneratorApiIsInvokedEveryTime_ThenItReturnsAUniqueRandomNumber(int bytesCount)
    {
        var randomNumberOne = CryptographicHelpers.GenerateRandomKey(bytesCount);
        var randomNumberTwo = CryptographicHelpers.GenerateRandomKey(bytesCount);

        Assert.NotEmpty(randomNumberOne);
        Assert.NotEmpty(randomNumberTwo);
        Assert.NotEqual(randomNumberOne, randomNumberTwo);
    }

    [Theory]
    [InlineData(1, 100)]
    public void WhenRandomNumberRangeIsProvided_ThenRandomNumberGeneratedShouldBeInTheRange(int minValue, int maxValue)
    {
        var randomNumber = CryptographicHelpers.GenerateRandomInteger(minValue, maxValue);

        Assert.NotEqual(0, randomNumber);
        Assert.InRange(randomNumber, minValue, maxValue);
    }
}