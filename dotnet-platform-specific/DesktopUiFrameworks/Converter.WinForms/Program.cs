using Converter.Core;

namespace Converter.WinForms;

internal static class Program
{
    [STAThread]
    private static void Main(string[] args)
    {
        ApplicationConfiguration.Initialize();
        Application.SetColorMode(SystemColorMode.System);

        Form form = args.Contains("--classic")
            ? new ClassicForm()
            : new BoundForm(new ConverterViewModel());

        Application.Run(form);
    }
}
