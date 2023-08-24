using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using Xunit;

namespace JsonSerializeExceptions.Tests;

public class NewtonsoftJsonSerializeExceptionsUnitTest
{
    [Fact]
    public void GivenAnException_WhenSerializedByJsonConvert_ThenSucceed()
    {
        try
        {
            throw new InvalidOperationException("Bad operation");
        }
        catch (Exception ex)
        {
            var json = JsonConvert.SerializeObject(ex)!;

            Assert.NotEmpty(json);
        }
    }

    [Fact]
    public void GivenACustomException_WhenSerializedByJsonConvert_ThenSerializeWithAdditionalProperties()
    {
        try
        {
            throw new CustomException("Custom error", "Try later");
        }
        catch (CustomException ex)
        {
            var json = JsonConvert.SerializeObject(ex)!;

            Assert.Contains("Mitigation", json);
        }
    }


    [Fact]
    public void GivenACustomException_WhenDecoratedWithSerializable_ThenRetainsBasicSerializationBehavior()
    {
        try
        {
            throw new CustomVerboseException("Custom error", "Try later");
        }
        catch (Exception ex)
        {
            var json = JsonConvert.SerializeObject(ex)!;

            var jObject = JObject.Parse(json);

            Assert.Equal(typeof(CustomVerboseException).FullName, jObject["ClassName"]);
        }
    }
}