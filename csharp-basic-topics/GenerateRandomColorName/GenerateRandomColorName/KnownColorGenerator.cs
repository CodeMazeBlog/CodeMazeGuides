namespace GenerateRandomColorName;
using System.Drawing;

public static class KnownColorGenerator
{
    private static readonly KnownColor[] allColors = Enum.GetValues<KnownColor>();

    public static Color GetRandomKnownColor()
    {
        int index = Random.Shared.Next(allColors.Length);
        KnownColor randomColorName = allColors[index];
        return Color.FromKnownColor(randomColorName);
    }
}