using System.Diagnostics;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Xunit;

namespace Tests;
public static class TestHelpers
{
    public const int _expectedMaxElapsedMilliseconds = 1000;
    public const string _jsonMediaType = "application/json";
    public static readonly JsonSerializerOptions _jsonSerializerOptions = new() { PropertyNameCaseInsensitive = true };
    public static async Task AssertResponseWithContentAsync<T>(Stopwatch stopwatch,
        HttpResponseMessage response, System.Net.HttpStatusCode expectedStatusCode,
        T expectedContent)
    {
        AssertCommonResponseParts(stopwatch, response, expectedStatusCode);
        Assert.Equal(_jsonMediaType, response.Content.Headers.ContentType?.MediaType);
        Assert.Equal(expectedContent, await JsonSerializer.DeserializeAsync<T?>(
            await response.Content.ReadAsStreamAsync(), _jsonSerializerOptions));
    }

    public static void AssertCommonResponseParts(Stopwatch stopwatch,
        HttpResponseMessage response, System.Net.HttpStatusCode expectedStatusCode)
    {
        Assert.Equal(expectedStatusCode, response.StatusCode);
        Assert.True(stopwatch.ElapsedMilliseconds < _expectedMaxElapsedMilliseconds);
    }

    public static StringContent GetJsonStringContent<T>(T model)
        => new(JsonSerializer.Serialize(model), Encoding.UTF8, _jsonMediaType);
}
