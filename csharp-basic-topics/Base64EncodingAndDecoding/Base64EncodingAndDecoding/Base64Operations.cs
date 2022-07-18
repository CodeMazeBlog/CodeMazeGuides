using System.Text;

namespace Base64EncodingAndDecoding;

public class Base64Operations
{
    public string Base64Encoding(string text, bool AddLineBreaks = false)
    {
        var textBytes = Encoding.UTF8.GetBytes(text);
        return !AddLineBreaks ? Convert.ToBase64String(textBytes) :
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
}

