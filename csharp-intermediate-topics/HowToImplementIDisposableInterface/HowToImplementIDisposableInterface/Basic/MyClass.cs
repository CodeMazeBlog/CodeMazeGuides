namespace HowToImplementIDisposableInterface.Basic;

public sealed class MyClass : IDisposable
{
    private bool _disposed = false;

    private readonly IManagedResource _managedResource;

    public MyClass(IManagedResource managedResource)
    {
        _managedResource = managedResource;
    }

    public void DoSomething()
    {
        if (_disposed)
        {
            throw new ObjectDisposedException(nameof(MyClass));
        }

        Console.WriteLine($"Called {nameof(MyClass)}.{nameof(DoSomething)}");
    }

    public void Dispose()
    {
        Console.WriteLine($"Called {nameof(MyClass)}.{nameof(Dispose)}");

        if (_disposed)
        {
            return;
        }

        _managedResource.Dispose();

        _disposed = true;
    }
}
