using YieldBreakInCSharp;

namespace Tests;

public class UtilityTests
{
    [Fact]
    public void GenerateRandomYears_WhenCalled_StopsAtTheFirstLeapYear()
    {
        // Act
        var years = Utility.GenerateRandomYears().ToList();

        // Assert
        Assert.True(DateTime.IsLeapYear(years[^1]));
        Assert.All(years.SkipLast(1), year => Assert.False(DateTime.IsLeapYear(year)));
    }

    [Fact]
    public void GenerateRandomYearsWithUnreachableCode_WhenCalled_SkipsTheLineAfterTheLoop()
    {
        // Act
        var output = CaptureConsole(() => Utility.GenerateRandomYearsWithUnreachableCode().ToList());

        // Assert
        Assert.DoesNotContain("executed successfully", output);
    }

    [Fact]
    public void GenerateRandomYearsWithBreak_WhenCalled_RunsTheLineAfterTheLoop()
    {
        // Act
        var output = CaptureConsole(() => Utility.GenerateRandomYearsWithBreak().ToList());

        // Assert
        Assert.Contains("executed successfully", output);
    }

    [Fact]
    public void GenerateRandomYearsWithCleanup_WhenCalled_RunsTheFinallyBlock()
    {
        // Act
        var output = CaptureConsole(() => Utility.GenerateRandomYearsWithCleanup().ToList());

        // Assert
        Assert.Contains("The finally block ran.", output);
    }

    private static string CaptureConsole(Action action)
    {
        var original = Console.Out;
        using var writer = new StringWriter();
        Console.SetOut(writer);
        try
        {
            action();
        }
        finally
        {
            Console.SetOut(original);
        }

        return writer.ToString();
    }
}
