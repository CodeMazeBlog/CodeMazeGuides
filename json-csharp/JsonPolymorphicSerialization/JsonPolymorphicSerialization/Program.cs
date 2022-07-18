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
        HomeAddress = new Address() 
        { 
            Street = "3 Main str.",
            ZipCode = "22323",
            City = "Boston",
            Country = "USA"
        },
        RegistrationYear = 2019,
        CoursesTaken = new List<Course>()
        {
            new Course()
            {
                Name = "Algorithms",
                Semester = 2
            },
            new Course()
            {
                Name = "Databases",
                Semester = 1
            }
        }
    },
    new Professor()
    {
        FirstName = "Jane",
        LastName =  "Doe",
        BirthDate = new DateTime(1978, 6, 6),
        HomeAddress = new Address()
        {
            Street = "1 Market str.",
            ZipCode = "HHFW33",
            City = "London",
            Country = "UK"
        },
        OfficeNumber = "222A",
        CoursesOffered = new List<Course>()
        {
            new Course()
            {
                Name = "Algorithms",
                Semester = 2
            }
        }
    },
    new Student()
    {
        FirstName = "Jason",
        LastName =  "Doe",
        BirthDate = new DateTime(2002, 7, 8),
        HomeAddress = new Address()
        {
            Street = "5 First str.",
            ZipCode = "43422",
            City = "New York",
            Country = "USA"
        },
        RegistrationYear = 2020,
        CoursesTaken = new List<Course>()
        {
            new Course()
            {
                Name = "Databases",
                Semester = 1
            }
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

