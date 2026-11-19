namespace Tests;

public class OtherUsagesTest
{
    [Fact]
    public Task WhenStudentDataIsPassed_ThenRenderStudentsTable()
    {
        var console = new TestConsole();
        console.Write(SpectreConsoleOtherUsages.CreateStudentTable());

        return Verify(console.Output);
    }

    [Fact]
    public Task WhenPromptingStudentForAge_ThenReturnErrorIfValidationFails()
    {
        var console = new TestConsole();
        console.Input.PushTextWithEnter("ABC");
        console.Input.PushTextWithEnter("5");
        console.Input.PushTextWithEnter("150");
        console.Input.PushTextWithEnter("22");

        var age = console.Prompt(SpectreConsoleOtherUsages.GetAgeTextPrompt());

        age.ShouldBe(22);

        return Verify(console.Output);
    }

    [Fact]
    public void WhenStudentPressesDownThenEnter_ThenSelectSecondHostel()
    {
        var console = new TestConsole().Interactive();
        console.Input.PushKey(ConsoleKey.DownArrow);
        console.Input.PushKey(ConsoleKey.Enter);

        var hostel = console.Prompt(SpectreConsoleOtherUsages.GetHostelSelectionPrompt());

        hostel.ShouldBe("Louisa");
    }

    [Fact]
    public void WhenPromptingStudentForHostel_ThenDisplayHotelSelectionPrompt()
    {
        var console = new TestConsole();
        console.Profile.Capabilities.Interactive = true;
        console.Input.PushKey(ConsoleKey.Enter);

        var prompt = SpectreConsoleOtherUsages.GetHostelSelectionPrompt();
        prompt.Show(console);

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
        var console = new TestConsole();
        console.Write(SpectreConsoleOtherUsages.CreateHostelBarChart());

        await Verify(console.Output);
    }

    [Fact]
    public async Task WhenDisplayFigLetIsInvoked_ThenDisplayFiglet()
    {
        var console = new TestConsole().Width(100);
        console.Write(SpectreConsoleOtherUsages.DisplayFiglet());

        await Verify(console.Output);
    }
}