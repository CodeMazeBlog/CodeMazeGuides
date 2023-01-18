using CliWrap;
using CliWrap.Buffered;
using CliWrap.EventStream;

namespace ExecuteCliExample;

public delegate void OnStart(int processId);
public delegate void OnExit(int exitCode);
public delegate void OnTextStreamHandler(string text);

public class DotnetCliWrap
{
    public event OnTextStreamHandler? OnStdOutput;
    public event OnTextStreamHandler? OnStdErr;
    public event OnStart? OnStart;
    public event OnExit? OnExit;

    public async Task<Version> GetVersion()
    {
        BufferedCommandResult result = await Cli.Wrap("dotnet")
                            .WithArguments("--version")
                            .ExecuteBufferedAsync();

        return Version.Parse(result.StandardOutput);
    }

    public async Task<bool> CreateNewConsoleProject(string projectName, string outputDir)
    {
        var result = await Cli.Wrap("dotnet")
                        .WithArguments(new List<string>
                        {
                            "new",
                            "console",
                            "--name",
                            projectName,
                            "--output",
                            outputDir
                        })
                        .WithStandardOutputPipe(PipeTarget.ToDelegate(Console.WriteLine))
                        .WithStandardErrorPipe(PipeTarget.ToDelegate(Console.WriteLine))
                        .WithValidation(CommandResultValidation.None)
                        .ExecuteAsync();

        return result.ExitCode == 0;
    }

    public async Task ListProjects()
    {
        var cmd = Cli.Wrap("dotnet").WithArguments("new list");

        await foreach (var cmdEvent in cmd.ListenAsync())
        {
            switch (cmdEvent)
            {
                case StartedCommandEvent started:
                    OnStart?.Invoke(started.ProcessId);
                    break;
                case StandardOutputCommandEvent stdOut:
                    OnStdOutput?.Invoke(stdOut.Text);
                    break;
                case StandardErrorCommandEvent stdErr:
                    OnStdErr?.Invoke(stdErr.Text);
                    break;
                case ExitedCommandEvent exited:
                    OnExit?.Invoke(exited.ExitCode);
                    break;
            }
        }
    }

    public async Task<(int exitCode, string? error)> RunInvalidCommand()
    {
        BufferedCommandResult result = await Cli.Wrap("dotnet")
                    .WithArguments("invalid command")
                    .WithValidation(CommandResultValidation.None)
                    .ExecuteBufferedAsync();

        return (result.ExitCode, result.StandardError);
    }
}