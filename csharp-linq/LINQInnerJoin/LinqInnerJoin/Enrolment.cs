namespace LinqInnerJoin;

public class Enrolment
{
    public int Id { get; set; }
    public int StudentId { get; set; }
    public int CourseId { get; set; }

    public static IEnumerable<Enrolment> GetDummyEnrolment() =>
    [
        new() { Id = 1, StudentId = 1, CourseId = 1 },
        new() { Id = 2, StudentId = 1, CourseId = 8 },
        new() { Id = 3, StudentId = 1, CourseId = 12 },
        new() { Id = 4, StudentId = 2, CourseId = 2 },
        new() { Id = 5, StudentId = 2, CourseId = 3 },
        new() { Id = 6, StudentId = 3, CourseId = 7 },
        new() { Id = 7, StudentId = 3, CourseId = 1 },
        new() { Id = 8, StudentId = 4, CourseId = 9 },
        new() { Id = 9, StudentId = 5, CourseId = 9 },
        new() { Id = 10, StudentId = 6, CourseId = 6 },
        new() { Id = 11, StudentId = 6, CourseId = 5 },
        new() { Id = 12, StudentId = 6, CourseId = 11 },
        new() { Id = 13, StudentId = 7, CourseId = 9 },
        new() { Id = 14, StudentId = 8, CourseId = 12 },
        new() { Id = 15, StudentId = 8, CourseId = 7 },
        new() { Id = 16, StudentId = 9, CourseId = 1 },
        new() { Id = 17, StudentId = 9, CourseId = 10 },
        new() { Id = 18, StudentId = 10, CourseId = 4 },
        new() { Id = 19, StudentId = 10, CourseId = 10 },
        new() { Id = 20, StudentId = 10, CourseId = 8 }
    ];
}
