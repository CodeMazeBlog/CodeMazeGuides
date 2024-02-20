using AForge.Imaging.Filters;
using System.Drawing;
using System.Drawing.Imaging;

namespace AForgeDotNetLibrary;

public static class ImageService
{
    public static Bitmap CreateBlankImage(int width, int height)
    {
        return new Bitmap(width, height);
    }

    public static Bitmap DrawHexagonOnImage(Bitmap bitmap, Brush color, PointF[] points)
    {
        if (points == null || points.Length != 6)
        {
            throw new ArgumentException("Invalid points array. A hexagon should have 6 points.");
        }
        using (var g = Graphics.FromImage(bitmap))
        {
            g.FillPolygon(color, points);
        }

        return bitmap;
    }

    public static Bitmap ApplySepiaFilter(Bitmap bitmap)
    {
        var sepiaFilter = new Sepia();

        return sepiaFilter.Apply(bitmap);
    }

    public static Bitmap ApplyGaussianBlurFilter(Bitmap bitmap, double sigma)
    {
        var gaussianFilter = new GaussianBlur(sigma);

        return gaussianFilter.Apply(bitmap);
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