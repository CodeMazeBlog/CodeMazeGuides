namespace ExecuteCliExample;

public delegate void OnChunkStreamHandler(string chunk);

public class CliEventStreamer
{
    public CliEventStreamer(StreamReader streamReader)
    {
        ArgumentNullException.ThrowIfNull(streamReader);
        _streamReader = streamReader;
        Task.Factory.StartNew(Start);
    }

    public event OnChunkStreamHandler? OnChunkReceived;
    private readonly StreamReader _streamReader;

    private async Task Start()
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

            OnChunk(new string(buffer, 0, chunkLength));
        }
    }

    private void OnChunk(string chunk)
    {
        OnChunkReceived?.Invoke(chunk);
    }
}