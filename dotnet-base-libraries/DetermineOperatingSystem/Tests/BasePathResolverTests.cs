namespace Tests;

public class BasePathResolverTests
{
    private readonly Mock<IOsPlatformResolver> _platformResolverMock = new ();

    [Fact]
    public void WhenGettingBasePathOnWindowsPlatform_ThenShouldReturnWindowsPath()
    {
        // Arrange
        _platformResolverMock.Setup(m => m.IsWindows()).Returns(true);
        var basePathResolver = new BasePathResolver(_platformResolverMock.Object);

        // Act
        var basePath = basePathResolver.GetBasePath();

        // Assert
        Assert.Equal("C:\\MyApp\\", basePath);
    }

    [Fact]
    public void WhenGettingBasePathOnLinuxPlatform_ThenShouldReturnLinuxPath()
    {
        // Arrange
        _platformResolverMock.Setup(m => m.IsLinux()).Returns(true);
        var basePathResolver = new BasePathResolver(_platformResolverMock.Object);

        // Act
        var basePath = basePathResolver.GetBasePath();

        // Assert
        Assert.Equal("/MyApp/", basePath);
    }

    [Fact]
    public void WhenGettingBasePathOnOsxPlatform_ThenShouldReturnOsxPath()
    {
        // Arrange
        _platformResolverMock.Setup(m => m.IsOsx()).Returns(true);
        var basePathResolver = new BasePathResolver(_platformResolverMock.Object);

        // Act
        var basePath = basePathResolver.GetBasePath();

        // Assert
        Assert.Equal("/MyApp/", basePath);
    }

    [Fact]
    public void WhenGettingBasePathOnFreeBSDPlatform_ThenThrowsNotSupportedException()
    {
        // Arrange
        _platformResolverMock.Setup(m => m.IsFreeBsd()).Returns(true);
        var basePathResolver = new BasePathResolver(_platformResolverMock.Object);

        // Act and Assert
        Assert.Throws<NotSupportedException>(() => basePathResolver.GetBasePath());
    }

    [Fact]
    public void WhenGettingBasePathOnDifferentPlatform_ThenThrowsNotSupportedException()
    {
        // Arrange
        var codeMazeOs = OSPlatform.Create("Code maze OS");
        _platformResolverMock.Setup(m => m.IsPlatform(codeMazeOs)).Returns(true);
        var basePathResolver = new BasePathResolver(_platformResolverMock.Object);

        // Act and Assert
        Assert.Throws<NotSupportedException>(() => basePathResolver.GetBasePath(codeMazeOs));
    }
}