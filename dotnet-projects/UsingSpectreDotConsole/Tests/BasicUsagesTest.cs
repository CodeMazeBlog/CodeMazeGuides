namespace Tests;

[UsesVerify]
public class BasicUsagesTest
{
    private static readonly List<Student> _students = StudentsGenerator.GenerateStudents();

    [Fact]
    public void WhenFormatCharacterIsEscaped_ThenRenderTextWithSquareBrackets()
    {
        var console = new TestConsole();
        console.Markup($"[[{_students[3].FirstName}]][blue][[{_students[3].Hostel}]][/]");
        console.Output.ShouldBe("[Sabrina][George]");
    }

    [Fact]
    public Task WhenJsonDataIsPassed_ThenRenderBeautifiedStudentsDataJson()
    {
        var console = new TestConsole().Size(new Size(100, 25));
        console.Write(SpectreConsoleBasicUsages.BeautifyStudentsDataJson());

        return Verify(console.Output);
    }

    [Fact]
    public Task WhenACalendarIsCreated_ThenPrettyPrintCalendar()
    {
        var console = new TestConsole();
        console.Write(SpectreConsoleBasicUsages.PrettyPrintCalendar());

        return Verify(console.Output);
    }
}