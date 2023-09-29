using System;
using System.Text.Json;

namespace CustomNamingPolicy.NET8.Test;

public class Tests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void GivenObject_WhenSerializeWithSnakeCaseLowerPolicy_ReturnSnakeCaseLowerResult()
    {
        //Arrange
        var propObj= new { PropertyName = "value" };
        var options = new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.SnakeCaseLower
        };

        //Act
        var jsonObj = JsonSerializer.Serialize(propObj, options);
        var expectedJsonObj = "{\"property_name\":\"value\"}";

        //Assert
        Assert.AreEqual(expectedJsonObj,jsonObj);
    }

    [Test]
    public void GivenObject_WhenSerializeWithKebabCaseUpperPolicy_ReturnKebabCaseUpperResult()
    {
        //Arrange
        var propObj = new { PropertyName = "value" };
        var options = new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.KebabCaseUpper
        };

        //Act
        var jsonObj = JsonSerializer.Serialize(propObj, options);
        var expectedJsonObj = "{\"PROPERTY-NAME\":\"value\"}";

        //Assert
        Assert.AreEqual(expectedJsonObj, jsonObj);
    }
}