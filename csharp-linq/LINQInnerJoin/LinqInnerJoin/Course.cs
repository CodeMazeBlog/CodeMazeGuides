namespace LinqInnerJoin;

public class Course
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public int CategoryId { get; set; }

    public static IEnumerable<Course> GetDummyCourses() =>
    [
        new() { Id = 1, Name = "CSHARP", CategoryId = 1 },
        new() { Id = 2, Name = "PYTHON", CategoryId = 1 },
        new() { Id = 3, Name = "JAVA", CategoryId = 1 },
        new() { Id = 4, Name = "RUBY", CategoryId = 1 },
        new() { Id = 5, Name = "GO", CategoryId = 1 },
        new() { Id = 6, Name = "MSSQL", CategoryId = 3 },
        new() { Id = 7, Name = "POSTGRES", CategoryId = 3 },
        new() { Id = 8, Name = "MONGODB", CategoryId = 3 },
        new() { Id = 9, Name = "MYSQL", CategoryId = 3 },
        new() { Id = 10, Name = "DOCKER", CategoryId = 2 },
        new() { Id = 11, Name = "JENKINS", CategoryId = 2 },
        new() { Id = 12, Name = "GIT", CategoryId = 2 },
        new() { Id = 13, Name = "KUBERNETES", CategoryId = 2 }
    ];
}
