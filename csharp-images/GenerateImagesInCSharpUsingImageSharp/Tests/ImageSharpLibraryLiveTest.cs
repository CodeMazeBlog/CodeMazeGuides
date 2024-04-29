using ImageSharpLibrary;
using SixLabors.ImageSharp.PixelFormats;
using SixLabors.ImageSharp;

namespace Tests;

public class ImageSharpLibraryLiveTest
{
    private const string OutputPath = @"outputImage.png";
    private const string NullOutputPath = "";
    private readonly int _width = 350;
    private readonly int _height = 280;

    [Fact]
    public void GivenWidthAndHeight_WhenCreatingBlankImage_ThenImageIsCreatedWithGivenDimensions()
    {
        var image = ImageService.CreateBlankImage(_width, _height);

        Assert.Equal(_width, image.Width);

        Assert.Equal(_height, image.Height);
    }

    [Theory]
    [InlineData(0, 10)]
    [InlineData(10, 0)]
    [InlineData(-10, 10)]
    [InlineData(10, -10)]
    public void GivenInvalidPoint_WhenValidatingPoint_ThenThrowsArgumentException(float x, float y)
    {
        var point = new PointF(x, y);

        Assert.Throws<ArgumentException>(() => ImageService.ValidatePoint(point));
    }

    [Fact]
    public void GivenValidPoints_WhenDrawingTriangleOnImage_ThenDoesNotThrowException()
    {
        var image = ImageService.CreateBlankImage(_width, _height);
        var point1 = new PointF(50, 50);
        var point2 = new PointF(250, 50);
        var point3 = new PointF(150, 200);

        var ex = Record.Exception(() => ImageService.DrawTriangleOnImage(image, point1, point2, point3));

        Assert.Null(ex);
    }

    [Fact]
    public void GivenImageAndValidPath_WhenSavingImage_ThenImageSavedSuccessfully()
    {
        var image = ImageService.CreateBlankImage(_width, _height);
        ImageService.SaveImage(image, OutputPath);

        Assert.True(File.Exists(OutputPath));

        File.Delete(OutputPath);
    }

    [Fact]
    public void GivenValidPoints_WhenDrawingTriangleOnImage_ThenImageIsChanged()
    {
        var point1 = new PointF(50, 50);
        var point2 = new PointF(150, 50);
        var point3 = new PointF(100, 200);
        var image = new Image<Rgba32>(_width, _height);
        var originalImage = image.Clone();

        ImageService.DrawTriangleOnImage(image, point1, point2, point3);

        Assert.NotEqual(originalImage, image);
    }

    [Fact]
    public void GivenInvalidPoints_WhenDrawingTriangleOnImage_ThenThrowsArgumentException()
    {
        var point1 = new PointF(-50, 50);
        var point2 = new PointF(150, 50);
        var point3 = new PointF(100, 200);
        var image = new Image<Rgba32>(_width, _height);

        Assert.Throws<ArgumentException>(() => ImageService.DrawTriangleOnImage(image, point1, point2, point3));
    }

    [Fact]
    public void GivenNullPath_WhenSavingImage_ThenThrowsArgumentNullException()
    {
        var image = ImageService.CreateBlankImage(_width, _height);

        Assert.Throws<ArgumentException>(() => ImageService.SaveImage(image, NullOutputPath));
    }
}