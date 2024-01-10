namespace HowToImplementIDisposableInterface.DisposePattern;

public class MyChildClass : MyParentClass
{
    // Child class can have its own managed resources, that need to be disposed of.
    private readonly IManagedResource _childManagedResource;

    public MyChildClass(IManagedResource parentManagedResource, IManagedResource childManagedResource) : base(parentManagedResource)
    {
        _childManagedResource = childManagedResource;
    }

    protected override void Dispose(bool disposing)
    {
        Console.WriteLine($"Called {nameof(MyChildClass)}.{nameof(Dispose)}");

        // Dispose of managed resources owned by this class.
        _childManagedResource.Dispose();

        // Dispose of managed resources owned by the parent class.
        base.Dispose(disposing);
    }
}