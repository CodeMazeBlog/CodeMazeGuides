using ImageMagick;
using ImageMagickLibrary;

string outputPath = @"outputImage.png";

var image = ImageService.CreateBlankImage(480, 300, MagickColors.AliceBlue);
var strokeColor = MagickColors.YellowGreen;
var fillColor = MagickColors.Transparent;
var circle = ImageService.CreateCircle(image.Width / 2, image.Height / 2, 100, 5, strokeColor, fillColor);
ImageService.DrawOnImage(image, circle);
ImageService.SaveImage(image, outputPath);

Console.WriteLine("Image generated and saved successfully.");