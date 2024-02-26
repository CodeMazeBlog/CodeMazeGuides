using SkiaSharp;
using SkiaSharpLibrary;

namespace Tests;

public class SkiaSharpLibraryUnitTest : IDisposable
{
    private SKBitmap _bitmap;
    private readonly int _width = 400;
    private readonly int _height = 300;
    private const string _validOutputPath = @"..\..\..\Image\outputImage.png";
    private const string _invalidOutputPath = @"Z:\Invalid\Path\outputImage.png";
    private const string _pathWithNoWritePermission = @"C:\Windows\System32\outputImage.png";
    private const string _nullOutputPath = "";

    public SkiaSharpLibraryUnitTest()
    {
        _bitmap = ImageService.CreateBlankImage(_width, _height);
    }

    [Fact]
    public void GivenValidDimensions_WhenCreateBlankImageIsCalled_ThenReturnBitmapWithCorrectDimensions()
    {
        // Assert
        Assert.NotNull(_bitmap);
        Assert.Equal(_width, _bitmap.Width);
        Assert.Equal(_height, _bitmap.Height);
    }

    [Theory]
    [InlineData(-1, 300)]
    [InlineData(400, -1)]
    [InlineData(-1, -1)]
    public void GivenInvalidDimensions_WhenCreateBlankImageIsCalled_ThenThrowArgumentException(int width, int height)
    {

        // Act & Assert
        Assert.Throws<Exception>(() => ImageService.CreateBlankImage(width, height));
    }

    [Fact]
    public void GivenValidSquareDetails_WhenDrawSquareOnImageIsCalled_ThenSquareIsDrawn()
    {
        // Arrange
        var (Size, StartX, StartY) = GetSquareDetails(120);

        // Act
        ImageService.DrawSquareOnImage(_bitmap, Size, StartX, StartY);

        // Assert
        Assert.Contains(_bitmap.Pixels, pixel => pixel != SKColors.White);
    }

    [Fact]
    public void GivenInvalidSquareSize_WhenDrawSquareOnImageIsCalled_ThenThrowArgumentException()
    {
        // Arrange
        var (Size, StartX, StartY) = GetSquareDetails(-120);

        // Act & Assert
        Assert.Throws<ArgumentException>(() => ImageService.DrawSquareOnImage(_bitmap, Size, StartX, StartY));
    }

    [Fact]
    public void GivenValidPath_WhenSaveImageIsCalled_ThenImageIsSavedToCorrectPath()
    {
        // Act
        ImageService.SaveImage(_bitmap, _validOutputPath);

        // Assert
        Assert.True(File.Exists(_validOutputPath));
    }

    [Fact]
    public void GivenInvalidPath_WhenSaveImageIsCalled_ThenThrowDirectoryNotFoundException()
    {
        // Act & Assert
        Assert.Throws<DirectoryNotFoundException>(() => ImageService.SaveImage(_bitmap, _invalidOutputPath));
    }

    [Fact]
    public void GivenPathWithNoWritePermission_WhenSaveImageIsCalled_ThenThrowUnauthorizedAccessException()
    {
        // Act & Assert
        Assert.Throws<UnauthorizedAccessException>(() => ImageService.SaveImage(_bitmap, _pathWithNoWritePermission));
    }

    [Fact]
    public void GivenNullPath_WhenSavingImage_ThenThrowsArgumentNullException()
    {
        var image = ImageService.CreateBlankImage(_width, _height);
        Assert.Throws<ArgumentNullException>(() => ImageService.SaveImage(image, _nullOutputPath));
    }

    public void Dispose()
    {
        if (File.Exists(_validOutputPath))
        {
            File.Delete(_validOutputPath);
        }

        _bitmap?.Dispose();
    }

    private (int Size, int StartX, int StartY) GetSquareDetails(int squareSize)
    {
        int startX = (_bitmap.Width - squareSize) / 2;
        int startY = (_bitmap.Height - squareSize) / 2;

        return (squareSize, startX, startY);
    }
}