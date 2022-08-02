using Base64EncodingAndDecoding;
using System;
using Xunit;

namespace Tests;

public class Tests
{
    private Base64Operations _base64Operations = new Base64Operations();
    private string _shortString = "To what length can the human lifespan be extended?";
    private string _longString = "The great crocodile of Queensland has been known to attain a length of 30 ft.; there is a smaller one about 6 ft.";

    [Fact]
    public void GivenAText_WhenEncoding_ThenReturnStringOutput()
    {
        var base64String = _base64Operations.Base64Encoding(_shortString);
        var decodedString = _base64Operations.Base64Decoding(base64String);

        Assert.Equal(decodedString, _shortString);
    }

    [Fact]
    public void GivenAText_WhenEncodingWithOffset_ThenReturnStringOutput()
    {
        var base64String = _base64Operations.Base64Encoding(_shortString, 2, 9);
        var decodedString = _base64Operations.Base64Decoding(base64String);

        Assert.Equal(decodedString, _shortString.Substring(2, 9));
    }

    [Fact]
    public void GivenATextLessThan76Length_WhenEncodingWithLineBreaks_ThenReturnStringOutput()
    {
        var base64String = _base64Operations.Base64Encoding("Test", true);

        Assert.Equal(base64String, _base64Operations.Base64Encoding("Test"));
        Assert.DoesNotContain(Environment.NewLine, base64String);
    }

    [Fact]
    public void GivenATextWithMoreThan76Length_WhenEncodingWithLineBreaks_ThenReturnStringOutput()
    {
        var base64String = _base64Operations.Base64Encoding(_longString, true);

        Assert.NotEqual(base64String, _base64Operations.Base64Encoding(_longString));
        Assert.Contains(Environment.NewLine, base64String);
    }
}