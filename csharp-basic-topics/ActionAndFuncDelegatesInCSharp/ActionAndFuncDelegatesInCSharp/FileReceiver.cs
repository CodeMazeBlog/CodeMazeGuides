using System.ComponentModel;

namespace ActionAndFuncDelegatesInCSharp;

public interface IFileReceiver
{
    Action<string> FileReceivedAction { get; set; }
    Func<string, bool> FileReceivedFunc { get; set; }
    void Start();
}

class FileReceiver : IFileReceiver
{
    private BackgroundWorker _worker;
    
    public Action<string> FileReceivedAction { get; set; }
    public Func<string, bool> FileReceivedFunc { get; set; }

    public void Start()
    {
        _worker = new();
        _worker.DoWork += TextFileReceived;
        _worker.RunWorkerAsync();
    }

    private void TextFileReceived(object _, DoWorkEventArgs __)
    {
        int index = 1;

        while(true)
        {
            if(FileReceivedAction != null)
            {
                FileReceivedAction($"File content {index} handled by action");
            }

            if(FileReceivedFunc != null)
            {
                System.Console.WriteLine(FileReceivedFunc($"File content {index++} handled by func"));
            }
            Thread.Sleep(2000);
        }
    }
}