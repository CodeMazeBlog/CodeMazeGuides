﻿using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;
using SixLabors.ImageSharp.Processing;
using SixLabors.ImageSharp.Drawing.Processing;

namespace ImageSharpLibrary;

public static class ImageService
{
    public static Image<Rgba32> CreateBlankImage(int width, int height)
    {
        return new Image<Rgba32>(width, height);
    }

    public static void DrawTriangleOnImage(Image<Rgba32> image, PointF point1, PointF point2, PointF point3)
    {
        ValidatePoint(point1);
        ValidatePoint(point2);
        ValidatePoint(point3);
        var pen = Pens.Solid(Color.Red, 3);
        image.Mutate(ctx => ctx.DrawPolygon(pen, [point1, point2, point3, point1]));
    }

    public static void ValidatePoint(PointF point)
    {
        if (point.X <= 0 || point.Y <= 0)
        {
            throw new ArgumentException("Point coordinates cannot be less than or equal to zero.");
        }         
    }

    public static void SaveImage(Image<Rgba32> image, string outputPath)
    {
        try
        {
            image.SaveAsPng(outputPath);
        }
        catch (Exception ex)
        {
            throw new Exception($"An error occurred: {ex.Message}");
        }
    }
}