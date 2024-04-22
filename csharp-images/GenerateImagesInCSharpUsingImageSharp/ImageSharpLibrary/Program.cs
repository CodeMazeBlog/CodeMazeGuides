using ImageSharpLibrary;
using SixLabors.ImageSharp;

string outputPath = @"outputImage.png";

using var image = ImageService.CreateBlankImage(width: 350, height: 280);

var point1 = new PointF(50, 50);
var point2 = new PointF(250, 50);
var point3 = new PointF(150, 200);
ImageService.DrawTriangleOnImage(image, point1, point2, point3);

ImageService.SaveImage(image, outputPath);

Console.WriteLine("Image generated and saved successfully.");