// See https://aka.ms/new-console-template for more information
using JsonPolymorphicSerialization;
using System.Text.Json;

var members = new Member[]
{
    new Student()
    {
        Name = "John Doe",
        BirthDate = new DateTime(2000, 2, 4),
        RegistrationYear = 2019,
        Courses = new List<string>()
        {
            "Algorithms",
            "Databases",
        }
    },
    new Professor()
    {
        Name = "Jane Doe",
        BirthDate = new DateTime(1978, 6, 6),
        Rank = "Full Professor",
        IsTenured = true,
    },
    new Student()
    {
        Name = "Jason Doe",
        BirthDate = new DateTime(2002, 7, 8),
        RegistrationYear = 2020,
        Courses = new List<string>()
        {
            "Databases"
        }
    }
};

var options = new JsonSerializerOptions
{
    WriteIndented = true
};

string membersJson = JsonSerializer.Serialize<Member[]>(members, options);
membersJson = JsonSerializer.Serialize<object[]>(members, options);

options = new JsonSerializerOptions
{
    Converters = { new UniversityJsonConverter() },
    WriteIndented = true
};

membersJson = JsonSerializer.Serialize<Member[]>(members, options);
var newMembers = JsonSerializer.Deserialize <Member[]>(membersJson, options);

