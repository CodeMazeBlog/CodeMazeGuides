namespace LinqInnerJoin;

public class Category
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;

    public static IEnumerable<Category> GetDummyCourseCategories() =>
    [
        new() { Id = 1, Name = "Programming Language" },
        new() { Id = 2, Name = "DevOps" },
        new() { Id = 3, Name = "Database System" }
    ];
}
