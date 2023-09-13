using System.Buffers;
using System.Text;

namespace FastestWayToReadATextFileInCsharp;

public class WaysToReadATextFileInCsharp
{
    private readonly string _sampleFilePath;

    public WaysToReadATextFileInCsharp(string sampleFilePath)
    {
        _sampleFilePath = sampleFilePath;
    }

    public string UseFileReadAllLines()
    {
        var stringBuilder = new StringBuilder();

        foreach (var line in File.ReadAllLines(_sampleFilePath))
        {
            stringBuilder.AppendLine(line);
        }
        stringBuilder.Length -= Environment.NewLine.Length;

        return stringBuilder.ToString();
    }

    public string UseFileReadAllText() => File.ReadAllText(_sampleFilePath);

    public string UseFileReadLines()
    {
        var stringBuilder = new StringBuilder();

        foreach (var line in File.ReadLines(_sampleFilePath))
        {
            stringBuilder.AppendLine(line);
        }
        stringBuilder.Length -= Environment.NewLine.Length;

        return stringBuilder.ToString();
    }

    public string UseStreamReaderReadLine()
    {
        using var streamReader = new StreamReader(_sampleFilePath);
        var stringBuilder = new StringBuilder();

        while (streamReader.ReadLine() is { } fileLine)
        {
            stringBuilder.AppendLine(fileLine);
        }
        stringBuilder.Length -= Environment.NewLine.Length;

        return stringBuilder.ToString();
    }

    public string UseStreamReaderReadToEnd()
    {
        using var streamReader = new StreamReader(_sampleFilePath);

        return streamReader.ReadToEnd();
    }

    public string UseStreamReaderReadBlock()
    {
        using var streamReader = new StreamReader(_sampleFilePath);
        var buffer = new char[4096];
        int numberRead;
        var stringBuilder = new StringBuilder();

        while ((numberRead = streamReader.ReadBlock(buffer, 0, buffer.Length)) > 0)
        {
            stringBuilder.Append(buffer[..numberRead]);
        }

        return stringBuilder.ToString();
    }

    public string UseStreamReaderReadBlockWithSpan()
    {
        using var streamReader = new StreamReader(_sampleFilePath);
        var buffer = new char[4096].AsSpan();
        int numberRead;
        var stringBuilder = new StringBuilder();

        while ((numberRead = streamReader.ReadBlock(buffer)) > 0)
        {
            stringBuilder.Append(buffer[..numberRead]);
        }

        return stringBuilder.ToString();
    }

    public string UseStreamReaderReadBlockWithArrayPool()
    {
        using var streamReader = new StreamReader(_sampleFilePath);
        var buffer = ArrayPool<char>.Shared.Rent(4096);
        int numberRead;
        var stringBuilder = new StringBuilder();

        while ((numberRead = streamReader.ReadBlock(buffer, 0, buffer.Length)) > 0)
        {
            stringBuilder.Append(buffer[..numberRead]);
        }

        ArrayPool<char>.Shared.Return(buffer);

        return stringBuilder.ToString();
    }

    public string UseBufferedStreamObject()
    {
        var stringBuilder = new StringBuilder();

        using var fileStream = new FileStream(_sampleFilePath,
                                    FileMode.Open,
                                    FileAccess.Read,
                                    FileShare.Read);
        using var bufferedStream = new BufferedStream(fileStream);
        using var streamReader = new StreamReader(bufferedStream);

        while (streamReader.ReadLine() is { } fileLine)
        {
            stringBuilder.AppendLine(fileLine);
        }
        stringBuilder.Length -= Environment.NewLine.Length;

        return stringBuilder.ToString();
    }

    public string UseBufferedStreamObjectWithNoFileStreamBuffer()
    {
        var stringBuilder = new StringBuilder();

        using var fileStream = new FileStream(_sampleFilePath,
                                    FileMode.Open,
                                    FileAccess.Read,
                                    FileShare.Read,
                                    0);
        using var bufferedStream = new BufferedStream(fileStream);
        using var streamReader = new StreamReader(bufferedStream);

        while (streamReader.ReadLine() is { } fileLine)
        {
            stringBuilder.AppendLine(fileLine);
        }
        stringBuilder.Length -= Environment.NewLine.Length;

        return stringBuilder.ToString();
    }
}