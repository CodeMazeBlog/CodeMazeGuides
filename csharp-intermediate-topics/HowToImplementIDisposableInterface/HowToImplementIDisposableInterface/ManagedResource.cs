namespace HowToImplementIDisposableInterface;

public class ManagedResource : IManagedResource
{
    public void Dispose()
    {
        Console.WriteLine($"Called {nameof(ManagedResource)}.{nameof(Dispose)}");
    }
}