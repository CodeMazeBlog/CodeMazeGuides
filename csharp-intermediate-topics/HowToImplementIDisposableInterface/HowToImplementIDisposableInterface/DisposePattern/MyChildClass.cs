namespace HowToImplementIDisposableInterface.DisposePattern;

public class MyChildClass : MyParentClass
{
    // Child class can have its own flag that indicates whether this object has been disposed.
    private bool _disposed = false;

    // Child class can have its own managed resources, that need to be disposed of.
    private readonly IManagedResource _childManagedResource;

    public MyChildClass(IManagedResource parentManagedResource, IManagedResource childManagedResource) : base(parentManagedResource)
    {
        _childManagedResource = childManagedResource;
    }

    protected override void Dispose(bool disposing)
    {
        Console.WriteLine($"Called {nameof(MyChildClass)}.{nameof(Dispose)}");

        // If this object has already been disposed, exit early, since we don't
        // need to dispose of resources twice.
        if (_disposed)
        {
            return;
        }

        if (disposing)
        {
            // Dispose of managed resources owned by this class.
            _childManagedResource.Dispose();
        }

        // Mark child object as disposed.
        _disposed = true;

        // Dispose of managed resources owned by the parent class.
        base.Dispose(disposing);
    }
}