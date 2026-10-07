namespace ExecutingPowerShellScript;

public record PowerShellResult(int ExitCode, string Output, string Error);
