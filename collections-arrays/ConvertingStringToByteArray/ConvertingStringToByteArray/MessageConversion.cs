using System.Text;

namespace ConvertingStringToByteArray;

public static class MessageConversion
{
    public static byte[] ConvertStringToUTF8Bytes(string message)
    {
        return Encoding.UTF8.GetBytes(message);
    }

    public static byte[] ConvertStringToByteArrayUsingCasting(string message)
    {
        var byteArray = new byte[message.Length];

        for (int i = 0; i < message.Length; i++)
        {
            byteArray[i] = (byte)message[i];
        }

        return byteArray;
    }

    public static byte[] ConvertStringToByteArrayUsingConvertToByte(string message)
    {
        var byteArray = new byte[message.Length];

        for (int i = 0; i < message.Length; i++)
        {
            byteArray[i] = Convert.ToByte(message[i]);
        }

        return byteArray;
    }

    public static byte[] ConvertStringToByteArrayUsingEncoding(string message)
    {
        var encoding = Encoding.GetEncoding("ISO-8859-1");
        var byteCount = encoding.GetByteCount(message);
        var byteArray = new byte[byteCount];

        encoding.GetBytes(message, byteArray);

        return byteArray;
    }
}