namespace ActionAndFuncDelegatesInCSharp;

public class FileHandler
{
    private readonly IConsole _console;
    private bool _ret;

    public FileHandler(IFileReceiver fileReceiver, IConsole console)
    {
        _console = console;
        fileReceiver.FileReceivedAction += ProcessFileContentAction;
        fileReceiver.FileReceivedFunc += ProcessFileContentFunc;
    }

    public void Process(string fileContent, Func<int, bool> func)
    {
        int value = int.Parse(fileContent);

        _console.Output(func(value) ? "Success!" : "Failure!");
    }

    private void ProcessFileContentAction(string fileContent) =>
        _console.Output($"Processing file content in action method: '{fileContent}'");

    private bool ProcessFileContentFunc(string fileContent)
    {
        _ret = !_ret;
        _console.Output($"Processing file content in func method: '{fileContent}'");
        
        return(_ret);
    }
}