namespace AsynchronousProgrammingPatterns.Providers;

public class ApmUserProvider
{
    private readonly FileStream _fileStream;
    private readonly byte[] _buffer;

    public ApmUserProvider()
    {
        _buffer = new byte[1024];
        _fileStream = File.OpenRead("user.txt");
    }

    public IAsyncResult BeginGetUser(int userId, AsyncCallback callback, object state)
    {
        return _fileStream.BeginRead(_buffer, 0, 1024, callback, state);
    }

    public byte[] EndGetUser(IAsyncResult asyncResult)
    {
        _fileStream.EndRead(asyncResult);
        _fileStream.Close();

        return _buffer;
    }
}
