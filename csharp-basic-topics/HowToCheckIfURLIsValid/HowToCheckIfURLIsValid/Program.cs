using HowToCheckIfURLIsValid;

{
    var url = "https://www.amazon.com";
    var success = UrlValidator.ValidateUrlWithRegex(url);

    Console.WriteLine($"The URL '{url}' is {(success ? "valid" : "invalid")}.");

    var url2 = "ftp:////example.com///one?param=true";
    success = UrlValidator.ValidateUrlWithRegex(url2);

    Console.WriteLine($"The URL '{url2}' is {(success ? "valid" : "invalid")}.");
}

{
    var url = "https://api.facebook.com:443";
    var success = UrlValidator.ValidateUrlWithUriCreate(url, out _);

    Console.WriteLine($"The URL '{url}' is {(success ? "valid" : "invalid")}.");

    var url2 = "ftp:///api.site.com?value=word1 word2";
    success = UrlValidator.ValidateUrlWithUriCreate(url2, out _);

    Console.WriteLine($"The URL '{url2}' is {(success ? "valid" : "invalid")}.");
}

{
    var url = "https://site.company?q=search";
    var success = UrlValidator.ValidateUrlWithUriWellFormedString(url);

    Console.WriteLine($"The URL '{url}' is {(success ? "valid" : "invalid")}.");

    var url2 = "ftp://api.site.com?value=word1 word2";
    success = UrlValidator.ValidateUrlWithUriWellFormedString(url2);

    Console.WriteLine($"The URL '{url2}' is {(success ? "valid" : "invalid")}.");
}
{
    var url = "https://api.facebook.com";
    var success = await UrlValidator.ValidateUrlWithHttpClient(url);

    Console.WriteLine($"The URL '{url}' is {(success ? "valid" : "invalid")}.");
    
    var url3 = "https://123api.facebook.com";
    var url2 = "https://www.example-nonexistent-url.com";
    success = await UrlValidator.ValidateUrlWithHttpClient(url3);

    Console.WriteLine($"The URL '{url3}' is {(success ? "valid" : "invalid")}.");
}