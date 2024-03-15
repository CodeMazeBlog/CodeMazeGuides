namespace HowToImplementIDisposableInterface.DisposePattern;

public class MyChildClass : MyParentClass
{
    private bool _disposed = false;

    private readonly IManagedResource _childManagedResource;

    public MyChildClass(IManagedResource parentManagedResource, IManagedResource childManagedResource) : base(parentManagedResource)
    {
        _childManagedResource = childManagedResource;
    }

    protected override void Dispose(bool disposing)
    {
        Console.WriteLine($"Called {nameof(MyChildClass)}.{nameof(Dispose)}");

        if (_disposed)
        {
            return;
        }

        if (disposing)
        {
            _childManagedResource.Dispose();
        }

        _disposed = true;

        base.Dispose(disposing);
    }
}