using Spectre.Console;
using UsingSpectreDotConsole;

SpectreConsoleBasicUsages.SetTextColor();
SpectreConsoleBasicUsages.SetBackgroundColor();
SpectreConsoleBasicUsages.EscapeFormatCharacters();
SpectreConsoleBasicUsages.BeautifyStudentsDataJson();
SpectreConsoleBasicUsages.PrettyPrintCalendar();

SpectreConsoleOtherUsages.CreateStudentTable();
SpectreConsoleOtherUsages.WriteReadableException();
SpectreConsoleOtherUsages.CreateHostelBarChart();
SpectreConsoleOtherUsages.DisplayProgress();
SpectreConsoleOtherUsages.DisplayFiglet();

if (AnsiConsole.Profile.Capabilities.Interactive)
{
    SpectreConsoleOtherUsages.PromptStudent();
}
