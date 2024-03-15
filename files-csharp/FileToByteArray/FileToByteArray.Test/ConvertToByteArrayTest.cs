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
    public async void GivenSmallFile_WhenCallingConvertInChunksMemoryMapped_ThenReturnsCorrectContent()
    {
        using var md5Hasher = MD5.Create();
        await foreach (var chunk in ToByteArrayMethods.ConvertInChunksMemoryMapped(fixture.SmallTestFile,
            ToByteArrayMethods.DefaultBufferSize))
        {
            md5Hasher.TransformBlock(chunk, 0, chunk.Length, null, 0);
        }

        md5Hasher.TransformFinalBlock([], 0, 0);
        var hash = md5Hasher.Hash;

        hash.Should().BeEquivalentTo(fixture.SmallTestFileHash);
    }

    [Fact]
    public async void GivenLargeFile_WhenCallingConvertInChunksMemoryMapped_ThenReturnsCorrectContent()
    {
        using var md5Hasher = MD5.Create();
        await foreach (var chunk in ToByteArrayMethods.ConvertInChunksMemoryMapped(fixture.LargeTestFile,
            ToByteArrayMethods.DefaultBufferSize))
        {
            md5Hasher.TransformBlock(chunk, 0, chunk.Length, null, 0);
        }

        md5Hasher.TransformFinalBlock([], 0, 0);
        var hash = md5Hasher.Hash;

        hash.Should().BeEquivalentTo(fixture.LargeTestFileHash);
    }

    [Fact]
    public async void GivenFile_WhenCallingConvertInChunksMemoryMappedWithGreaterThanMaxArrayChunkSize_ThenThrowsArgumentException()
    {
        var func = async () =>
        {
            using var md5Hasher = MD5.Create();
            await foreach (var chunk in ToByteArrayMethods.ConvertInChunksMemoryMapped(fixture.SmallTestFile,
                Array.MaxLength + 1))
            {
                md5Hasher.TransformBlock(chunk, 0, chunk.Length, null, 0);
            }

            md5Hasher.TransformFinalBlock([], 0, 0);

            return md5Hasher.Hash;
        };

        await func.Should().ThrowAsync<ArgumentOutOfRangeException>();
    }

    [Fact]
    public async void GivenSmallFile_WhenCallingConvertInChunksFileStream_ThenReturnsCorrectContent()
    {
        using var md5Hasher = MD5.Create();
        await foreach (var chunk in ToByteArrayMethods.ConvertInChunksFileStream(fixture.SmallTestFile,
            ToByteArrayMethods.DefaultBufferSize))
        {
            md5Hasher.TransformBlock(chunk, 0, chunk.Length, null, 0);
        }

        md5Hasher.TransformFinalBlock([], 0, 0);
        var hash = md5Hasher.Hash;

        hash.Should().BeEquivalentTo(fixture.SmallTestFileHash);
    }

    [Fact]
    public async void GivenLargeFile_WhenCallingConvertInChunksFileStream_ThenReturnsCorrectContent()
    {
        using var md5Hasher = MD5.Create();
        await foreach (var chunk in ToByteArrayMethods.ConvertInChunksFileStream(fixture.LargeTestFile,
            ToByteArrayMethods.DefaultBufferSize))
        {
            md5Hasher.TransformBlock(chunk, 0, chunk.Length, null, 0);
        }

        md5Hasher.TransformFinalBlock([], 0, 0);
        var hash = md5Hasher.Hash;

        hash.Should().BeEquivalentTo(fixture.LargeTestFileHash);
    }

    [Fact]
    public async void GivenFile_WhenCallingConvertInChunksFileStreamWithGreaterThanMaxArrayChunkSize_ThenThrowsArgumentException()
    {
        var func = async () =>
        {
            using var md5Hasher = MD5.Create();
            await foreach (var chunk in ToByteArrayMethods.ConvertInChunksFileStream(fixture.SmallTestFile,
                Array.MaxLength + 1))
            {
                md5Hasher.TransformBlock(chunk, 0, chunk.Length, null, 0);
            }

            md5Hasher.TransformFinalBlock([], 0, 0);

            return md5Hasher.Hash;
        };

        await func.Should().ThrowAsync<ArgumentOutOfRangeException>();
    }
}