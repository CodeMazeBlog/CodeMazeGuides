using CommunityToolkit.HighPerformance.Buffers;
using UsingSendGridApi.Utils;

namespace UsingSendGridUnitTests;

public sealed class UsingSendGridUtilitiesTests : IClassFixture<SendGridUnitTestFixture>
{
    private readonly SendGridUnitTestFixture _fixture;
    public UsingSendGridUtilitiesTests(SendGridUnitTestFixture fixture) => _fixture = fixture;

    [Theory]
    [InlineData(64)]
    [InlineData(8192)]
    [InlineData(8193)]
    [InlineData(81920)]
    public async Task WhenWritingRandomDataToFile_ResultIsCorrectFileSize(int bytesToWrite)
    {
        var tempFile = _fixture.GetTempFileName();
        await Utilities.FillFileWithRandomDataOfSpecifiedLength(tempFile, bytesToWrite);
        var fi = new FileInfo(tempFile);

        Assert.Equal(bytesToWrite, fi.Length);
    }

    [Fact]
    public async Task WhenGettingAttachmentAsBase64_ResultIsExpectedData()
    {
        var buffer = MemoryOwner<byte>.Allocate(1024);
        Random.Shared.NextBytes(buffer.Span);
        var expected = Convert.ToBase64String(buffer.Span);

        var tempFile = _fixture.GetTempFileName();
        await using (var fs = File.Create(tempFile))
        {
            await fs.WriteAsync(buffer.Memory);
        }

        var result = await Utilities.GetAttachmentContentsAsBase64(tempFile);

        Assert.Equal(expected, result);
    }

    [Fact]
    public async Task WhenAttachmentNotFound_GettingAttachmentAsBase64_ThrowsFileNotFoundException()
    {
        var tempFile = _fixture.GetTempFileName();

        Assert.False(File.Exists(tempFile));
        await Assert.ThrowsAsync<FileNotFoundException>(() => Utilities.GetAttachmentContentsAsBase64(tempFile));
    }

    [Fact]
    public async Task WhenAttachmentTooLarge_GettingAttachmentAsBase64_ThrowsArgumentException()
    {
        var tempFile = _fixture.GetTempFileName();
        await Utilities.FillFileWithRandomDataOfSpecifiedLength(tempFile, (int) Utilities.MaxAttachmentSize + 128);

        await Assert.ThrowsAsync<ArgumentException>(() => Utilities.GetAttachmentContentsAsBase64(tempFile));
    }
}