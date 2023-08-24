using System.Text.Json;
using System;
using Xunit;

namespace JsonSerializeExceptions.Tests;

public class JsonSerializeExceptionsUnitTest
{
    [Fact]
    public void GivenException_WhenSerializedByJsonSerializer_ThenFails()
    {
        try
        {
            throw new InvalidOperationException("Bad operation");
        }
        catch(Exception ex)
        {
            Assert.ThrowsAny<NotSupportedException>(() => JsonSerializer.Serialize(ex));
        }
    }

    [Fact]
    public void GivenException_WhenSerializedBySimpleExceptionConverter_ThenProvidesBasicDetails()
    {
        try
        {
            var innerException = new InvalidOperationException("Bad operation");

            throw new CustomException("Custom error", "Try later", innerException);
        }
        catch (Exception ex)
        {
            JsonSerializerOptions options = new(JsonSerializerOptions.Default);
            options.Converters.Add(new SimpleExceptionConverter());

            var json = JsonSerializer.Serialize(ex, options);

            Assert.NotEmpty(json);
        }
    }

    [Fact]
    public void GivenException_WhenSerializedByDetailExceptionConverter_ThenProvidesFullDetails()
    {
        try
        {
            var innerException = new InvalidOperationException("Bad operation");

            throw new CustomException("Custom error", "Try later", innerException);
        }
        catch (Exception ex)
        {
            JsonSerializerOptions options = new(JsonSerializerOptions.Default);
            options.Converters.Add(new DetailExceptionConverter());

            var json = JsonSerializer.Serialize(ex, options);

            Assert.NotEmpty(json);
        }
    }

    [Fact]
    public void GivenException_WhenTransformedToAnonymousObject_ThenCanBeSerialized()
    {
        try
        {
            throw new InvalidOperationException("Bad operation");
        }
        catch (Exception ex)
        {
            var interimObject = new
            {
                ex.Message,
                ex.StackTrace,
            };

            var json = JsonSerializer.Serialize(interimObject);

            Assert.NotEmpty(json);
        }
    }

    [Fact]
    public void GivenException_WhenTransformedToWrapperObject_ThenCanBeSerialized()
    {
        try
        {
            var innerException = new InvalidOperationException("Bad operation");

            throw new CustomException("Custom error", "Try later", innerException);
        }
        catch (Exception ex)
        {
            var interimObject = new ExceptionObject(ex);

            var json = JsonSerializer.Serialize(interimObject);

            Assert.NotEmpty(json);
        }
    }
}