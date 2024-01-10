namespace HowToImplementIDisposableInterface;

// This class emulates a managed resource that needs to be disposed of.
public class ManagedResource : IManagedResource
{
    public void Dispose()
    {
        Console.WriteLine($"Called {nameof(ManagedResource)}.{nameof(Dispose)}");
    }
}