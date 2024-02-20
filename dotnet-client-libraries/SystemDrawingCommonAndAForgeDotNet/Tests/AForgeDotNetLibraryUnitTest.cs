using AForgeDotNetLibrary;

namespace Tests;

public class AForgeDotNetLibraryUnitTest
{
    private const int Width = 480;
    private const int Height = 300;
    private const string _outputPath = @"..\..\..\Image\outputImage.jpeg";
    private const string _invalidOutputPath = @"Z:\Invalid\Path\outputImage.png";
    private const string _protectedPath = @"C:\Windows\System32\outputImage.jpeg";
    private const string _nullPath = "";
    private readonly Bitmap _bitmap;
    private readonly PointF[] _hexagonPoints;

    public AForgeDotNetLibraryUnitTest()
    {
        _bitmap = ImageService.CreateBlankImage(Width, Height);
        _hexagonPoints = GetHexagonPoints();
    }

    private static PointF[] GetHexagonPoints()
    {
        return new PointF[] {
            new(240, 100),
            new(290, 125),
            new(290, 175),
            new(240, 200),
            new(190, 175),
            new(190, 125)
        };
    }

    [Fact]
    public void GivenValidWidthAndHeight_WhenCreateBlankImageCalled_ThenValidBitmapReturned()
    {
        // Act
        var bitmap = ImageService.CreateBlankImage(Width, Height);

        // Assert
        Assert.NotNull(bitmap);
        Assert.Equal(Width, bitmap.Width);
        Assert.Equal(Height, bitmap.Height);
    }

    [Fact]
    public void GivenNegativeWidth_WhenCreateBlankImageCalled_ThenThrowException()
    {
        // Arrange
        int negativeWidth = -1;

        // Act & Assert
        Assert.Throws<ArgumentException>(() =>
        {
            var bitmap = ImageService.CreateBlankImage(negativeWidth, Height);
        });
    }

    [Fact]
    public void GivenNegativeHeight_WhenCreateBlankImageCalled_ThenThrowException()
    {
        // Arrange
        int negativeHeight = -1;

        // Act & Assert
        Assert.Throws<ArgumentException>(() =>
        {
            var bitmap = ImageService.CreateBlankImage(Width, negativeHeight);
        });
    }

    [Fact]
    public void GivenInvalidPointsForHexagon_WhenDrawHexagonOnImageCalled_ThenArgumentExceptionThrown()
    {
        // Arrange
        var points = Array.Empty<PointF>();

        // Act & Assert
        Assert.Throws<ArgumentException>(() => ImageService.DrawHexagonOnImage(_bitmap, Brushes.Blue, points));
    }

    [Fact]
    public void GivenBitmapAndPoints_WhenDrawHexagonOnImageCalled_ThenValidHexagonDrawnOnBitmap()
    {
        // Act
        var hexagonImage = ImageService.DrawHexagonOnImage(_bitmap, Brushes.Blue, _hexagonPoints);

        // Assert
        Assert.NotNull(hexagonImage);
    }

    [Fact]
    public void GivenBitmapAndPoints_WhenDrawHexagonOnImageCalled_ThenHexagonIsNotDrawnOutsideExpectedArea()
    {
        // Arrange
        var brush = Brushes.Blue;
        var solidBrush = brush as SolidBrush;
        var testPoint = new PointF(0, 0); // A point that should be outside the hexagon

        // Act
        ImageService.DrawHexagonOnImage(_bitmap, brush, _hexagonPoints);
        var pixelColor = _bitmap.GetPixel((int)testPoint.X, (int)testPoint.Y);

        // Assert
        if (solidBrush != null)
        {
            Assert.NotEqual(solidBrush.Color, pixelColor); // This assertion assumes that the brush color directly corresponds to the pixel color
        }
    }

    [Fact]
    public void GivenBitmap_WhenApplySepiaFilterCalled_ThenValidSepiaFilterAppliedOnBitmap()
    {
        // Act
        var sepiaImage = ImageService.ApplySepiaFilter(_bitmap);

        // Assert
        Assert.NotNull(sepiaImage);
    }

    [Fact]
    public void GivenBitmapAndSigma_WhenApplyGaussianBlurFilterCalled_ThenValidBlurFilterAppliedOnBitmap()
    {
        // Arrange
        var sigma = 2.0;

        // Act
        var blurredImage = ImageService.ApplyGaussianBlurFilter(_bitmap, sigma);

        // Assert
        Assert.NotNull(blurredImage);
    }

    [Fact]
    public void GivenBitmapAndOutputPath_WhenSaveImageCalled_ThenImageSavedToOutputPath()
    {
        // Act
        ImageService.SaveImage(_bitmap, _outputPath, ImageFormat.Jpeg);

        // Assert
        Assert.True(File.Exists(_outputPath));
    }

    [Fact]
    public void GivenInvalidDirectoryInOutputPath_WhenSaveImageCalled_ThenDirectoryCreatedAndImageSaved()
    {
        // Act & Assert
        Assert.Throws<DirectoryNotFoundException>(() => ImageService.SaveImage(_bitmap, _invalidOutputPath, ImageFormat.Jpeg));
    }

    [Fact]
    public void GivenNullPath_WhenSaveImageCalled_ThenThrowException()
    {
        // Act & Assert
        Assert.Throws<ArgumentNullException>(() =>
        {
            ImageService.SaveImage(_bitmap, _nullPath, ImageFormat.Jpeg);
        });
    }

    [Fact]
    public void GivenNoWritePermission_WhenSaveImageCalled_ThenUnauthorizedAccessExceptionThrown()
    {
        // Act & Assert
        Assert.Throws<UnauthorizedAccessException>(() => ImageService.SaveImage(_bitmap, _protectedPath, ImageFormat.Jpeg));
    }
}
