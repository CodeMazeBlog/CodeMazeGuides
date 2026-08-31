using Base64EncodingAndDecoding;
using System;
using System.Buffers.Text;
using System.IO;
using System.Text;
using Xunit;

namespace Tests;

public class Tests
{
    private Base64Operations _base64Operations = new Base64Operations();
    private string _shortString = "To what length can the human lifespan be extended?";
    private string _longString = "The great crocodile of Queensland has been known to attain a length of 30 ft.; there is a smaller one about 6 ft.";

    [Fact]
    public void GivenAText_WhenEncoding_ThenReturnStringOutput()
    {
        var base64String = _base64Operations.Base64Encoding(_shortString);
        var decodedString = _base64Operations.Base64Decoding(base64String);

        Assert.Equal(_shortString, decodedString);
    }

    [Fact]
    public void GivenAText_WhenEncodingWithOffset_ThenReturnStringOutput()
    {
        var base64String = _base64Operations.Base64Encoding(_shortString, 2, 9);
        var decodedString = _base64Operations.Base64Decoding(base64String);

        Assert.Equal(_shortString.Substring(2, 9), decodedString);
    }

    [Fact]
    public void GivenATextLessThan76Length_WhenEncodingWithLineBreaks_ThenReturnStringOutput()
    {
        var base64String = _base64Operations.Base64Encoding("Test", true);

        Assert.Equal(_base64Operations.Base64Encoding("Test"), base64String);
        Assert.DoesNotContain(Environment.NewLine, base64String);
    }

    [Fact]
    public void GivenATextWithMoreThan76Length_WhenEncodingWithLineBreaks_ThenReturnStringOutput()
    {
        var base64String = _base64Operations.Base64Encoding(_longString, true);

        Assert.NotEqual(_base64Operations.Base64Encoding(_longString), base64String);
        Assert.Contains(Environment.NewLine, base64String);
    }

    [Fact]
    public void GivenTextEncodedAsUtf8_WhenDecodedAsUtf16_ThenReturnsMangledTextWithoutThrowing()
    {
        var utf8Bytes = Encoding.UTF8.GetBytes("Hello world!");

        var mangled = Encoding.Unicode.GetString(utf8Bytes);

        Assert.NotEqual("Hello world!", mangled);
        Assert.Equal(6, mangled.Length);
        Assert.DoesNotContain('\uFFFD', mangled);
    }

    [Fact]
    public void GivenAFile_WhenEncodingAndDecodingBack_ThenFileContentSurvives()
    {
        var sourcePath = Path.GetTempFileName();
        var targetPath = Path.GetTempFileName();

        try
        {
            var content = new byte[] { 0x25, 0x50, 0x44, 0x46, 0x2D, 0x31, 0x2E, 0x37, 0x0A, 0xFF, 0x00, 0x80 };
            File.WriteAllBytes(sourcePath, content);

            var base64String = _base64Operations.EncodeFile(sourcePath);
            _base64Operations.DecodeToFile(base64String, targetPath);

            Assert.Equal(Convert.ToBase64String(content), base64String);
            Assert.Equal(content, File.ReadAllBytes(targetPath));
        }
        finally
        {
            File.Delete(sourcePath);
            File.Delete(targetPath);
        }
    }

    [Fact]
    public void GivenAStream_WhenEncoding_ThenOutputMatchesConvertToBase64String()
    {
        var content = Encoding.UTF8.GetBytes(_longString);

        using var input = new MemoryStream(content);
        using var output = new MemoryStream();

        _base64Operations.EncodeStream(input, output);

        Assert.Equal(Convert.ToBase64String(content), Encoding.ASCII.GetString(output.ToArray()));
    }

    [Fact]
    public void GivenABase64Stream_WhenDecoding_ThenOriginalBytesComeBack()
    {
        var content = Encoding.UTF8.GetBytes(_longString);
        var base64Bytes = Encoding.ASCII.GetBytes(Convert.ToBase64String(content));

        using var input = new MemoryStream(base64Bytes);
        using var output = new MemoryStream();

        _base64Operations.DecodeStream(input, output);

        Assert.Equal(content, output.ToArray());
    }

    [Fact]
    public void GivenValidBase64_WhenTryDecoding_ThenReturnsTrueAndTheBytes()
    {
        var base64String = Convert.ToBase64String(Encoding.UTF8.GetBytes(_shortString));

        var succeeded = _base64Operations.TryDecode(base64String, out var bytes);

        Assert.True(succeeded);
        Assert.Equal(_shortString, Encoding.UTF8.GetString(bytes));
    }

    [Fact]
    public void GivenInvalidBase64_WhenTryDecoding_ThenReturnsFalseInsteadOfThrowing()
    {
        var succeeded = _base64Operations.TryDecode("SGVsbG8gd29ybGQ!", out var bytes);

        Assert.False(succeeded);
        Assert.Empty(bytes);
    }

    [Fact]
    public void GivenText_WhenBase64UrlEncoding_ThenRoundTripsAndOmitsPadding()
    {
        var base64UrlString = _base64Operations.Base64UrlEncoding(_shortString);

        Assert.DoesNotContain("=", base64UrlString);
        Assert.Equal(_shortString, _base64Operations.Base64UrlDecoding(base64UrlString));
    }

    [Fact]
    public void GivenBytesThatUsePlusAndSlash_WhenBase64UrlEncoding_ThenTheAlphabetIsSwapped()
    {
        var bytes = new byte[] { 0xFB, 0xFF, 0xFE };

        Assert.Equal("+//+", Convert.ToBase64String(bytes));
        Assert.Equal("-__-", Base64Url.EncodeToString(bytes));
    }
}
