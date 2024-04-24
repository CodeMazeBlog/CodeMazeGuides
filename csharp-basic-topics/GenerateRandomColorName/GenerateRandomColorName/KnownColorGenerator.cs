namespace GenerateRandomColorName;
using System.Drawing;

public static class KnownColorGenerator
{
    private static readonly KnownColor[] _allColors = Enum.GetValues<KnownColor>();

    public static Color GetRandomKnownColor()
    {
        int index = Random.Shared.Next(_allColors.Length);
        KnownColor randomColorName = _allColors[index];

        return Color.FromKnownColor(randomColorName);
    }
}