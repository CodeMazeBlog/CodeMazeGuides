namespace Tests;
using GenerateRandomColorName;
using System.Drawing;
using Xunit;

public class KnownColorTests
{
    [Fact]
    public void GivenGenerator_WhenGetRandomKnownColorCalled_ThenColorIsFromKnownColorEnum()
    {
        KnownColorGenerator generator = new KnownColorGenerator();
        Color color = generator.GetRandomKnownColor();
        KnownColor knownColor = (KnownColor)Enum.Parse(typeof(KnownColor), color.Name);

        KnownColor[] allColors = (KnownColor[])Enum.GetValues(typeof(KnownColor));

        Assert.Contains(knownColor, allColors);
    }

    [Fact]
    public void GivenGenerator_WhenGetRandomKnownColorCalled_ThenReturnsNonDefaultColorObject()
    {
        KnownColorGenerator generator = new KnownColorGenerator();

        Color color = generator.GetRandomKnownColor();

        Assert.False(color.IsEmpty, "The returned color should not be the default (empty) Color object.");
    }

    [Fact]
    public void GivenGenerator_WhenGetRandomKnownColorCalledMultipleTimes_ThenGeneratesSomeDuplicateColors()
    {
        KnownColorGenerator generator = new KnownColorGenerator();
        var colorCounts = new Dictionary<KnownColor, int>();
        int iterations = 200;

        for (int i = 0; i < iterations; i++)
        {
            Color color = generator.GetRandomKnownColor();
            KnownColor knownColor = (KnownColor)Enum.Parse(typeof(KnownColor), color.Name, true);

            if (!colorCounts.ContainsKey(knownColor))
                colorCounts[knownColor] = 0;

            colorCounts[knownColor]++;
        }

        bool hasDuplicates = colorCounts.Any(kvp => kvp.Value > 1);

        Assert.True(hasDuplicates, "Expect some colors to be generated more than once to confirm randomness.");
    }
}
