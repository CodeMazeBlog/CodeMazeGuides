using Spectre.Console;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace CreateBetterLookingConsoleAppsWithSpectreConsole;

public class SpectreConsoleOtherUsages
{
    private static readonly List<Student> _students = StudentsGenerator.GenerateStudents();

    public static Table CreateStudentTable()
    {
        var table = new Table
        {
            Title = new TableTitle("STUDENTS", "bold green")
        };

        table.AddColumns("[yellow]Id[/]", $"[{Color.Olive}]FirstName[/]", "[Fuchsia]Age[/]");

        foreach (var student in _students)
        {
            table.AddRow(student.Id.ToString(), $"[red]{student.FirstName}[/]", $"[cyan]{student.Age}[/]");
        }

        AnsiConsole.Write(table);

        return table;
    }

    public static void WriteReadableException()
    {
        try
        {
            string filePath = "nofile.txt";
            File.OpenRead(filePath);
        }
        catch (FileNotFoundException ex)
        {
            AnsiConsole.WriteException(ex,
            ExceptionFormats.ShortenPaths |
            ExceptionFormats.ShortenMethods);

        }
    }

    public static TextPrompt<int> GetAgeTextPrompt()
    {
        return new TextPrompt<int>("[green]How old are you[/]?")
                .PromptStyle("green")
                .ValidationErrorMessage("[red]That's not a valid age[/]")
                .Validate(age =>
                {
                    return age switch
                    {
                        <= 10 => ValidationResult.Error("[red]You must be above 10 years[/]"),
                        >= 123 => ValidationResult.Error("[red]You must be younger than that[/]"),
                        _ => ValidationResult.Success(),
                    };

                });
    }

    public static SelectionPrompt<string> GetHostelSelectionPrompt()
    {
        var hostels = StudentsGenerator.Hostels;

        return new SelectionPrompt<string>()
                 .Title("Choose a hostel")
                 .AddChoices(hostels);
    }

    public static Student PromptStudent()
    {
        var student = new Student
        {
            FirstName = AnsiConsole.Ask<string>("[green]What's your First Name[/]?"),
            LastName = AnsiConsole.Ask<string>("[green]What's your Last Name[/]?"),

            Age = AnsiConsole.Prompt(GetAgeTextPrompt()),

            Hostel = AnsiConsole.Prompt(GetHostelSelectionPrompt())
        };

        AnsiConsole.MarkupLine($"Alright [yellow]{student.FirstName} {student.LastName}[/], welcome!");

        return student;
    }

    public static BarChart CreateHostelBarChart()
    {
        var barChart = new BarChart()
        .Width(60)
        .Label("[orange1 bold underline]Number of Students per Hostel[/]")
        .CenterLabel();

        var hostels = StudentsGenerator.Hostels;
        var colors = new List<Color> { Color.Red, Color.Fuchsia, Color.Blue, Color.Yellow, Color.Magenta1 };

        for (int i = 0; i < hostels.Length; i++)
        {
            var hostel = hostels[i];
            var color = colors[i];
            var count = _students.Count(s => s.Hostel == hostel);
            barChart.AddItem(hostel, count, color);
        }

        AnsiConsole.Write(barChart);

        return barChart;
    }

    public static void DisplayProgress()
    {
        var incrementValue = 100 / _students.Count;

        AnsiConsole.Progress()
            .Start(ctx =>
            {
                var streamingTask = ctx.AddTask("Student Streaming");

                foreach (var student in StudentsGenerator.StreamStudentsFromDatabase())
                {
                    streamingTask.Increment(incrementValue);
                }
            });
    }

    public static FigletText DisplayFiglet()
    {
        var text = new FigletText("Beautify")
            .LeftJustified()
            .Color(Color.Orchid);

        AnsiConsole.Write(text);

        return text;
    }
}