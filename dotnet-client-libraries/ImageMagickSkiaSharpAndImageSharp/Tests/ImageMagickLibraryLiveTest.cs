using ImageMagick;
using ImageMagickLibrary;

namespace Tests;

public class ImageMagickLibraryLiveTest
{
    private readonly MagickColor _color = MagickColors.Green;
    private readonly MagickGeometry _imageSize = new(480, 300);
    private readonly MagickGeometry _circle = new(50, 50, 100, 200);
    private const string OutputPath = @"..\..\..\Image\outputImage.png";
    private const string NullOutputPath = "";

    private readonly MagickColor expectedColor;
    private readonly int centerX;
    private readonly int centerY;
    private readonly int radius;
    private readonly int strokeWidth;
    private readonly int invalidPointX = -1;
    private readonly int invalidPointY = -1;

    public ImageMagickLibraryLiveTest()
    {
        expectedColor = _color;
        centerX = _circle.X + _circle.Width / 2;
        centerY = _circle.Y + _circle.Height / 2;
        radius = _circle.Width / 2;
        strokeWidth = 5;
    }

    private MagickImage CreateCircleImage()
    {
        var drawables = ImageService.CreateCircle(centerX, centerY, radius, strokeWidth, expectedColor, MagickColors.Transparent);
        var image = ImageService.CreateBlankImage(_imageSize.Width, _imageSize.Height, MagickColors.White);
        ImageService.DrawOnImage(image, drawables);

        return image;
    }

    [Fact]
    public void GivenValidSize_WhenCreateBlankImage_ThenReturnMagickImage()
    {
        // Arrange
        var expectedImage = new MagickImage(new MagickColor("white"), _imageSize.Width, _imageSize.Height);

        // Act
        var actualImage = ImageService.CreateBlankImage(_imageSize.Width, _imageSize.Height, MagickColors.White);

        // Assert
        Assert.Equal(expectedImage.Width, actualImage.Width);
        Assert.Equal(expectedImage.Height, actualImage.Height);
    }

    [Theory]
    [InlineData(0, 200)]
    [InlineData(400, 0)]
    public void GivenInvalidSize_WhenCreateBlankImage_ThenThrowArgumentException(int width, int height)
    {
        // Arrange, Act & Assert
        Assert.Throws<ArgumentException>(() => ImageService.CreateBlankImage(width, height, MagickColors.White));
    }

    [Fact]
    public void GivenValidParameters_WhenCreateCircle_ThenCircleIsDrawn()
    {
        // Act
        var image = CreateCircleImage();

        // Assert
        using var pixels = image.GetPixels();
        // Check the color at the edge of the circle
        var edgePixel = pixels.GetPixel(centerX + radius - strokeWidth / 2, centerY);
        var edgeColor = edgePixel.ToColor();

        Assert.Equal(expectedColor, edgeColor);

        // Check the color outside the circle
        var outsidePixel = pixels.GetPixel(centerX + radius + strokeWidth / 2 + 1, centerY);
        var outsideColor = outsidePixel.ToColor();

        Assert.Equal(MagickColors.White, outsideColor);
    }

    [Fact]
    public void GivenImageAndPath_WhenSaveImage_ThenImageSavedSuccessfully()
    {
        // Arrange
        var image = CreateCircleImage();

        // Act
        ImageService.SaveImage(image, OutputPath);

        // Assert
        Assert.True(File.Exists(OutputPath));

        // Cleanup
        File.Delete(OutputPath);
    }

    [Fact]
    public void GivenNullPath_WhenSaveImage_ThenThrowException()
    {
        //Arrange
        var image = ImageService.CreateBlankImage(_imageSize.Width, _imageSize.Height, MagickColors.AliceBlue);

        // Act & Assert
        Assert.Throws<ArgumentNullException>(() =>
        {
            ImageService.SaveImage(image, NullOutputPath);
        });
    }

    [Fact]
    public void GivenInvalidPoints_WhenDrawCircleOnImage_ThenThrowsArgumentException()
    {
        //Arrange
        var strokeColor = MagickColors.YellowGreen;
        var fillColor = MagickColors.Transparent;
        var image = ImageService.CreateBlankImage(_imageSize.Width, _imageSize.Height, MagickColors.AliceBlue);

        // Act & Assert
        Assert.Throws<ArgumentException>(() =>
        {
            var circle = ImageService.CreateCircle(invalidPointX, invalidPointY, 100, 5, strokeColor, fillColor);
            ImageService.DrawOnImage(image, circle);
        });
    }

}