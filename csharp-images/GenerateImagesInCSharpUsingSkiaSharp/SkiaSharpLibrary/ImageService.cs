using SkiaSharp;

namespace SkiaSharpLibrary;

public static class ImageService
{
    public static SKBitmap CreateBlankImage(int width, int height)
    {
        var bitmap = new SKBitmap(width, height);
        using var canvas = new SKCanvas(bitmap);
        canvas.Clear(SKColors.White);

        return bitmap;
    }

    public static void DrawSquareOnImage(SKBitmap bitmap, int squareSize, int startX, int startY)
    {
        if (squareSize <= 0 || startX <= 0 || startY <= 0)
        {
            throw new ArgumentException("Square size and coordinates must be greater than zero.");
        }
        using var canvas = new SKCanvas(bitmap);
        using var paint = new SKPaint();
        paint.Color = SKColors.Red;
        var square = new SKRect(startX, startY, startX + squareSize, startY + squareSize);
        canvas.DrawRect(square, paint);
    }

    public static void SaveImage(SKBitmap bitmap, string outputPath)
    {
        using var stream = new FileStream(outputPath, FileMode.Create, FileAccess.Write);
        using var image = SKImage.FromBitmap(bitmap);
        using var encodedImage = image.Encode();
        encodedImage.SaveTo(stream);
    }
}
