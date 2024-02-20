using AForgeDotNetLibrary;
using System.Drawing;
using System.Drawing.Imaging;

string outputPath = @"..\..\..\Image\outputImage.jpeg";

var bitmap = ImageService.CreateBlankImage(480, 300);
bitmap = ImageService.DrawHexagonOnImage(bitmap, Brushes.Blue, GetHexagonPoints());
var sepiaFilteredImage = ImageService.ApplySepiaFilter(bitmap);
var gaussianBlurredImage = ImageService.ApplyGaussianBlurFilter(sepiaFilteredImage, 2.0);
ImageService.SaveImage(gaussianBlurredImage, outputPath, ImageFormat.Jpeg);

Console.WriteLine($"Image created, modified, and saved successfully in Image Folder.");

static PointF[] GetHexagonPoints()
{
    return new PointF[] {
        new(240, 100),
        new(290, 125),
        new(290, 175),
        new(240, 200),
        new(190, 175),
        new(190, 125)
    };        
}
