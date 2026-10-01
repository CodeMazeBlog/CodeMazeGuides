# Visual Studio vs VS Code for .NET Developers

The sample for the Code Maze article "Visual Studio vs VS Code for .NET Developers". It holds one
minimal ASP.NET Core API, `ReportApi`, with a slow endpoint (`/report/slow`, string concatenation in
a loop) and a fast one (`/report/fast`, `StringBuilder`), and an xUnit test project,
`ReportApi.Tests`, with two tests.

## Open in Visual Studio

1. Open `VisualStudioVsVsCode.sln`.
2. Run `ReportApi`.
3. Browse to `http://localhost:5234/report/slow` and `http://localhost:5234/report/fast`.

## Open in VS Code

1. Install the C# Dev Kit extension.
2. To use Hot Reload while debugging, run "Preferences: Open User Settings (JSON)" from the Command
   Palette and add this entry. The setting is machine-scoped, so a workspace
   `.vscode/settings.json` would ignore it:

   ```json
   "csharp.experimental.debug.hotReload": true
   ```

3. Open this folder, then run and debug `ReportApi`.
4. With the API running, use the .NET diagnostic tools from the terminal while you call
   `/report/slow`:

   ```
   dnx dotnet-counters monitor -n ReportApi
   dnx dotnet-trace collect -n ReportApi --duration 00:00:00:15 -o slow.nettrace
   dnx dotnet-trace report slow.nettrace topN -n 10
   ```
