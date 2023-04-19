using YieldBreakInCSharp;

namespace Tests;

public class UtilityTests
{
    [Fact]
    public void GenerateRandomYears_WhenCalled_GenerateRandomYears()
    {
        // Act
        var years = Utility.GenerateRandomYears();

        // Assert
        Assert.NotEmpty(years);
    }

    [Fact]
    public void GenerateRandomYearsWithBreak_WhenCalled_GenerateRandomYears()
    {
        // Act
        var years = Utility.GenerateRandomYearsWithBreak();

        // Assert
        Assert.NotEmpty(years);
    }
}