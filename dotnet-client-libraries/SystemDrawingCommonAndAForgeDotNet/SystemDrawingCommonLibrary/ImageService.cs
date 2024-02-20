using System.Drawing;
using System.Drawing.Imaging;

namespace SystemDrawingCommonLibrary;

public static class ImageService
{
    public static Bitmap CreateBlankImage(Size imageSize)
    {
        return new Bitmap(imageSize.Width, imageSize.Height);
    }

    public static void DrawRectangleOnImage(Bitmap bitmap, Rectangle rect, Brush color)
    {
        if (rect.Width <= 0 || rect.Height <= 0)
        {
            throw new ArgumentException("The rectangle's width and height must be greater than 0");
        }
        using var graphics = Graphics.FromImage(bitmap);
        graphics.FillRectangle(color, rect);
    }

    public static void SaveImage(Bitmap bitmap, string outputPath, ImageFormat format)
    {
        var directory = Path.GetDirectoryName(outputPath);
        Directory.CreateDirectory(directory);
        try
        {
            bitmap.Save(outputPath, format);
        }
        catch (System.Runtime.InteropServices.ExternalException)
        {
            throw new UnauthorizedAccessException($"No write permission for path: {outputPath}");
        }
    }
}
