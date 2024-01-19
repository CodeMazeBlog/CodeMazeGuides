using AngleSharp.Io.Dom;

namespace ParsingHtmlWithAngleSharp;

public class FileEntry : IFile
{
    private readonly string _fileName;
    private readonly Stream _content;
    private readonly string _type;
    private readonly DateTime _modified;

    public FileEntry(string fileName, string type, Stream content)
    {
        _fileName = fileName;
        _type = type;
        _content = content;
        _modified = DateTime.Now;
    }

    public Stream Body => _content;

    public bool IsClosed => _content.CanRead == false;

    public DateTime LastModified => _modified;

    public int Length => (int)_content.Length;

    public string Name => _fileName;

    public string Type => _type;

    public void Close()
    {
        _content.Close();
    }

    public void Dispose() => _content.Dispose();

    public IBlob Slice(int start = 0, int end = int.MaxValue, string contentType = null)
    {
        var ms = new MemoryStream();
        _content.Position = start;
        var buffer = new byte[Math.Max(0, Math.Min(end, _content.Length) - start)];

        _content.Read(buffer, 0, buffer.Length);

        ms.Write(buffer, 0, buffer.Length);
        _content.Position = 0;
        return new FileEntry(_fileName, _type, ms);
    }
}