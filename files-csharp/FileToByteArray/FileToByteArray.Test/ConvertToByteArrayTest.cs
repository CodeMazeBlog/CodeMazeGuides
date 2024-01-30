using System.Buffers;
using System.Security.Cryptography;
using FluentAssertions;
using FluentAssertions.Collections;
using Xunit;

namespace FileToByteArray.Test;

public sealed class ConvertToByteArrayTest(TestFilesFixture fixture) : IClassFixture<TestFilesFixture>
{
    [Fact]
    public void GivenFile_WhenConvertingUsingReadAllBytes_ThenReturnsCorrectContent()
    {
        var bytes = File.ReadAllBytes(fixture.SmallTestFile);

        bytes.Should().BeEquivalentTo(fixture.SmallTestFileExpectedBytes);
    }

    [Fact]
    public async void GivenFile_WhenConvertingUsingReadAllBytesAsync_ThenReturnsCorrectContent()
    {
        var bytes = await File.ReadAllBytesAsync(fixture.SmallTestFile);

        bytes.Should().BeEquivalentTo(fixture.SmallTestFileExpectedBytes);
    }

    [Fact]
    public void GivenGiantFileWithLengthExceedingMaxArray_WhenConvertingUsingReadAllBytes_ThenReturnsCorrectContent()
    {
        var action = () => _ = File.ReadAllBytes(fixture.GiantTestFile);

        action.Should().Throw<IOException>();
    }

    [Fact]
    public async void
        GivenGiantFileWithLengthExceedingMaxArray_WhenConvertingUsingReadAllBytesAsync_ThenReturnsCorrectContent()
    {
        var func = async () => _ = await File.ReadAllBytesAsync(fixture.GiantTestFile);

        await func.Should().ThrowAsync<IOException>();
    }

    [Fact]
    public void GivenFile_WhenConvertUsingMemoryStream_ThenReturnsCorrectContent()
    {
        var bytes = ToByteArrayMethods.ConvertUsingMemoryStream(fixture.SmallTestFile);

        bytes.Should().BeEquivalentTo(fixture.SmallTestFileExpectedBytes);
    }

    [Fact]
    public async void GivenFile_WhenConvertUsingMemoryStreamAsync_ThenReturnsCorrectContent()
    {
        var bytes = await ToByteArrayMethods.ConvertUsingMemoryStreamAsync(fixture.SmallTestFile);

        bytes.Should().BeEquivalentTo(fixture.SmallTestFileExpectedBytes);
    }

    [Fact]
    public void GivenLargeFileExceedingBufferSize_WhenConvertUsingMemoryStream_ThenReturnsCorrectContent()
    {
        var bytes = ToByteArrayMethods.ConvertUsingMemoryStream(fixture.LargeTestFile);

        bytes.Should().BeEquivalentTo(fixture.LargeTestFileExpectedBytes);
    }

    [Fact]
    public async void GivenLargeFileExceedingBufferSize_WhenConvertUsingMemoryStreamAsync_ThenReturnsCorrectContent()
    {
        var bytes = await ToByteArrayMethods.ConvertUsingMemoryStreamAsync(fixture.LargeTestFile);

        bytes.Should().BeEquivalentTo(fixture.LargeTestFileExpectedBytes);
    }

    [Fact]
    public void
        GivenGiantFileWithLengthExceedingMaxArray_WhenConvertUsingPooledArray_ThenThrowsArgumentOutOfRangeException()
    {
        var action = () =>
        {
            var (array, _) = ToByteArrayMethods.ConvertToPooledArray(fixture.GiantTestFile);
            ArrayPool<byte>.Shared.Return(array);
        };

        action.Should().Throw<ArgumentOutOfRangeException>();
    }

    [Fact]
    public async void
        GivenGiantFileWithLengthExceedingMaxArray_WhenConvertUsingMemoryStreamAsync_ThenThrowsArgumentOutOfRangeException()
    {
        var func = async () => { _ = await ToByteArrayMethods.ConvertUsingMemoryStreamAsync(fixture.GiantTestFile); };

        await func.Should().ThrowAsync<ArgumentOutOfRangeException>();
    }

    [Fact]
    public void
        GivenGiantFileWithLengthExceedingMaxArray_WhenConvertUsingPooledWriter_ThenThrowsArgumentOutOfRangeException()
    {
        var action = () => { _ = ToByteArrayMethods.ConvertUsingMemoryStream(fixture.GiantTestFile); };

        action.Should().Throw<ArgumentOutOfRangeException>();
    }

    [Fact]
    public async void
        GivenGiantFileWithLengthExceedingMaxArray_WhenConvertUsingPooledWriterAsync_ThenThrowsArgumentOutOfRangeException()
    {
        var func = async () => { _ = await ToByteArrayMethods.ConvertUsingPooledWriterAsync(fixture.GiantTestFile); };

        await func.Should().ThrowAsync<ArgumentOutOfRangeException>();
    }

