using System.Drawing.Imaging;
using System.Drawing;
using SystemDrawingCommonLibrary;

string outputPath = @"..\..\..\Image\outputImage.png";

var imageSize = new Size(400, 200);
var rect = new Rectangle(50, 50, 100, 200);
var color = Brushes.Green;
var bitmap = ImageService.CreateBlankImage(imageSize);
ImageService.DrawRectangleOnImage(bitmap, rect, color);
ImageService.SaveImage(bitmap, outputPath, ImageFormat.Png);

Console.WriteLine("Image generated and saved successfully in Image folder.");