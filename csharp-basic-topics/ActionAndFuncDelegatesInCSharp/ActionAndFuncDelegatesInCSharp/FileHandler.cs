namespace ActionAndFuncDelegatesInCSharp;

class FileHandler
{
    private bool _ret;

    public FileHandler(FileReceiver fileReceiver)
    {
        fileReceiver.FileReceivedAction += ProcessFileContentAction;
        fileReceiver.FileReceivedFunc += ProcessFileContentFunc;
    }

    public void Process(string fileContent, Func<int, bool> func)
    {
        int value = int.Parse(fileContent);

        Console.WriteLine(func(value) ? "Success!" : "Failure!");
    }

    private void ProcessFileContentAction(string fileContent) =>
        Console.WriteLine($"Processing file content in action method: '{fileContent}'");

    private bool ProcessFileContentFunc(string fileContent)
    {
        _ret = !_ret;
        Console.WriteLine($"Processing file content in func method: '{fileContent}'");
        return(_ret);
    }
}