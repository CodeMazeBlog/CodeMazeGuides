using ThenullbangStatementInCSharp;

namespace Tests;

public class StudentTest
{
    [Fact]
    public void WhenCreatingAStudent_ThenReturnsANonNullableName()
    {
        var student = new Student
        {
            Id = 1,
            Name = "Duke"
        };

        Assert.IsType<string>(student.Name);
    }
}