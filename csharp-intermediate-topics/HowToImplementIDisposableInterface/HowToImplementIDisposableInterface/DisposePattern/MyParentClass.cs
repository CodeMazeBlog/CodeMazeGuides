namespace HowToImplementIDisposableInterface.DisposePattern;

public class MyParentClass : IDisposable
{
    private bool _disposed = false;

    private readonly IManagedResource _parentManagedResource;

    public MyParentClass(IManagedResource parentManagedResource)
    {
        _parentManagedResource = parentManagedResource;
    }

    public void DoSomething()
    {
        if (_disposed)
        {
            throw new ObjectDisposedException(nameof(MyParentClass));
        }

        Console.WriteLine($"Called {nameof(MyParentClass)}.{nameof(DoSomething)}");
    }

    public void Dispose()
    {
        Dispose(true);

        GC.SuppressFinalize(this);
    }

    protected virtual void Dispose(bool disposing)
    {
        Console.WriteLine($"Called {nameof(MyParentClass)}.{nameof(Dispose)}");

        if (_disposed)
        {
            return;
        }

        if (disposing)
        {
            _parentManagedResource.Dispose();
        }

        // Free native resources if there are any.
        // For simplicity, we'll assume there aren't any.

        _disposed = true;
    }
}
