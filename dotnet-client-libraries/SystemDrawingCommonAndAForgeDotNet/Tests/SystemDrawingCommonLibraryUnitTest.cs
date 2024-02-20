using SystemDrawingCommonLibrary;

namespace Tests;

public class SystemDrawingCommonUnitTest
{
    private const string _outputPath = @"..\..\..\Image\outputImage.png";
    private const string _nullOutputPath = "";
    private const string _protectedPath = @"C:\Windows\System32\outputImage.png";
    private readonly Bitmap _bitmap;
    private readonly Size _imageSize = new(400, 200);
    private readonly Rectangle _rect = new(50, 50, 100, 200);
    private readonly Brush _color = Brushes.Green;

    public SystemDrawingCommonUnitTest()
    {
        _bitmap = ImageService.CreateBlankImage(_imageSize);
    }

    [Fact]
    public void GivenValidSize_WhenCreateBlankImage_ThenReturnBitmap()
    {
        // Arrange
        var expectedBitmap = new Bitmap(_imageSize.Width, _imageSize.Height);

        // Act
        var actualBitmap = ImageService.CreateBlankImage(_imageSize);

        // Assert
        Assert.Equal(expectedBitmap.Size, actualBitmap.Size);
    }

    [Fact]
    public void GivenValidParameters_WhenDrawRectangleOnImage_ThenRectangleIsDrawn()
    {
        // Arrange
        var expectedColor = Color.FromArgb(255, 0, 128, 0);

        // Act
        ImageService.DrawRectangleOnImage(_bitmap, _rect, (SolidBrush)_color);

        // Assert
        var clampedRect = Rectangle.Intersect(_rect, new Rectangle(0, 0, _imageSize.Width, _imageSize.Height));
        for (int x = clampedRect.Left; x < clampedRect.Right; x++)
        {
            for (int y = clampedRect.Top; y < clampedRect.Bottom; y++)
            {
                var actualColor = _bitmap.GetPixel(x, y);
                Assert.Equal(expectedColor, actualColor);
            }
        }
    }

    [Fact]
    public void GivenBitmapAndPath_WhenSaveImage_ThenImageSavedSuccessfully()
    {
        // Arrange
        ImageService.DrawRectangleOnImage(_bitmap, _rect, _color);

        // Act
        ImageService.SaveImage(_bitmap, _outputPath, ImageFormat.Png);

        // Assert
        Assert.True(File.Exists(_outputPath));
    }

    [Theory]
    [InlineData(-1, 200)]
    [InlineData(400, -1)]
    [InlineData(0, 200)]
    [InlineData(400, 0)]
    public void GivenInvalidSize_WhenCreateBlankImage_ThenThrowArgumentException(int width, int height)
    {
        // Arrange
        var invalidSize = new Size(width, height);

        // Act & Assert
        Assert.Throws<ArgumentException>(() => ImageService.CreateBlankImage(invalidSize));
    }

    [Fact]
    public void GivenPathWithNoWritePermission_WhenSaveImage_ThenThrowUnauthorizedAccessException()
    {
        // Arrange
        ImageService.DrawRectangleOnImage(_bitmap, _rect, _color);

        // Act & Assert
        Assert.Throws<UnauthorizedAccessException>(() => ImageService.SaveImage(_bitmap, _protectedPath, ImageFormat.Png));
    }

    [Theory]
    [InlineData(-1, 200)]
    [InlineData(200, -1)]
    [InlineData(0, 200)]
    [InlineData(200, 0)]
    public void GivenInvalidRectangle_WhenDrawRectangleOnImage_ThenThrowArgumentException(int width, int height)
    {
        // Arrange
        var invalidRect = new Rectangle(50, 50, width, height);

        // Act & Assert
        Assert.Throws<ArgumentException>(() => ImageService.DrawRectangleOnImage(_bitmap, invalidRect, _color));
    }

    [Fact]
    public void GivenNullPath_WhenSaveImage_ThenThrowException()
    {
        // Act & Assert
        Assert.Throws<ArgumentNullException>(() => ImageService.SaveImage(_bitmap, _nullOutputPath, ImageFormat.Png));
    }
}