using Bogus;

namespace GetFirstRecordInEachGroup;

public static class Methods
{
    public static List<Student> GenerateStudents(int count = 100_000) => 
        new Faker<Student>()
        .UseSeed(42)
        .RuleFor(m => m.FirstName, faker => faker.Person.FirstName)
        .RuleFor(m => m.LastName, faker => faker.Person.LastName)
        .RuleFor(m => m.DateOfBirth, faker => DateOnly.FromDateTime(faker.Person.DateOfBirth))
        .RuleFor(m => m.Class, faker => faker.PickRandom(Enumerable.Range(1, 10)))
        .Generate(count);

    public static List<Student> GetYoungestStudentInClassLinqGroupBy1(this List<Student> students) 
        => students.GroupBy(m => m.Class, (key, g) => g.OrderByDescending(e => e.DateOfBirth).First())
        .ToList();

    public static List<Student> GetYoungestStudentInClassLinqGroupBy2(this List<Student> students) 
        => students.GroupBy(m => m.Class).Select(g => g.OrderByDescending(e => e.DateOfBirth).First())
        .ToList();

    public static List<Student> GetYoungestStudentInClassLinqLookup(this List<Student> students) 
        => students.ToLookup(m => m.Class).Select(g => g.OrderByDescending(e => e.DateOfBirth).First())
       .ToList();

    public static List<Student> GetYoungestStudentInClassLinqDictionary(this List<Student> students) 
        => students.Select(m => m.Class).Distinct()
        .ToDictionary(m => m,
          m => students
          .Where(s => s.Class.Equals(m))
          .OrderByDescending(s => s.DateOfBirth).First())
        .Values
        .ToList();

    public static List<Student> GetYoungestStudentInClassIterativeDictionary(this List<Student> students)
    {
        var groupedStudents = new Dictionary<int, Student>();
        foreach (var student in students)
        {
            if (!groupedStudents.TryGetValue(student.Class, out Student existingStudent) ||
                student.DateOfBirth > existingStudent.DateOfBirth)
            {
                groupedStudents[student.Class] = student;
            }
        }

        return groupedStudents.Values.ToList();
    }
}