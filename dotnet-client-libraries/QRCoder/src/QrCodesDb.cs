using QRCoder;

namespace QRCodeGeneratorWebSample;

public class QrCodesDb
{
    private readonly Dictionary<string, byte[]> _qrCodes;

    public QrCodesDb()
    {
        _qrCodes = [];
    }

    public void Add(string key, QRCodeData data)
    {
        _qrCodes.Add(key, data.GetRawData(QRCodeData.Compression.Uncompressed));
    }

    public byte[] Get(string key)
    {
        return _qrCodes[key];
    }
}
