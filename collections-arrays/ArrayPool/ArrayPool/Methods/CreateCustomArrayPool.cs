using System.Buffers;

namespace ArrayPool;

public static partial class Methods
{
    public static ArrayPool<T> CreateArrayPool<T>(int maxArrayLength, int maxArraysPerBucket)
    {
        var arrayPool = ArrayPool<T>.Create(maxArrayLength, maxArraysPerBucket);

        return arrayPool;
    }
}