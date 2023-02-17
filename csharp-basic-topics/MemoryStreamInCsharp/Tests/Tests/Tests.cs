using System;
using System.IO;
using Xunit;

namespace Tests;

public class Tests
{
    [Fact]
    public void WhenCreateMemoryStream_ThanCanWrite()
    {
        var memoryStream = new MemoryStream();
        Assert.True(memoryStream.CanWrite);
    }

    [Fact]
    public void WhenWritingToExtendibleMemoryStream_ThenCanWrite()
    {
        var memoryStream = new MemoryStream();
        Assert.True(memoryStream.CanWrite);
        Assert.True(memoryStream.Capacity == 0);

        var addBytes = new byte[20];
        memoryStream.Write(addBytes, 0, addBytes.Length);
        Assert.True(memoryStream.Length == 20);
    }

    [Fact]
    public void WhenWritingOverTheCapacity_ThenFailure()
    {
        var memoryStream = new MemoryStream(new byte[10]);
        Assert.True(memoryStream.CanWrite);
        Assert.True(memoryStream.Capacity == 10);

        var addBytes = new byte[20];
        Assert.Throws<NotSupportedException>(() => memoryStream.Write(addBytes, 0, addBytes.Length));
    }

    [Fact]
    public void WhenWritingWithinTheCapacity_ThenSuccess()
    {
        var memoryStream = new MemoryStream(new byte[10]);
        Assert.True(memoryStream.CanWrite);
        Assert.True(memoryStream.Capacity == 10);

        var addBytes = new byte[5] { 1, 1, 1, 1, 1 };
        memoryStream.Write(addBytes, 0, addBytes.Length);

        Assert.True(memoryStream.Length == 10);
        Assert.True(memoryStream.Capacity == 10);
    }
}