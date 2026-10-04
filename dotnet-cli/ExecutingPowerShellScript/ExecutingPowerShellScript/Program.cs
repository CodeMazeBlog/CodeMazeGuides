using ExecutingPowerShellScript;

var scriptPath = Path.Combine(AppContext.BaseDirectory, "echo.ps1");

var processStart = new ProcessStart();
var scriptResult = await processStart.ExecuteScriptAsync(scriptPath);
Console.WriteLine(scriptResult.Output);

var commandResult = await processStart.ExecuteCommandAsync("echo 'I am invoked using echo command!'");
Console.WriteLine(commandResult.Output);

var powerShellClass = new PowerShellClass();
Console.WriteLine(powerShellClass.ExecuteScript(scriptPath));
Console.WriteLine(powerShellClass.ExecuteCommand("Get-Date"));

// notepad is a Windows example; on macOS or Linux use open or xdg-open
Console.WriteLine(powerShellClass.StartProcess("notepad"));

using var customRunspace = new PSCustomRunspace();
Console.WriteLine(customRunspace.ExecuteCommand("Get-Date"));
Console.WriteLine(customRunspace.StartProcess("notepad"));
