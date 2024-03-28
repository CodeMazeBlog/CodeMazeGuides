using SkiaSharp;

namespace SkiaSharpLibrary;

public static class ImageService
{
    public static SKBitmap CreateBlankImage(int width, int height)
    {
        var bitmap = new SKBitmap(width, height);
        using (var canvas = new SKCanvas(bitmap))
        canvas.Clear(SKColors.White);

        return bitmap;
    }

    public static void DrawSquareOnImage(SKBitmap bitmap, int squareSize, int startX, int startY)
    {
        if (squareSize <= 0)
        { 
            throw new ArgumentException("Square dimensions cannot be less than or equal to zero.");
        }
        using var canvas = new SKCanvas(bitmap);
        using var paint = new SKPaint();
        paint.Color = SKColors.Red;
        var square = new SKRect(startX, startY, startX + squareSize, startY + squareSize);
        canvas.DrawRect(square, paint);
    }

    public static void SaveImage(SKBitmap bitmap, string outputPath)
    {
        var directory = Path.GetDirectoryName(outputPath);
        Directory.CreateDirectory(directory);
        try
        {
            using var stream = new FileStream(outputPath, FileMode.Create, FileAccess.Write);
            SKImage.FromBitmap(bitmap).Encode(SKEncodedImageFormat.Png, 100).SaveTo(stream);
        }
        catch (System.Runtime.InteropServices.ExternalException)
        {
            throw new UnauthorizedAccessException($"No write permission for path: {outputPath}");
        }
    }
}
