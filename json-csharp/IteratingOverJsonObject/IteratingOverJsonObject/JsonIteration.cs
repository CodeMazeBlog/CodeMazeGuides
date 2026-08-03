using System.Text.Json;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace IteratingOverJsonObject;

public class JsonIteration
{
    public string Json { get; set; }

    public JsonIteration()
    {
        Json = new TestData().GenerateJsonData();
    }

    public int IterateOverJsonDynamically()
    {
        var jsonData = JsonConvert.DeserializeObject<dynamic>(Json);

        foreach (var data in jsonData)
        {
            var name = data.name;
            var age = data.age;
            var department = data.department;

            Console.WriteLine($"Name: {name}, Age: {age}, Department: {department}");
        }

        var count = jsonData.Count;
        return count;
    }

    public int IterateUsingJArray()
    {
        var jsonArray = JArray.Parse(Json);

        foreach (var data in jsonArray)
        {
            var name = (string)data["name"];
            var age = (int)data["age"];
            var department = (string)data["department"];

            Console.WriteLine($"Name: {name}, Age: {age}, Department: {department}");
        }

        var count = jsonArray.Count;
        return count;
    }

    public List<Employee> IterateUsingStaticallyTypedObject()
    {
        var employees = JsonConvert.DeserializeObject<List<Employee>>(Json);

        foreach (var employee in employees)
        {
            var name = employee.Name;
            var age = employee.Age;
            var department = employee.Department;

            Console.WriteLine($"Name: {name}, Age: {age}, Department: {department}");
        }

        return employees;
    }

    public List<Employee> IterateUsingSystemJson()
    {
        var employees = JsonSerializer.Deserialize<List<Employee>>(Json, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        });

        foreach (var employee in employees)
        {
            var name = employee.Name;
            var age = employee.Age;
            var department = employee.Department;

            Console.WriteLine($"Name: {name}, Age: {age}, Department: {department}");
        }

        return employees;
    }
}