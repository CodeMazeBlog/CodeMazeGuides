using QRCoder;

namespace QRCodeGeneratorWebSample;

public class QrCodesDb
{
    private readonly Dictionary<string, byte[]> _qrCodes = [];

    public void Add(string key, QRCodeData data)
    {
        if (!_qrCodes.ContainsKey(key))
        {
            _qrCodes.Add(key, data.GetRawData(QRCodeData.Compression.Uncompressed));
        }
    }

    public byte[]? Get(string key)
    {
        _qrCodes.TryGetValue(key, out var value);

        return value;
    }
}
