using System.Collections.Concurrent;
using QRCoder;

namespace QRCodeGeneratorWebSample;

public class QrCodesDb
{
    private readonly ConcurrentDictionary<string, byte[]> _qrCodes = new();

    public void Add(string key, QRCodeData data)
    {
        _qrCodes.TryAdd(key, data.GetRawData(QRCodeData.Compression.Uncompressed));
    }

    public byte[]? Get(string key)
    {
        _qrCodes.TryGetValue(key, out var value);

        return value;
    }
}
