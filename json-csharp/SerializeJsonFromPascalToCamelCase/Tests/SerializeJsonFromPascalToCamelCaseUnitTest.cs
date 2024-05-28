namespace Tests;

public class SerializeJsonFromPascalToCamelCaseUnitTest
{
    [Fact]
    public void GivenEdgeCase_WhenAJsonSerializeObjectIsUsed_ThenDesiredOutputNotReturned()
    {
        var serializedObject = JsonConvert.SerializeObject(GetData());

        Assert.NotEqual(serializedObject, GetResult());
    }

    [Fact]
    public void GivenEdgeCase_WhenDefaultSettingsIsSetToCamelCase_ThenDesiredOutputIsReturned()
    {
        JsonConvert.DefaultSettings = () => new JsonSerializerSettings
        {
            ContractResolver = new CamelCasePropertyNamesContractResolver()
        };

        var serializedObject = JsonConvert.SerializeObject(GetData());

        Assert.Equal(serializedObject, GetResult());
    }

    [Fact]
    public void GivenEdgeCase_WhenJsonSerializerSettingsIsUsed_ThenDesiredOutputIsReturned()
    {
        var result = FormatJson.ConvertToCamel(JObject.FromObject(GetData()));
        var serializedObject = JsonConvert.SerializeObject(result);

        Assert.Equal(serializedObject, GetResult());
    }

    private static House GetData()
    {
        return new House
        {
            SizeInSqft = 1000,
            NoOfRooms = 2,
            OtherDetails = JObject.FromObject(new Measurement
            {
                Width = 50,
                Length = 100
            })
        };
    }

    private static string GetResult() =>
        "{\"noOfRooms\":2,\"sizeInSqft\":1000.0,\"otherDetails\":{\"width\":50,\"length\":100}}";
}