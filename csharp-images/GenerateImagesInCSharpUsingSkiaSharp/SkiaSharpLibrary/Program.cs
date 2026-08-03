using SkiaSharpLibrary;

string outputPath = @"outputImage.png";

int imageWidth = 400;
int imageHeight = 300;
int squareSize = 120;
int startX = (imageWidth - squareSize) / 2;
int startY = (imageHeight - squareSize) / 2;
var bitmap = ImageService.CreateBlankImage(imageWidth, imageHeight);
ImageService.DrawSquareOnImage(bitmap, squareSize, startX, startY);
ImageService.SaveImage(bitmap, outputPath);

Console.WriteLine("Image generated and saved successfully.");