    [Fact]
    public void
        GivenGiantFileWithLengthExceedingMaxArray_WhenConvertUsingMemoryStream_ThenThrowsArgumentOutOfRangeException()
    {
        var action = () => { _ = ToByteArrayMethods.ConvertUsingPooledWriter(fixture.GiantTestFile); };

        action.Should().Throw<ArgumentOutOfRangeException>();
    }

    [Fact]
    public async void
        GivenGiantFileWithLengthExceedingMaxArray_WhenConvertUsingPooledArrayAsync_ThenThrowsArgumentOutOfRangeException()
    {
        var func = async () =>
        {
            var (array, _) = await ToByteArrayMethods.ConvertToPooledArrayAsync(fixture.GiantTestFile);
            ArrayPool<byte>.Shared.Return(array);
        };

        await func.Should().ThrowAsync<ArgumentOutOfRangeException>();
    }

    [Fact]
    public void
        GivenLargeFileExceedingBufferSize_WhenConvertingUsingPooledArray_ThenReturnsCorrectContent()
    {
        byte[]? rentedArray = null;
        try
        {
            (rentedArray, var length) = ToByteArrayMethods.ConvertToPooledArray(fixture.LargeTestFile);

            rentedArray.AsSpan(0, length).Should().Equal(fixture.LargeTestFileExpectedBytes);
        }
        finally
        {
            if (rentedArray is not null)
            {
                ArrayPool<byte>.Shared.Return(rentedArray);
            }
        }
    }

    [Fact]
    public async void
        GivenLargeFileExceedingBufferSize_WhenConvertingUsingPooledArrayAsync_ThenReturnsCorrectContent()
    {
        byte[]? rentedArray = null;
        try
        {
            (rentedArray, var length) = await ToByteArrayMethods.ConvertToPooledArrayAsync(fixture.LargeTestFile);

            rentedArray.AsSpan(0, length).Should().Equal(fixture.LargeTestFileExpectedBytes);
        }
        finally
        {
            if (rentedArray is not null)
            {
                ArrayPool<byte>.Shared.Return(rentedArray);
            }
        }
    }

    [Fact]
    public void
        GivenLargeFileExceedingBufferSize_WhenConvertingUsingPooledWriter_ThenReturnsCorrectContent()
    {
        var bytes = ToByteArrayMethods.ConvertUsingPooledWriter(fixture.LargeTestFile);

        bytes.Should().Equal(fixture.LargeTestFileExpectedBytes);
    }

    [Fact]
    public async void
        GivenLargeFileExceedingBufferSize_WhenConvertingUsingPooledWriterAsync_ThenReturnsCorrectContent()
    {
        var bytes = await ToByteArrayMethods.ConvertUsingPooledWriterAsync(fixture.LargeTestFile);

        bytes.Should().Equal(fixture.LargeTestFileExpectedBytes);
    }

    [Fact]
    public async void GivenFile_WhenCallingConvertInChunks_ThenReturnsCorrectContent()
    {
        using var md5Hasher = MD5.Create();
        await foreach (var chunk in ToByteArrayMethods.ConvertInChunks(fixture.SmallTestFile,
            ToByteArrayMethods.DefaultBufferSize))
        {
            md5Hasher.TransformBlock(chunk, 0, chunk.Length, null, 0);
        }

        md5Hasher.TransformFinalBlock([], 0, 0);
        var hash = md5Hasher.Hash;

        hash.Should().BeEquivalentTo(fixture.SmallTestFileHash);
    }

    [Fact]
    public async void GivenLargeFile_WhenCallingConvertInChunks_ThenReturnsCorrectContent()
    {
        using var md5Hasher = MD5.Create();
        await foreach (var chunk in ToByteArrayMethods.ConvertInChunks(fixture.LargeTestFile,
            ToByteArrayMethods.DefaultBufferSize))
        {
            md5Hasher.TransformBlock(chunk, 0, chunk.Length, null, 0);
        }

        md5Hasher.TransformFinalBlock([], 0, 0);
        var hash = md5Hasher.Hash;

        hash.Should().BeEquivalentTo(fixture.LargeTestFileHash);
    }

    [Fact]
    public async void GivenGiantFile_WhenCallingConvertInChunks_ThenReturnsCorrectContent()
    {
        using var md5Hasher = MD5.Create();
        await foreach (var chunk in ToByteArrayMethods.ConvertInChunks(fixture.GiantTestFile,
            ToByteArrayMethods.DefaultBufferSize))
        {
            md5Hasher.TransformBlock(chunk, 0, chunk.Length, null, 0);
        }

        md5Hasher.TransformFinalBlock([], 0, 0);
        var hash = md5Hasher.Hash;

        hash.Should().BeEquivalentTo(fixture.GiantTestFileHash);
    }
}

public static class SpanAssertionHelpers
{
    public static GenericCollectionAssertions<T> Should<T>(this Span<T> span) => span.ToArray().Should();
}