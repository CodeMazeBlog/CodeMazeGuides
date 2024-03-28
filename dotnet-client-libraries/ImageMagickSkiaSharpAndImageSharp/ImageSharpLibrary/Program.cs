using ImageSharpLibrary;
using SixLabors.ImageSharp;

string outputPath = @"..\..\..\Image\outputImage.png";

var imageSize = new SizeF(350, 280);
var point1 = new PointF(50, 50);
var point2 = new PointF(250, 50);
var point3 = new PointF(150, 200);
var image = ImageService.CreateBlankImage((int)imageSize.Width, (int)imageSize.Height);
ImageService.DrawTriangleOnImage(image, point1, point2, point3);
ImageService.SaveImage(image, outputPath);

Console.WriteLine("Image generated and saved successfully in Image folder.");