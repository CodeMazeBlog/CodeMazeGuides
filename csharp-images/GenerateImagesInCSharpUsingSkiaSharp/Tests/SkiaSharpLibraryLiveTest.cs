using SkiaSharp;
using SkiaSharpLibrary;

namespace Tests;

public class SkiaSharpLibraryLiveTest : IDisposable
{
    private const string OutputPath = @"outputImage.png";
    private const string NullOutputPath = "";
    private readonly int _width = 400;
    private readonly int _height = 300;
    private SKBitmap _bitmap;
    private bool _isDisposed = false;


    public SkiaSharpLibraryLiveTest()
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
        ImageService.SaveImage(_bitmap, OutputPath);

        // Assert
        Assert.True(File.Exists(OutputPath));

        // Cleanup
        File.Delete(OutputPath);
    }

    [Fact]
    public void GivenNullPath_WhenSavingImage_ThenThrowArgumentException()
    {
        // Arrange
        var image = ImageService.CreateBlankImage(_width, _height);

        // Act & Assert
        Assert.Throws<ArgumentException>(() => ImageService.SaveImage(image, NullOutputPath));
    }

    private (int Size, int StartX, int StartY) GetSquareDetails(int squareSize)
    {
        int startX = (_bitmap.Width - squareSize) / 2;
        int startY = (_bitmap.Height - squareSize) / 2;

        return (squareSize, startX, startY);
    }

    public void Dispose()
    {
        lock (this)
        {
            if (_isDisposed) return;
            _bitmap?.Dispose();
            _bitmap = null!;
            _isDisposed = true;
        }
        GC.SuppressFinalize(this);
    }
}