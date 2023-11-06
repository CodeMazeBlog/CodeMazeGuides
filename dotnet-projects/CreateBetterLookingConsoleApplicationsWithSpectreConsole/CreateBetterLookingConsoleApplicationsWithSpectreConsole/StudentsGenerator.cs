using System.Text.Json;

namespace CreateBetterLookingConsoleAppsWithSpectreConsole;

public static class StudentsGenerator
{
    public static string[] Hostels { get; }
        = new string[] { "Lincoln", "Louisa", "Laurent", "George", "Kennedy" };

    public static List<Student> GenerateStudents()
    {
        return new List<Student>()
        {
            new Student{Id=1, FirstName="Julie", LastName="Matthew", Age=19, Hostel=Hostels[0]},
            new Student{Id=2, FirstName="Michael", LastName="Taylor", Age=23, Hostel=Hostels[3]},
            new Student{Id=3, FirstName="Joe", LastName="Hardy", Age=27, Hostel=Hostels[2]},
            new Student{Id=4, FirstName="Sabrina", LastName="Azulon", Age=18, Hostel=Hostels[3]},
            new Student{Id=5, FirstName="Hunter", LastName="Cyril", Age=19, Hostel=Hostels[4]},
        };
    }

    public static string ConvertStudentsToJson(List<Student> students)
    {
        return JsonSerializer.Serialize(students, new JsonSerializerOptions
        {
            WriteIndented = true
        });
    }
}