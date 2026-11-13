using ImageSharpLibrary;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;

namespace Tests;

public class ImageServiceTests
{
    private const string OutputPath = "outputImage.png";
    private const string EmptyOutputPath = "";
    private readonly int _width = 350;
    private readonly int _height = 280;

    [Fact]
    public void GivenWidthAndHeight_WhenCreatingBlankImage_ThenImageIsCreatedWithGivenDimensions()
    {
        using var image = ImageService.CreateBlankImage(_width, _height);

        Assert.Equal(_width, image.Width);
        Assert.Equal(_height, image.Height);
    }

    [Fact]
    public void GivenBlankImage_WhenReadingAPixel_ThenPixelIsTransparent()
    {
        using var image = ImageService.CreateBlankImage(_width, _height);

        Assert.Equal(new Rgba32(0, 0, 0, 0), image[10, 10]);
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
    public void GivenValidPoints_WhenDrawingTriangleOnImage_ThenEdgePixelIsRed()
    {
        using var image = ImageService.CreateBlankImage(_width, _height);

        ImageService.DrawTriangleOnImage(image, new PointF(50, 50), new PointF(250, 50), new PointF(150, 200));

        Assert.Equal(new Rgba32(255, 0, 0, 255), image[150, 50]);
        Assert.Equal(new Rgba32(255, 0, 0, 255), image[100, 125]);
        Assert.Equal(new Rgba32(0, 0, 0, 0), image[150, 120]);
    }

    [Fact]
    public void GivenInvalidPoints_WhenDrawingTriangleOnImage_ThenThrowsArgumentException()
    {
        using var image = ImageService.CreateBlankImage(_width, _height);

        Assert.Throws<ArgumentException>(() =>
            ImageService.DrawTriangleOnImage(image, new PointF(-50, 50), new PointF(150, 50), new PointF(100, 200)));
    }

    [Fact]
    public void GivenImageAndValidPath_WhenSavingImage_ThenPngFileIsWritten()
    {
        using var image = ImageService.CreateBlankImage(_width, _height);

        ImageService.SaveImage(image, OutputPath);

        Assert.True(File.Exists(OutputPath));
        using var saved = Image.Load<Rgba32>(OutputPath);
        Assert.Equal(_width, saved.Width);
        File.Delete(OutputPath);
    }

    [Fact]
    public void GivenEmptyPath_WhenSavingImage_ThenThrowsArgumentException()
    {
        using var image = ImageService.CreateBlankImage(_width, _height);

        Assert.Throws<ArgumentException>(() => ImageService.SaveImage(image, EmptyOutputPath));
    }
}
