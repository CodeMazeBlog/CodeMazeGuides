using App.UseCases;

namespace Tests;

public class JsonSupportTests
{
    [Fact]
    public void WhenYamlIsSerializedToJson_ThenJsonIsReturned()
    {
        var yaml = "Name: Test\nAge: 30";
        var expectedJson = "{\"Name\":\"Test\",\"Age\":\"30\"}\n";
        var actualJson = JsonSupport.SerializeToJson(yaml);

        Assert.Equal(RemoveWhitespace(expectedJson), RemoveWhitespace(actualJson));
    }

    private string RemoveWhitespace(string str)
    {
        return string.Join("", str.Split(default(string[]), StringSplitOptions.RemoveEmptyEntries));
    }
}