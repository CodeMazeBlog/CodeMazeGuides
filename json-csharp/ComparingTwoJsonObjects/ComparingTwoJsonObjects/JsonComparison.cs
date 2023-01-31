using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Reflection;
using System.Xml.Linq;

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

    public void CompareJsonObjectsUsingDeepEquals()
    {
        var plainJsonObject = JToken.Parse(PlainJsonString);
        var secondJsonObject = JToken.Parse(SecondPlainJsonString);
        var nestedJsonObject = JToken.Parse(NestedJsonString);

        var arePlainObjectsEqual = JToken.DeepEquals(plainJsonObject, secondJsonObject);
        var isPlainAndNestedObjectEqual = JToken.DeepEquals(secondJsonObject, nestedJsonObject);

        if (arePlainObjectsEqual)
        {
            Console.WriteLine("The plain json objects are equal");
        }
        else
        {
            Console.WriteLine("The plain json objects are not equal");
        }


        if (isPlainAndNestedObjectEqual)
        {
            Console.WriteLine("The plain and nested json objects are equal");
        }
        else
        {
            Console.WriteLine("The plain and nested json objects are not equal");
        }
    }

    public void CompareDeserializedJsonObjects()
    {
        var car1 = JsonConvert.DeserializeObject<Car>(PlainJsonString);
        var car2 = JsonConvert.DeserializeObject<Car>(SecondPlainJsonString);
        var car3 = JsonConvert.DeserializeObject<Car>(NestedJsonString);

        if (car1.Equals(car2))
        {
            Console.WriteLine("The two deserialized plain json objects are equal");
        }
        else
        {
            Console.WriteLine("The two deserialized plain json objects are not equal");
        }

        if (car1.Equals(car3))
        {
            Console.WriteLine("The plain and nested deserialized objects are equal");
        }
        else
        {
            Console.WriteLine("The plain and nested deserialized objects are not equal");
        }
    }

    public void CompareJsonObjectsUsingLinq()
    {
        var car1 = JObject.Parse(PlainJsonString);
        var car2 = JObject.Parse(SecondPlainJsonString);
        var car3 = JObject.Parse(NestedJsonString);

        var arePlainObjectsEqual = car1.Properties().All(p => p.Value.Equals(car2[p.Name]));
        var isPlainAndNestedObjectEqual = car3.Properties().All(p => p.Value.Equals(car1[p.Name]));

        if (arePlainObjectsEqual)
        {
            Console.WriteLine("The plain JSON objects are equal");
        }
        else
        {
            Console.WriteLine("The plain JSON objects are not equal");
        }

        if (isPlainAndNestedObjectEqual)
        {
            Console.WriteLine("The plain and nested json objects are equal");
        }
        else
        {
            Console.WriteLine("The plain and nested json objects are not equal");
        }
    }
}