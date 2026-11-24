namespace LinqInnerJoin;

public class Grade
{
    public int StudentId { get; set; }
    public int CourseId { get; set; }
    public string Mark { get; set; } = string.Empty;

    public static IEnumerable<Grade> GetDummyGrades() =>
    [
        new() { StudentId = 1, CourseId = 1, Mark = "A" },
        new() { StudentId = 1, CourseId = 12, Mark = "B" },
        new() { StudentId = 3, CourseId = 7, Mark = "A" },
        new() { StudentId = 2, CourseId = 1, Mark = "C" }
    ];
}
