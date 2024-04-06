using ImageMagick;

namespace ImageMagickLibrary;

public static class ImageService
{
    public static MagickImage CreateBlankImage(int width, int height, MagickColor color)
    {
        return new MagickImage(color, width, height);
    }

    public static Drawables CreateCircle(
        int centerX,
        int centerY,
        int radius,
        int strokeWidth,
        MagickColor strokeColor,
        MagickColor fillColor)
    {
        if (centerX <= 0 || centerY <= 0 || radius <= 0 || strokeWidth <= 0)
        {
            throw new ArgumentException(
                "The values for the circle's center, radius, and stroke width must be greater than zero."
            );
        }
        var drawables = new Drawables();
        drawables.StrokeColor(strokeColor);
        drawables.FillColor(fillColor);
        drawables.StrokeWidth(strokeWidth);
        drawables.Circle(centerX, centerY, centerX, centerY - radius);

        return drawables;
    }

    public static void DrawOnImage(MagickImage image, Drawables drawables)
    {
        image.Draw(drawables);
    }

    public static void SaveImage(MagickImage image, string outputPath)
    {
        image.Write(outputPath, MagickFormat.Png);
    }
}
