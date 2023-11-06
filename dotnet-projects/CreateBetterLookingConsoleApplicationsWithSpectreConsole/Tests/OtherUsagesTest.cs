namespace Tests;

[UsesVerify]
public class OtherUsagesTest
{
    [Fact]
    public Task WhenStudentDataIsPassed_ThenRenderStudentsTable()
    {
        // Given
        var console = new TestConsole();

        // When
        console.Write(SpectreConsoleOtherUsages.CreateStudentTable());

        // Then
        return Verifier.Verify(console.Output);
    }

    [Fact]
    public Task WhenPromptingStudentForAge_ThenReturnErrorIfValidationFails()
    {
        // Given
        var console = new TestConsole();
        console.Input.PushTextWithEnter("102");
        console.Input.PushTextWithEnter("ABC");
        console.Input.PushTextWithEnter("99");
        console.Input.PushTextWithEnter("22");

        // When
        console.Prompt(SpectreConsoleOtherUsages.GetAgeTextPrompt());

        // Then
        return Verify(console.Output);

    }

    [Fact]
    public void WhenPromptingStudentForHostel_ThenDisplayHotelSelectionPrompt()
    {
        // Given
        var console = new TestConsole();
        console.Profile.Capabilities.Interactive = true;
        console.Input.PushKey(ConsoleKey.Enter);

        // When
        var prompt = SpectreConsoleOtherUsages.GetHostelSelectionPrompt();
        prompt.Show(console);

        // Then
        console.Output.ShouldContain("Choose a Hostel");
        console.Output.ShouldContain("Lincoln");
        console.Output.ShouldContain("Louisa");
        console.Output.ShouldContain("Laurent");
        console.Output.ShouldContain("George");
        console.Output.ShouldContain("Kennedy");
    }

    [Fact]
    public async Task WhenStudentsDataIsPassed_ThenDisplayBarChart()
    {
        // Given
        var console = new TestConsole();

        // When
        console.Write(SpectreConsoleOtherUsages.CreateHostelBarChart());

        // Then
        await Verify(console.Output);
    }

    [Fact]
    public async Task WhenDisplayFigLetIsInvoked_ThenDisplayFiglet()
    {
        // Given
        var console = new TestConsole().Width(100);

        // When
        console.Write(SpectreConsoleOtherUsages.DisplayFiglet());

        // Then
        await Verify(console.Output);
    }
}