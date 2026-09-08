using System.Text.Json;
using JsonSerializer = System.Text.Json.JsonSerializer;
using Microsoft.CSharp.RuntimeBinder;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Xunit;

namespace JsonDeserializationDynamicObject.Tests;

public class ReturnTypeTests
{
    private const string JsonObjectPayload = @"{ ""Genre"": ""Thriller"" }";
    private const string JsonArrayPayload = "[ 1, 2, 3 ]";
    private const string JsonStringPayload = @"""Thriller""";
    private const string JsonNumberPayload = "8.1";
    private const string JsonBooleanPayload = "true";
    private const string JsonNullPayload = "null";

    [Fact]
    public void GivenJsonObject_WhenDeserializingToDynamic_ThenWeGetJObject()
    {
        object result = JsonConvert.DeserializeObject<dynamic>(JsonObjectPayload)!;

        Assert.IsType<JObject>(result);
    }

    [Fact]
    public void GivenJsonArray_WhenDeserializingToDynamic_ThenWeGetJArray()
    {
        object result = JsonConvert.DeserializeObject<dynamic>(JsonArrayPayload)!;

        Assert.IsType<JArray>(result);
    }

    [Fact]
    public void GivenJsonString_WhenDeserializingToDynamic_ThenWeGetString()
    {
        object result = JsonConvert.DeserializeObject<dynamic>(JsonStringPayload)!;

        Assert.IsType<string>(result);
        Assert.Equal("Thriller", result);
    }

    [Fact]
    public void GivenJsonNumber_WhenDeserializingToDynamic_ThenWeGetDouble()
    {
        object result = JsonConvert.DeserializeObject<dynamic>(JsonNumberPayload)!;

        Assert.IsType<double>(result);
        Assert.Equal(8.1d, result);
    }

    [Fact]
    public void GivenJsonBoolean_WhenDeserializingToDynamic_ThenWeGetBool()
    {
        object result = JsonConvert.DeserializeObject<dynamic>(JsonBooleanPayload)!;

        Assert.IsType<bool>(result);
        Assert.Equal(true, result);
    }

    [Fact]
    public void GivenJsonNull_WhenDeserializingToDynamic_ThenWeGetNullReference()
    {
        object? result = JsonConvert.DeserializeObject<dynamic>(JsonNullPayload);

        Assert.Null(result);
    }

    [Theory]
    [InlineData(JsonStringPayload, JTokenType.String)]
    [InlineData(JsonNumberPayload, JTokenType.Float)]
    [InlineData(JsonBooleanPayload, JTokenType.Boolean)]
    [InlineData(JsonNullPayload, JTokenType.Null)]
    public void GivenJsonScalar_WhenDeserializingToJToken_ThenWeGetJValueOfExpectedType(string payload, JTokenType expected)
    {
        var result = JsonConvert.DeserializeObject<JToken>(payload)!;

        var value = Assert.IsType<JValue>(result);
        Assert.Equal(expected, value.Type);
    }

    [Fact]
    public void GivenJsonObject_WhenDeserializingToJToken_ThenWeGetJObject()
    {
        var result = JsonConvert.DeserializeObject<JToken>(JsonObjectPayload)!;

        Assert.IsType<JObject>(result);
    }

    [Fact]
    public void GivenJsonArray_WhenDeserializingToJToken_ThenWeGetJArray()
    {
        var result = JsonConvert.DeserializeObject<JToken>(JsonArrayPayload)!;

        Assert.IsType<JArray>(result);
    }

    [Theory]
    [InlineData(JsonObjectPayload, JsonValueKind.Object)]
    [InlineData(JsonArrayPayload, JsonValueKind.Array)]
    [InlineData(JsonStringPayload, JsonValueKind.String)]
    [InlineData(JsonNumberPayload, JsonValueKind.Number)]
    [InlineData(JsonBooleanPayload, JsonValueKind.True)]
    public void GivenJsonPayload_WhenDeserializingToDynamicWithSystemTextJson_ThenWeGetJsonElementOfExpectedKind(string payload, JsonValueKind expected)
    {
        object result = JsonSerializer.Deserialize<dynamic>(payload)!;

        var element = Assert.IsType<JsonElement>(result);
        Assert.Equal(expected, element.ValueKind);
    }

    [Fact]
    public void GivenJsonNull_WhenDeserializingToDynamicWithSystemTextJson_ThenWeGetNullReference()
    {
        object? result = JsonSerializer.Deserialize<dynamic>(JsonNullPayload);

        Assert.Null(result);
    }

    [Fact]
    public void GivenJsonElement_WhenAccessingMemberByName_ThenRuntimeBinderExceptionIsThrown()
    {
        dynamic result = JsonSerializer.Deserialize<dynamic>(JsonObjectPayload)!;

        Assert.Throws<RuntimeBinderException>(() => result.Genre);
    }

    [Fact]
    public void GivenJObject_WhenAccessingMemberByName_ThenValueIsResolvedAtRuntime()
    {
        dynamic result = JsonConvert.DeserializeObject<dynamic>(JsonObjectPayload)!;

        Assert.Equal("Thriller", (string)result.Genre);
    }
}
