using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
namespace ComparingTwoJsonObjects;

public class JsonComparison
{
    public string PlainJsonString { get; set; }
    public string SecondPlainJsonString { get; set; }
    public string NestedJsonString { get; set; }

    public JsonComparison()
    {
        InitializeData();
    }

    public void InitializeData()
    {
        var testData = new TestData();
        PlainJsonString = testData.GeneratePlainJsonString();
        SecondPlainJsonString = testData.GeneratePlainJsonString();
        NestedJsonString = testData.GenerateNestedJsonString();
    }

    public Dictionary<string, string> CompareJsonObjectsUsingDeepEquals()
    {
        var result = new Dictionary<string, string>();
        var plainJsonObject = JToken.Parse(PlainJsonString);
        var secondJsonObject = JToken.Parse(SecondPlainJsonString);
        var nestedJsonObject = JToken.Parse(NestedJsonString);

        var arePlainObjectsEqual = JToken.DeepEquals(plainJsonObject, secondJsonObject);
        var isPlainAndNestedObjectEqual = JToken.DeepEquals(secondJsonObject, nestedJsonObject);

        string responseString;

        if (arePlainObjectsEqual)
        {
            responseString = "The plain json objects are equal";
            result.Add("Plain Objects Result", responseString);
        }
        else
        {
            responseString = "The plain json objects are not equal";
            result.Add("Plain Objects Result", responseString);
        }


        if (isPlainAndNestedObjectEqual)
        {
            responseString = "The plain and nested json objects are equal";
            result.Add("Nested Objects Result", responseString);
        }
        else
        {
            responseString = "The plain and nested json objects are not equal";
            result.Add("Nested Objects Result", responseString);
        }

        return result;
    }

    public Dictionary<string, string> CompareDeserializedJsonObjects()
    {
        var result = new Dictionary<string, string>();
        var car1 = JsonConvert.DeserializeObject<Car>(PlainJsonString);
        var car2 = JsonConvert.DeserializeObject<Car>(SecondPlainJsonString);
        var car3 = JsonConvert.DeserializeObject<Car>(NestedJsonString);

        string responseString;

        if (car1.Equals(car2))
        {
            responseString = "The two deserialized plain json objects are equal";
            result.Add("Plain Objects Result", responseString);
        }
        else
        {
            responseString = "The two deserialized plain json objects are not equal";
            result.Add("Plain Objects Result", responseString);
        }

        if (car1.Equals(car3))
        {
            responseString = "The plain and nested deserialized objects are equal";
            result.Add("Nested Objects Result", responseString);
        }
        else
        {
            responseString = "The plain and nested deserialized objects are not equal";
            result.Add("Nested Objects Result", responseString);
        }

        return result;
    }

    public Dictionary<string, string> CompareJsonObjectsUsingLinq()
    {
        var result = new Dictionary<string, string>();
        var car1 = JObject.Parse(PlainJsonString);
        var car2 = JObject.Parse(SecondPlainJsonString);
        var car3 = JObject.Parse(NestedJsonString);

        var arePlainObjectsEqual = car1.Properties().All(p => p.Value.Equals(car2[p.Name]));
        var isPlainAndNestedObjectEqual = car3.Properties().All(p => p.Value.Equals(car1[p.Name]));

        string responseString;

        if (arePlainObjectsEqual)
        {
            responseString = "The plain JSON objects are equal";
            result.Add("Plain Objects Result", responseString);
        }
        else
        {
            responseString = "The plain JSON objects are not equal";
            result.Add("Plain Objects Result", responseString);
        }

        if (isPlainAndNestedObjectEqual)
        {
            responseString = "The plain and nested json objects are equal";
            result.Add("Nested Objects Result", responseString);
        }
        else
        {
            responseString = "The plain and nested json objects are not equal";
            result.Add("Nested Objects Result", responseString);
        }

        return result;
    }
}