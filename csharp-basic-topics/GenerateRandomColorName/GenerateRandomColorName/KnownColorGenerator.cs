namespace GenerateRandomColorName;
using System.Drawing;

public class KnownColorGenerator
{
    private Random randomGen;

    public KnownColorGenerator()
    {
        randomGen = new Random();
    }

    public Color GetRandomKnownColor()
    {
        KnownColor[] allColors = (KnownColor[])Enum.GetValues(typeof(KnownColor));
        KnownColor randomColorName = allColors[randomGen.Next(allColors.Length)];

        return Color.FromKnownColor(randomColorName);
    }
}