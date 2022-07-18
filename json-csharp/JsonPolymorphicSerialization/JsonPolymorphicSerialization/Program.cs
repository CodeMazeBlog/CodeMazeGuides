// See https://aka.ms/new-console-template for more information
using JsonPolymorphicSerialization;
using System.Text.Json;

var list = new Person[]
{
    new Student()
    {
        FirstName = "John",
        LastName =  "Doe",
        BirthDate = new DateTime(2000, 2, 4),
        HomeAddress = "3 Main str., 22323 Boston, USA",
        RegistrationYear = 2019,
        CoursesTaken = new List<string>()
        {
            "Algorithms",
            "Databases",
        }
    },
    new Professor()
    {
        FirstName = "Jane",
        LastName =  "Doe",
        BirthDate = new DateTime(1978, 6, 6),
        HomeAddress = "1 Market str., HHFW33 London, UK",
        OfficeNumber = "222A",
        CoursesOffered = new List<string>()
        {
            "Algorithms"
        }
    },
    new Student()
    {
        FirstName = "Jason",
        LastName =  "Doe",
        BirthDate = new DateTime(2002, 7, 8),
        HomeAddress = "5 First str., 43422 New York, USA",
        RegistrationYear = 2020,
        CoursesTaken = new List<string>()
        {
            "Databases",
        }
    }
};

var options = new JsonSerializerOptions
{
    WriteIndented = true
};

string personsJson = JsonSerializer.Serialize<Person[]>(list, options);
personsJson = JsonSerializer.Serialize<object[]>(list, options);


options = new JsonSerializerOptions
{
    Converters = { new UniversityJsonConverter() },
    WriteIndented = true
};

personsJson = JsonSerializer.Serialize<Person[]>(list, options);
var personsList = JsonSerializer.Deserialize<List<Person>>(personsJson, options);

