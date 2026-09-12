using System.Text.Json;

namespace Test;

public class BuiltInPolicyTests
{
    [Test]
    public void GivenObject_WhenSerializeWithSnakeCaseLowerPolicy_ReturnSnakeCaseLowerResult()
    {
        //Arrange
        var propObj = new { PropertyName = "value" };
        var options = new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.SnakeCaseLower
        };

        //Act
        var jsonObj = JsonSerializer.Serialize(propObj, options);
        var expectedJsonObj = "{\"property_name\":\"value\"}";

        //Assert
        Assert.That(jsonObj, Is.EqualTo(expectedJsonObj));
    }

    [Test]
    public void GivenObject_WhenSerializeWithSnakeCaseUpperPolicy_ReturnSnakeCaseUpperResult()
    {
        //Arrange
        var propObj = new { PropertyName = "value" };
        var options = new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.SnakeCaseUpper
        };

        //Act
        var jsonObj = JsonSerializer.Serialize(propObj, options);
        var expectedJsonObj = "{\"PROPERTY_NAME\":\"value\"}";

        //Assert
        Assert.That(jsonObj, Is.EqualTo(expectedJsonObj));
    }

    [Test]
    public void GivenObject_WhenSerializeWithKebabCaseLowerPolicy_ReturnKebabCaseLowerResult()
    {
        //Arrange
        var propObj = new { PropertyName = "value" };
        var options = new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.KebabCaseLower
        };

        //Act
        var jsonObj = JsonSerializer.Serialize(propObj, options);
        var expectedJsonObj = "{\"property-name\":\"value\"}";

        //Assert
        Assert.That(jsonObj, Is.EqualTo(expectedJsonObj));
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
        Assert.That(jsonObj, Is.EqualTo(expectedJsonObj));
    }
}
