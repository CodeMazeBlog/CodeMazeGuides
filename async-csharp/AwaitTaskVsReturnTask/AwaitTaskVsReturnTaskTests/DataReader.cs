using System;
using System.Threading.Tasks;

namespace AwaitTaskVsReturnTaskTests;

public class DataReader: IDisposable
{
    private bool _disposeInvoked = false;

    public void Dispose()
    {
        _disposeInvoked = true;
        GC.SuppressFinalize(this);
    }

    public async Task<string> ReadAsync()
    {
        await Task.Delay(10);

        return _disposeInvoked  ? "Dispose invoked before reading completed" : "Dispose invoked after reading completed";
    }
}