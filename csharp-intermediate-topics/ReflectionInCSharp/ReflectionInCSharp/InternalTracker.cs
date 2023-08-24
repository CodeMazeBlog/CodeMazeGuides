namespace ReflectionInCSharp;

public class InternalTracker
{
    private static int _instanceCount = 0;

    private InternalTracker() => Sequence = ++_instanceCount;

    public int Sequence { get; }
}