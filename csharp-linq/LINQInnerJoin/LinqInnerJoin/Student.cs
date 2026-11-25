namespace LinqInnerJoin;

public class Student
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;

    public static IEnumerable<Student> GetDummyStudents() =>
    [
        new() { Id = 1, Name = "John" },
        new() { Id = 2, Name = "Abhi" },
        new() { Id = 3, Name = "Rahul" },
        new() { Id = 4, Name = "Nisha" },
        new() { Id = 5, Name = "Mike" },
        new() { Id = 6, Name = "Joana" },
        new() { Id = 7, Name = "Nick" },
        new() { Id = 8, Name = "Julie" },
        new() { Id = 9, Name = "Anita" },
        new() { Id = 10, Name = "Jenny" }
    ];
}
