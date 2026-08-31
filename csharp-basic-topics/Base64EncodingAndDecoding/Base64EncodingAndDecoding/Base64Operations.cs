using System.Buffers.Text;
using System.Security.Cryptography;
using System.Text;

namespace Base64EncodingAndDecoding;

public class Base64Operations
{
    public string Base64Encoding(string text, bool addLineBreaks = false)
    {
        var textBytes = Encoding.UTF8.GetBytes(text);
        return !addLineBreaks ? Convert.ToBase64String(textBytes) :
            Convert.ToBase64String(textBytes, Base64FormattingOptions.InsertLineBreaks);
    }

    public string Base64Encoding(string text, int offset, int arrayLength)
    {
        var textBytes = Encoding.UTF8.GetBytes(text);
        return Convert.ToBase64String(textBytes, offset, arrayLength);
    }

    public string Base64Decoding(string base64EncodedText)
    {
        var base64EncodedBytes = Convert.FromBase64String(base64EncodedText);
        return Encoding.UTF8.GetString(base64EncodedBytes);
    }

    public string EncodeFile(string path)
    {
        return Convert.ToBase64String(File.ReadAllBytes(path));
    }

    public void DecodeToFile(string base64EncodedText, string path)
    {
        File.WriteAllBytes(path, Convert.FromBase64String(base64EncodedText));
    }

    public void EncodeStream(Stream input, Stream output)
    {
        using var transform = new ToBase64Transform();
        using var cryptoStream = new CryptoStream(output, transform, CryptoStreamMode.Write, leaveOpen: true);

        input.CopyTo(cryptoStream);
    }

    public void DecodeStream(Stream input, Stream output)
    {
        using var transform = new FromBase64Transform();
        using var cryptoStream = new CryptoStream(output, transform, CryptoStreamMode.Write, leaveOpen: true);

        input.CopyTo(cryptoStream);
    }

    public bool TryDecode(string base64EncodedText, out byte[] bytes)
    {
        var buffer = new byte[base64EncodedText.Length];

        if (Convert.TryFromBase64String(base64EncodedText, buffer, out var bytesWritten))
        {
            bytes = buffer[..bytesWritten];

            return true;
        }

        bytes = [];

        return false;
    }

    public string Base64UrlEncoding(string text)
    {
        return Base64Url.EncodeToString(Encoding.UTF8.GetBytes(text));
    }

    public string Base64UrlDecoding(string base64UrlEncodedText)
    {
        return Encoding.UTF8.GetString(Base64Url.DecodeFromChars(base64UrlEncodedText));
    }
}
