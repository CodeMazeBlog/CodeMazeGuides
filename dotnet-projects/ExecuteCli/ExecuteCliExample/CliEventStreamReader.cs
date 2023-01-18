namespace ExecuteCliExample;

public delegate void OnChunkStreamHandler(ArraySegment<char> line);

public class CliEventStreamReader
{
    public CliEventStreamReader(StreamReader streamReader)
    {
        ArgumentNullException.ThrowIfNull(streamReader);
        _streamReader = streamReader;
        Task.Factory.StartNew(StartListening);
    }

    public event OnChunkStreamHandler? OnChunkReceived;
    private readonly StreamReader _streamReader;

    private async Task StartListening()
    {
        int bufferSize = 8 * 1024;
        var buffer = new char[bufferSize];

        while (true)
        {
            var chunkLength = await _streamReader.ReadAsync(buffer, 0, buffer.Length);

            if (chunkLength == 0)
            {
                break;
            }

            OnChunk(new ArraySegment<char>(buffer, 0, chunkLength));
        }
    }

    private void OnChunk(ArraySegment<char> chunk)
    {
        OnChunkReceived?.Invoke(chunk);
    }
}