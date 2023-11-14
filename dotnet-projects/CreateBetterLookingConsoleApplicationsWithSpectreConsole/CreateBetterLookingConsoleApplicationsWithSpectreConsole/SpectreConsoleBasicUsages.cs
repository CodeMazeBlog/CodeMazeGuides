using Spectre.Console;
using Spectre.Console.Json;

namespace UsingSpectreConsole;

public class SpectreConsoleBasicUsages
{
    private static readonly List<Student> _students = StudentsGenerator.GenerateStudents();

    public static void SetTextColor()
    {
        AnsiConsole.Markup($"[bold blue]Hello[/] [italic green]{_students[1].FirstName}[/]!"); 
        AnsiConsole.Write(new Markup($"[underline #800080]{_students[2].FirstName}[/]"));
        AnsiConsole.MarkupLine($"[rgb(128,0,0)]{_students[3].FirstName}[/]");
    }

    public static void SetBackgroundColor()
    {
        AnsiConsole.MarkupLine($"[red on yellow] Hello, {_students[4].LastName}![/]");
    }

    public static void EscapeFormatCharacters()
    {
        AnsiConsole.Markup($"[[{_students[3].FirstName}]]");
        AnsiConsole.MarkupLine($"[blue][[{_students[3].Hostel}]][/]");
        AnsiConsole.MarkupLine($"[{_students[3].Age}]".EscapeMarkup());
    }

    public static Panel BeautifyStudentsDataJson()
    {
        var json = new JsonText(StudentsGenerator.ConvertStudentsToJson(_students));
        var panel = new Panel(json)
                .Header("Students")
                .HeaderAlignment(Justify.Center)
                .SquareBorder()
                .Collapse()
                .BorderColor(Color.LightSkyBlue1);

        AnsiConsole.Write(panel);

        return panel;      
    }

    public static Calendar PrettyPrintCalendar()
    {
        var calendar = new Calendar(2023, 11)
            .AddCalendarEvent(2023, 11, 19)
            .HighlightStyle(Style.Parse("magenta bold"))
            .HeaderStyle(Style.Parse("purple"));

        AnsiConsole.Write(calendar);

        return calendar;
    }
}