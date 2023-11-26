using ActionFuncDemo;

namespace Tests;

public class FuncExampleTests
{
    [Fact]
    public void CalculateAgeInTenYears_Should_Return_Correct_Result()
    {
        var initialAge = 5;
        var expectedAgeInTenYears = 15;

        var result = FuncExample.CalculateAgeInTenYears(initialAge);

        Assert.Equal(expectedAgeInTenYears, result);
    }
}