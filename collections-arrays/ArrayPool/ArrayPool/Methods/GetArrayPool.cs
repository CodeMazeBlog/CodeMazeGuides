using System.Buffers;

namespace ArrayPool;

public partial class Methods
{
    public static ArrayPool<T> GetDefaultArrayPool<T>()
    {
        var arrayPool = ArrayPool<T>.Shared;

        return arrayPool;
    }
}