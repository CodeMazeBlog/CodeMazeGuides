using HowToImplementIDisposableInterface.DisposePattern;

namespace HowToImplementIDisposableInterface.Basic;

public sealed class MyClass : IDisposable
{
    // This field is a flag that indicates whether this object has been disposed.
    private bool _disposed = false;

    // This field is disposable, so this class must (also) implement the IDisposable interface.
    private readonly IManagedResource _managedResource;

    public MyClass(IManagedResource managedResource)
    {
        _managedResource = managedResource;
    }

    public void DoSomething()
    {
        // If this object has been disposed, throw an exception.
        if (_disposed)
        {
            throw new ObjectDisposedException(nameof(MyParentClass));
        }

        Console.WriteLine($"Called {nameof(MyClass)}.{nameof(DoSomething)}");
    }

    public void Dispose()
    {
        Console.WriteLine($"Called {nameof(MyClass)}.{nameof(Dispose)}");

        // If this object has already been disposed, exit early, since we don't
        // need to dispose of resources twice.
        if (_disposed)
        {
            return;
        }

        // Dispose of managed resources.
        _managedResource.Dispose();

        // Mark this object as disposed.
        _disposed = true;
    }
}
