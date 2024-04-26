using App.UseCases;
using static System.Environment;

namespace Tests;

public class JsonSupportTests
{
    [Fact]
    public void GivenYamlInput_WhenYamlIsSerializedToJson_ThenJsonIsReturned()
    {
        var yaml = $"Name: Test{NewLine}Age: 30";
        var expectedJson = $"{{\"Name\": \"Test\", \"Age\": \"30\"}}{NewLine}";
        var actualJson = JsonSupport.SerializeToJson(yaml);

        Assert.Equal(expectedJson, actualJson);
    }
}