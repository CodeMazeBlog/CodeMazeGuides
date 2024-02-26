using SixLabors.ImageSharp.PixelFormats;
using SixLabors.ImageSharp;
using ImageSharpLibrary;

namespace Tests;

public class ImageSharpLibraryLiveTest
{
    private readonly int _width = 350;
    private readonly int _height = 280;
    private const string _invalidOutputPath = @"C:\Windows\System32\outputImage.png";
    private const string _validOutputPath = @"..\..\..\Image\outputImage.png";
    private const string _nullOutputPath = "";

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
    public void GivenImageAndPathWithNoWritePermission_WhenSavingImage_ThenThrowsUnauthorizedAccessException()
    {
        var image = ImageService.CreateBlankImage(_width, _height);
        Assert.Throws<UnauthorizedAccessException>(() => ImageService.SaveImage(image, _invalidOutputPath));
    }

    [Fact]
    public void GivenImageAndValidPath_WhenSavingImage_ThenDoesNotThrowException()
    {
        var image = ImageService.CreateBlankImage(_width, _height);
        var ex = Record.Exception(() => ImageService.SaveImage(image, _validOutputPath));
        Assert.Null(ex);
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
        Assert.Throws<ArgumentNullException>(() => ImageService.SaveImage(image, _nullOutputPath));
    }
}