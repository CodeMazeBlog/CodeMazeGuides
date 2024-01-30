using JObjectToDictionary;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

var person = new JObject(
    new JProperty("Name", "John Smith"),
    new JProperty("BirthDate", new DateTime(1983, 3, 20)),
    new JProperty("Hobbies", new JArray("Play football", "Programming")),
    new JProperty("Extra", new JObject(
        new JProperty("Age", 27),
        new JProperty("Phone", new JArray(1, 2, 3))
    ))
);

PrintDictionary(JObjectConverter.ConvertJObjectToDictionary(person));

var result = JObjectConverter.ConvertUsingNewtonsoftJson(person);
foreach (var kvp in result!)
{
    Console.WriteLine($"{kvp.Key}: {kvp.Value}");
}

PrintDictionary(JObjectConverter.ConvertUsingLinq(person));

PrintDictionary(person.ToDictionary());

static void PrintDictionary(Dictionary<string, object> dictionary)
{
    string jsonString = JsonConvert.SerializeObject(dictionary, Formatting.Indented);

    Console.WriteLine(jsonString);
}
