# WPF vs WinForms vs WinUI vs Avalonia vs MAUI
## https://code-maze.com/wpf-vs-winforms/

One temperature converter, built three times on .NET 10. The same ViewModel drives a WinForms form,
a WPF window and an Avalonia window, and a test project checks the ViewModel and the Avalonia window.

| Project | Target | What it shows |
|---|---|---|
| `Converter.Core` | `net10.0` | `ConverterViewModel` and `RelayCommand`, written by hand, with no UI framework reference |
| `Converter.WinForms` | `net10.0-windows` | `ClassicForm` (logic in event handlers) and `BoundForm` (bound to the ViewModel, with a button command) |
| `Converter.Wpf` | `net10.0-windows` | `MainWindow.xaml` bound to the ViewModel, and the Fluent theme set in `App.xaml` |
| `Converter.Avalonia` | `net10.0` | The same window in Avalonia XAML, with compiled bindings through `x:DataType` |
| `Converter.Tests` | `net10.0` | ViewModel tests and one headless Avalonia window test (xUnit v3, `Avalonia.Headless`) |

## Build and test

```bash
dotnet build DesktopUiFrameworks.sln
dotnet test DesktopUiFrameworks.sln
```

The WinForms and WPF projects set `EnableWindowsTargeting`, so the solution also builds on Linux and macOS.
The tests run on any operating system. The WinForms and WPF apps run only on Windows.

## Run the apps

```bash
dotnet run --project Converter.WinForms              # the bound form
dotnet run --project Converter.WinForms -- --classic # the event-handler form
dotnet run --project Converter.Wpf
dotnet run --project Converter.Avalonia
```

Type a temperature in degrees Celsius. The Convert button turns on once the text is a number, and a click
shows the result in degrees Fahrenheit.
