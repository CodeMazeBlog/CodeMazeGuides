using LinqInnerJoin;
using Xunit;

namespace Tests;

public class LinqInnerJoinUnitTest
{
    [Fact]
    public void WhenFetchingCourses_ThenGetCoursesWithCategoryName()
    {
        var courses = new List<Course>
        {
            new() { Id = 1, Name = "C#", CategoryId = 1 },
            new() { Id = 2, Name = "Docker", CategoryId = 2 },
            new() { Id = 3, Name = "Python", CategoryId = 1 },
        };

        var result = EnrolmentHelper.GetCoursesWithCategoryName(courses)
            .Select(c => ((int)c.Id, (string)c.Name, (string)c.CategoryName))
            .ToList();

        var expectedResult = new List<(int, string, string)>
        {
            (1, "C#", "Programming Language"),
            (2, "Docker", "DevOps"),
            (3, "Python", "Programming Language"),
        };

        Assert.Equal(expectedResult, result);
    }

    [Fact]
    public void WhenFetchingCourses_ThenGetCoursesWithCategory()
    {
        var courses = new List<Course>
        {
            new() { Id = 1, Name = "C#", CategoryId = 1 },
            new() { Id = 2, Name = "Docker", CategoryId = 2 },
            new() { Id = 3, Name = "SQL", CategoryId = 3 },
            new() { Id = 4, Name = "Jenkins", CategoryId = 2 },
        };

        var result = EnrolmentHelper.GetCoursesWithCategory(courses)
            .Select(c => ((int)c.Id, (string)c.Name, (string)c.CategoryName))
            .ToList();

        var expectedResult = new List<(int, string, string)>
        {
            (1, "C#", "Programming Language"),
            (2, "Docker", "DevOps"),
            (3, "SQL", "Database System"),
            (4, "Jenkins", "DevOps"),
        };

        Assert.Equal(expectedResult, result);
    }

    [Fact]
    public void WhenCourseHasUnknownCategory_ThenInnerJoinDropsIt()
    {
        var courses = new List<Course>
        {
            new() { Id = 1, Name = "C#", CategoryId = 1 },
            new() { Id = 2, Name = "COBOL", CategoryId = 99 },
        };

        var result = EnrolmentHelper.GetCoursesWithCategory(courses).ToList();

        var course = Assert.Single(result);
        Assert.Equal("C#", (string)course.Name);
    }

    [Fact]
    public void WhenJoiningWithoutResultSelector_ThenGetTuples()
    {
        var courses = new List<Course>
        {
            new() { Id = 1, Name = "C#", CategoryId = 1 },
            new() { Id = 2, Name = "Docker", CategoryId = 2 },
        };

        var result = EnrolmentHelper.GetCourseCategoryPairs(courses)
            .Select(pair => (pair.Outer.Name, pair.Inner.Name))
            .ToList();

        Assert.Equal([("C#", "Programming Language"), ("Docker", "DevOps")], result);
    }

    [Fact]
    public void WhenFetchingEnrolments_ThenFetchWithStudentAndCourseName()
    {
        var enrolments = new List<Enrolment>
        {
            new() { Id = 1, StudentId = 1, CourseId = 1 },
            new() { Id = 2, StudentId = 2, CourseId = 6 },
            new() { Id = 3, StudentId = 3, CourseId = 8 },
        };

        var result = EnrolmentHelper.GetEnrolments(enrolments)
            .Select(e => ((int)e.Id, (string)e.StudentName, (string)e.CourseName))
            .ToList();

        var expectedResult = new List<(int, string, string)>
        {
            (1, "John", "CSHARP"),
            (2, "Abhi", "MSSQL"),
            (3, "Rahul", "MONGODB"),
        };

        Assert.Equal(expectedResult, result);
    }

    [Fact]
    public void WhenFilterEnrolments_ThenReturnsCorrectData()
    {
        var enrolments = new List<Enrolment>
        {
            new() { Id = 1, StudentId = 1, CourseId = 1 },
            new() { Id = 2, StudentId = 2, CourseId = 2 },
            new() { Id = 3, StudentId = 3, CourseId = 1 },
        };

        var expected = new List<(int, string, int, string)>
        {
            (1, "John", 1, "CSHARP"),
            (3, "Rahul", 1, "CSHARP"),
        };

        var actual = EnrolmentHelper.FilterEnrolments(enrolments)
            .Select(e => ((int)e.Id, (string)e.StudentName, (int)e.CourseId, (string)e.CourseName))
            .ToList();

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void WhenFilterAndGroupEnrolments_ThenReturnCorrectData()
    {
        var enrolments = Enrolment.GetDummyEnrolment();

        var result = EnrolmentHelper.FilterAndGroupEnrolments(enrolments).ToList();

        var actual = result
            .Select(group => ((int)group.Key,
                group
                    .Select(e => ((int)e.Id, (string)e.StudentName, (string)e.CourseName))
                    .ToList()))
            .ToList();

        Assert.Equal([1, 2, 3, 4], actual.Select(group => group.Item1));
        Assert.Equal([(1, "John", "CSHARP"), (7, "Rahul", "CSHARP"), (16, "Anita", "CSHARP")], actual[0].Item2);
        Assert.Equal([(4, "Abhi", "PYTHON")], actual[1].Item2);
        Assert.Equal([(5, "Abhi", "JAVA")], actual[2].Item2);
        Assert.Equal([(18, "Jenny", "RUBY")], actual[3].Item2);
    }

    [Fact]
    public void WhenJoiningOnCompositeKey_ThenOnlyMatchingPairsReturn()
    {
        var enrolments = Enrolment.GetDummyEnrolment();

        var querySyntax = EnrolmentHelper.GetEnrolmentsWithGrade(enrolments)
            .Select(e => ((int)e.Id, (string)e.Mark))
            .ToList();
        var methodSyntax = EnrolmentHelper.GetEnrolmentsWithGradeMethodSyntax(enrolments)
            .Select(e => ((int)e.Id, (string)e.Mark))
            .ToList();

        Assert.Equal([(1, "A"), (3, "B"), (6, "A")], querySyntax);
        Assert.Equal(querySyntax, methodSyntax);
    }

    [Fact]
    public void WhenGroupJoining_ThenEveryCourseAppearsOnce()
    {
        var result = EnrolmentHelper.GetEnrolmentCountPerCourse(Course.GetDummyCourses())
            .Select(c => ((string)c.Name, (int)c.EnrolmentCount))
            .ToList();

        Assert.Equal(13, result.Count);
        Assert.Contains(("KUBERNETES", 0), result);
        Assert.Contains(("CSHARP", 3), result);
    }
}
