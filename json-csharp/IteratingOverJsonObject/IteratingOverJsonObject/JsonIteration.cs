using System.Text.Json;
using System.Text.Json.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace IteratingOverJsonObject;

public class JsonIteration
{
    public string Json { get; set; }
    public string Name { get; set; }
    public int Age { get; set; }
    public string Department { get; set; }

    public JsonIteration()
    {
        Json = new TestData().GenerateJsonData();
    }

    public void IterateOverJsonDynamically(string jsonString)
    {
        var jsonData = JsonConvert.DeserializeObject<dynamic>(jsonString);

        foreach (var data in jsonData)
        {
            Name = data.name;
            Age = data.age;
            Department = data.department;
        }
    }

    public void IterateUsingJArray(string jsonString)
    {
        var jsonArray = JArray.Parse(jsonString);

        foreach (var data in jsonArray)
        {
            Name = (string)data["name"];
            Age = (int)data["age"];
            Department = (string)data["department"];
        }
    }

    public List<Employee> IterateUsingStaticObject(string jsonString)
    {
        var employees = JsonConvert.DeserializeObject<List<Employee>>(jsonString);

        foreach (var employee in employees)
        {
            Name = employee.Name;
            Age = employee.Age;
            Department = employee.Department;
        }

        return employees;
    }

    public List<Employee> IterateUsingSystemJson(string jsonString)
    {
        var employees = JsonSerializer.Deserialize<List<Employee>>(jsonString, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        });

        foreach (var employee in employees)
        {
            Name = employee.Name;
            Age = employee.Age;
            Department = employee.Department;
        }

        return employees;
    }
}