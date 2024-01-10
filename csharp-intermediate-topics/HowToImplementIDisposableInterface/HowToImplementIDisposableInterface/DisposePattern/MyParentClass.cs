namespace HowToImplementIDisposableInterface.DisposePattern;

public class MyParentClass : IDisposable
{
    // This field is a flag that indicates whether this object has been disposed.
    private bool _disposed;

    // This field is disposable, so this class must (also) implement the IDisposable interface.
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
        // Dispose of managed resources.
        Dispose(true);

        // Use SupressFinalize in case a subclass 
        // of this type implements a finalizer.
        GC.SuppressFinalize(this);
    }

    protected virtual void Dispose(bool disposing)
    {
        Console.WriteLine($"Called {nameof(MyParentClass)}.{nameof(Dispose)}");

        // If this object has already been disposed, exit early, since we don't
        // need to dispose of resources twice.
        if (_disposed)
        {
            return;
        }

        if (disposing)
        {
            // Free managed resources here.
            _parentManagedResource.Dispose();
        }

        // Free native resources if there are any.
        // For simplicity, we'll assume there aren't any.

        // Mark this object as disposed.
        _disposed = true;
    }
}
