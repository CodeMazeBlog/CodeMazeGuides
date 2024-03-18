using Microsoft.Extensions.ObjectPool;
namespace Api;

public class MemoryStreamPooledObjectPolicy : IPooledObjectPolicy<MemoryStream>
{
    public MemoryStream Create()
    {
        return new MemoryStream();
    }

    public bool Return(MemoryStream stream)
    {
        stream.SetLength(0);
        return true;
    }
}