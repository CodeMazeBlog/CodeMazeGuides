namespace Tests;

[UsesVerify]
public class BasicUsagesTest
{
    private static readonly List<Student> _students = StudentsGenerator.GenerateStudents();

    [Fact]
    public void WhenFormatCharacterIsEscaped_ThenRenderTextWithSquareBrackets()
    {
        // Given
        var console = new TestConsole();

        // When
        console.Markup($"[[{_students[3].FirstName}]][blue][[{_students[3].Hostel}]][/]");

        // Then
        console.Output.ShouldBe("[Sabrina][George]");
    }

    [Fact]
    public Task WhenJsonDataIsPassed_ThenRenderBeautifiedStudentsDataJson()
    {
        // Given
        var console = new TestConsole().Size(new Size(100, 25));

        // When
        console.Write(SpectreConsoleBasicUsages.BeautifyStudentsDataJson());

        // Then
        return Verify(console.Output);
    }

    [Fact]
    public Task WhenACalendarIsCreated_ThenPrettyPrintCalendar()
    {
        // Given
        var console = new TestConsole();

        // When
        console.Write(SpectreConsoleBasicUsages.PrettyPrintCalendar());

        // Then
        return Verify(console.Output);
    }
}