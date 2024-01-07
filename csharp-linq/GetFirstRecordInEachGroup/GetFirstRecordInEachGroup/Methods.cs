using Bogus;

namespace GetFirstRecordInEachGroup;

public static class Methods
{
    public static List<Student> GenerateStudents(int count = 100000) =>
         new Faker<Student>()
        .RuleFor(m => m.FirstName, faker => faker.Person.FirstName)
        .RuleFor(m => m.LastName, faker => faker.Person.LastName)
        .RuleFor(m => m.DateOfBirth, faker => DateOnly.FromDateTime(faker.Person.DateOfBirth))
        .RuleFor(m => m.Class, faker => faker.PickRandom(Enumerable.Range(1,10)))
        .Generate(count);

    public static List<Student> GetYoungestStudentInClassLinqGroupBy1
        (this List<Student> students) =>
        students.GroupBy(m => m.Class, (key, g) => g.OrderBy(e => e.DateOfBirth).First())
        .ToList();

    public static List<Student> GetYoungestStudentInClassLinqGroupBy2
        (this List<Student> students) =>
        students.GroupBy(m => m.Class).Select(g => g.OrderBy(e => e.DateOfBirth).First())
        .ToList();

    public static List<Student> GetYoungestStudentInClassLinqLookup
       (this List<Student> students) =>
       students.ToLookup(m => m.Class).Select(g => g.OrderBy(e => e.DateOfBirth).First())
       .ToList();

    public static List<Student> GetYoungestStudentInClassLinqDictionary
      (this List<Student> students) =>
      students.Select(m => m.Class).Distinct()
        .ToDictionary(m => m, 
          m => students
          .Where(s => s.Class.Equals(m))
          .OrderBy(s => s.DateOfBirth).First())
        .Values
        .ToList();

    public static List<Student> GetYoungestStudentInClassIterativeDictionary
        (this List<Student> students)
    {
        var grouppedStudents = new Dictionary<int, Student>();
        foreach (var student in students)
        {
            if (!grouppedStudents.ContainsKey(student.Class))
                grouppedStudents.Add(student.Class, student);
            else if (student.DateOfBirth < 
                grouppedStudents[student.Class].DateOfBirth)
                grouppedStudents[student.Class] = student;
        }

        return grouppedStudents.Values.ToList();
    }
}