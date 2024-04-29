using ImageMagick;
using ImageMagickLibrary;

namespace Tests;

public class ImageMagickLibraryLiveTest
{
    private const string OutputPath = @"outputImage.png";
    private const string NullOutputPath = "";
    private readonly MagickColor _color = MagickColors.Green;
    private readonly MagickGeometry _imageSize = new(480, 300);
    private readonly MagickGeometry _circle = new(50, 50, 100, 200);
    private readonly MagickColor _expectedColor;
    private readonly int _centerX;
    private readonly int _centerY;
    private readonly int _radius;
    private readonly int _strokeWidth;
    private readonly int _invalidPointX = -1;
    private readonly int _invalidPointY = -1;

    public ImageMagickLibraryLiveTest()
    {
        _expectedColor = _color;
        _centerX = _circle.X + _circle.Width / 2;
        _centerY = _circle.Y + _circle.Height / 2;
        _radius = _circle.Width / 2;
        _strokeWidth = 5;
    }

    private MagickImage CreateCircleImage()
    {
        var drawables = ImageService.CreateCircle(_centerX, _centerY, _radius, _strokeWidth, _expectedColor, MagickColors.Transparent);
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
        var edgePixel = pixels.GetPixel(_centerX + _radius - _strokeWidth / 2, _centerY);
        var edgeColor = edgePixel.ToColor();

        Assert.Equal(_expectedColor, edgeColor);

        // Check the color outside the circle
        var outsidePixel = pixels.GetPixel(_centerX + _radius + _strokeWidth / 2 + 1, _centerY);
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
        Assert.Throws<ArgumentException>(() =>
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
            var circle = ImageService.CreateCircle(_invalidPointX, _invalidPointY, 100, 5, strokeColor, fillColor);
            ImageService.DrawOnImage(image, circle);
        });
    }
}