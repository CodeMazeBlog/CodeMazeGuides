namespace GrpcVsRest.Benchmarks;

public sealed class ByteCounter
{
    private long _sent;
    private long _received;
    private int _connections;

    public long Sent => Interlocked.Read(ref _sent);
    public long Received => Interlocked.Read(ref _received);
    public int Connections => Volatile.Read(ref _connections);

    public void AddConnection() => Interlocked.Increment(ref _connections);
    public void AddSent(int count) => Interlocked.Add(ref _sent, count);
    public void AddReceived(int count) => Interlocked.Add(ref _received, count);

    public void Reset()
    {
        Interlocked.Exchange(ref _sent, 0);
        Interlocked.Exchange(ref _received, 0);
    }
}

// Wraps the socket stream and counts the bytes HttpClient writes and reads:
// request and response headers, HTTP/2 frames and bodies (TCP/IP headers are not included).
public sealed class CountingStream(Stream inner, ByteCounter counter) : Stream
{
    public override bool CanRead => inner.CanRead;
    public override bool CanSeek => false;
    public override bool CanWrite => inner.CanWrite;
    public override long Length => throw new NotSupportedException();
    public override long Position
    {
        get => throw new NotSupportedException();
        set => throw new NotSupportedException();
    }

    public override int Read(byte[] buffer, int offset, int count)
    {
        var read = inner.Read(buffer, offset, count);
        counter.AddReceived(read);
        return read;
    }

    public override async ValueTask<int> ReadAsync(Memory<byte> buffer, CancellationToken cancellationToken = default)
    {
        var read = await inner.ReadAsync(buffer, cancellationToken);
        counter.AddReceived(read);
        return read;
    }

    public override Task<int> ReadAsync(byte[] buffer, int offset, int count, CancellationToken cancellationToken) =>
        ReadAsync(buffer.AsMemory(offset, count), cancellationToken).AsTask();

    public override void Write(byte[] buffer, int offset, int count)
    {
        inner.Write(buffer, offset, count);
        counter.AddSent(count);
    }

    public override async ValueTask WriteAsync(ReadOnlyMemory<byte> buffer, CancellationToken cancellationToken = default)
    {
        await inner.WriteAsync(buffer, cancellationToken);
        counter.AddSent(buffer.Length);
    }

    public override Task WriteAsync(byte[] buffer, int offset, int count, CancellationToken cancellationToken) =>
        WriteAsync(buffer.AsMemory(offset, count), cancellationToken).AsTask();

    public override void Flush() => inner.Flush();
    public override Task FlushAsync(CancellationToken cancellationToken) => inner.FlushAsync(cancellationToken);
    public override long Seek(long offset, SeekOrigin origin) => throw new NotSupportedException();
    public override void SetLength(long value) => throw new NotSupportedException();

    protected override void Dispose(bool disposing)
    {
        if (disposing)
        {
            inner.Dispose();
        }

        base.Dispose(disposing);
    }
}
