namespace Tests;
using GenerateRandomColorName;
using System.Drawing;
using Xunit;

public class KnownColorTests
{
    [Fact]
    public void GivenGenerator_WhenGetRandomKnownColorCalled_ThenColorIsFromKnownColorEnum()
    {
        Color color = KnownColorGenerator.GetRandomKnownColor();

        Assert.True(color.IsKnownColor, "The color should be a known color.");
    }

    [Fact]
    public void GivenGenerator_WhenGetRandomKnownColorCalled_ThenReturnsNonDefaultColorObject()
    {
        Color color = KnownColorGenerator.GetRandomKnownColor();

        Assert.False(color.IsEmpty, "The returned color should not be the default (empty) Color object.");
    }
}
