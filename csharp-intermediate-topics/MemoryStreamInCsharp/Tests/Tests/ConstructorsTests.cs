using MemoryStreamInCsharp;
using Xunit;

namespace Tests;

public class ConstructorsTests
{
    [Fact]
    public void WhenSimpleConstructor_ThanSuccess()
    {
        var memoryStream = Constructors.SimpleConstructor();

        Assert.True(memoryStream.Length == 0);
        Assert.True(memoryStream.Capacity == 0);
        Assert.True(memoryStream.CanRead);
        Assert.True(memoryStream.CanSeek);
        Assert.True(memoryStream.CanWrite);
        Assert.False(memoryStream.CanTimeout);
        Assert.True(memoryStream.TryGetBuffer(out _));
    }

    [Fact]
    public void WhenByteArrayConstructor_ThenSuccess()
    {
        var memoryStream = Constructors.ByteArrayConstructor(new byte[29]);

        Assert.True(memoryStream.Length == 29);
        Assert.True(memoryStream.Capacity == 29);
        Assert.True(memoryStream.CanRead);
        Assert.True(memoryStream.CanSeek);
        Assert.True(memoryStream.CanWrite);
        Assert.False(memoryStream.CanTimeout);
        Assert.False(memoryStream.TryGetBuffer(out _));
    }

    [Fact]
    public void WhenFullConstructor_ThenSuccess()
    {
        var memoryStream = Constructors.FullConstructor(new byte[29], 19);

        Assert.True(memoryStream.Length == 19);
        Assert.True(memoryStream.Capacity == 19);
        Assert.True(memoryStream.CanRead);
        Assert.True(memoryStream.CanSeek);
        Assert.True(memoryStream.CanWrite);
        Assert.False(memoryStream.CanTimeout);
        Assert.True(memoryStream.TryGetBuffer(out _));
    }
}