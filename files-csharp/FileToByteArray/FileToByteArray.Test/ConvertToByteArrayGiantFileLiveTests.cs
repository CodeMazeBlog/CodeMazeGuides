namespace FileToByteArray.Test;

// Note: Running these tests will generate a temporary file of size ~ 2 GB
// The file will be cleaned up after the tests run
public class ConvertToByteArrayGiantFileLiveTests(LiveTestGiantFileFixture fixture)
    : IClassFixture<LiveTestGiantFileFixture>
{
    [Fact]
    public void GivenGiantFileWithLengthExceedingMaxArray_WhenConvertingUsingReadAllBytes_ThenThrowsIOException()
    {
        var action = () => _ = File.ReadAllBytes(fixture.GiantTestFile);

        action.Should().Throw<IOException>();
    }

    [Fact]
    public async void
        GivenGiantFileWithLengthExceedingMaxArray_WhenConvertingUsingReadAllBytesAsync_ThenThrowsIOException()
    {
        var func = async () => _ = await File.ReadAllBytesAsync(fixture.GiantTestFile);

        await func.Should().ThrowAsync<IOException>();
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

        await func.Should().
            ThrowAsync<Exception>().Where(ex =>
                ex.GetType() == typeof(OutOfMemoryException) ||
                ex.GetType() == typeof(IOException)
            );
    }

    [Fact]
    public void
        GivenGiantFileWithLengthExceedingMaxArray_WhenConvertUsingPooledWriter_ThenThrowsArgumentOutOfRangeException()
    {
        var action = () => { _ = ToByteArrayMethods.ConvertUsingPooledWriter(fixture.GiantTestFile); };

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
        GivenGiantFileWithLengthExceedingMaxArray_WhenConvertUsingMemoryStream_ThenThrowsException()
    {
        var action = () => { _ = ToByteArrayMethods.ConvertUsingMemoryStream(fixture.GiantTestFile); };

        action.Should().
            Throw<Exception>().Where(ex =>
                ex.GetType() == typeof(OutOfMemoryException) ||
                ex.GetType() == typeof(IOException)
            );
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
    public async void GivenGiantFile_WhenCallingConvertInChunks_ThenReturnsCorrectContent()
    {
        using var md5Hasher = MD5.Create();
        await foreach (var chunk in ToByteArrayMethods.ConvertInChunks(fixture.GiantTestFile,
                           ToByteArrayMethods.DefaultBufferSize))
        {
            md5Hasher.TransformBlock(chunk, 0,
                chunk.Length, null, 0);
        }

        md5Hasher.TransformFinalBlock([], 0, 0);
        var hash = md5Hasher.Hash;

        hash.Should().BeEquivalentTo(fixture.GiantTestFileHash);
    }
}