using HowToCheckIfURLIsValid;

namespace Tests;

public class HowToCheckIfURLIsValidUnitTests
{
    [Fact]
    public void GivenACorrectUrl_WhenValidatedWithRegex_ThenItShouldBeValid()
    {
        var url = "https://www.amazon.com";
        var urlTwo = "https://api.example.org/v1/data";

        Assert.True(UrlValidator.ValidateUrlWithRegex(url));
        Assert.True(UrlValidator.ValidateUrlWithRegex(urlTwo));
    }

    [Fact]
    public void GivenAnIncorrectUrl_WhenValidatedWithRegex_ThenItShouldBeInvalid()
    {
        List<string> urls =
        [
            "http:/www.amazon.com",
            "https://site.company///",
            "xxx://org.company.com"
        ];
        
        foreach (var url in urls)
        {
            Assert.False(UrlValidator.ValidateUrlWithRegex(url));
        }
    }

    [Fact]
    public void GivenACorrectUrl_WhenValidatedWithUriTryCreate_ThenItShouldBeValid()
    {
        var url = "https://api.facebook.com:443";
        
        Assert.True(UrlValidator.ValidateUrlWithUriCreate(url, out var uri));
        
        var url2 = "ftps://user:password@secure.example.org/files";
        
        Assert.True(UrlValidator.ValidateUrlWithUriCreate(url2, out uri));
        
        var url3 = "file:///C:/Users/username/Documents/file.txt";
        
        Assert.True(UrlValidator.ValidateUrlWithUriCreate(url3, out uri));
        
        List<string> urls = [url, url2, url3];
        
        Assert.True(urls.All(x => Uri.IsWellFormedUriString(x, UriKind.RelativeOrAbsolute)));
    }

    [Fact]
    public void GivenAnIncorrectUrl_WhenValidatedWithUriTryCreate_ThenItShouldBeInvalid()
    {
        List<string> urls =
        [
            "https:/www.twitter.com",
            "https://site.company?q=search",
            "http://api.facebook.com",
            "ftp://api.site.com?value=word1 word2"
        ];
        
        Assert.False(UrlValidator.ValidateUrlWithUriWellFormedString(urls[0]));
        
        Assert.True(UrlValidator.ValidateUrlWithUriWellFormedString(urls[1]));
        
        Assert.True(UrlValidator.ValidateUrlWithUriWellFormedString(urls[2]));
        
        Assert.False(UrlValidator.ValidateUrlWithUriWellFormedString(urls[3]));
    }

    [Fact]
    public async Task GivenACorrectUrl_WhenValidatedWithUriHttpRequest_ThenItShouldBeValid()
    {
        var url = "https://api.facebook.com";
        
        Assert.True(await UrlValidator.ValidateUrlWithHttpClient(url));
    }

    [Fact]
    public async Task GivenAnIncorrectUrl_WhenValidatedWithUriHttpRequest_ThenItShouldBeInvalid()
    {
        var url = "https://www.example-nonexistent-url.com";
        
        Assert.False(await UrlValidator.ValidateUrlWithHttpClient(url));
    }
}