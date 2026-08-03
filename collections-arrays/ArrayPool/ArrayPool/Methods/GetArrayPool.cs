using System.Buffers;

namespace ArrayPool;

public partial class Methods
{
    public static ArrayPool<T> GetDefaultArrayPool<T>() => ArrayPool<T>.Shared;
}