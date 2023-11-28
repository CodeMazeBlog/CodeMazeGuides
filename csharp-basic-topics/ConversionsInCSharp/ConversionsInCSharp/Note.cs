namespace ConversionsInCSharp;

public class Note : IConvertible
{
    readonly char tone;
    readonly char[] tones = ['A', 'B', 'C', 'D', 'E', 'F', 'G'];

    public Note(char tone)
    {
        this.tone = tone;
    }

    public TypeCode GetTypeCode()
    {
        return TypeCode.Object;
    }

    public bool ToBoolean(IFormatProvider? provider)
    {
        return tones.Contains(tone);
    }

    public byte ToByte(IFormatProvider? provider)
    {
        return Convert.ToByte(Array.FindIndex(tones, t => t == tone) + 1);
    }

    public char ToChar(IFormatProvider? provider)
    {
        return tone;
    }

    public DateTime ToDateTime(IFormatProvider? provider)
    {
        throw new InvalidCastException();
    }

    public decimal ToDecimal(IFormatProvider? provider)
    {
        return Convert.ToDecimal(Array.FindIndex(tones, t => t == tone) + 1);
    }

    public double ToDouble(IFormatProvider? provider)
    {
        return Convert.ToDouble(Array.FindIndex(tones, t => t == tone) + 1);
    }

    public short ToInt16(IFormatProvider? provider)
    {
        return Convert.ToInt16(Array.FindIndex(tones, t => t == tone) + 1);
    }

    public int ToInt32(IFormatProvider? provider)
    {
        return Convert.ToInt32(Array.FindIndex(tones, t => t == tone) + 1);
    }

    public long ToInt64(IFormatProvider? provider)
    {
        return Convert.ToInt64(Array.FindIndex(tones, t => t == tone) + 1);
    }

    public sbyte ToSByte(IFormatProvider? provider)
    {
        return Convert.ToSByte(Array.FindIndex(tones, t => t == tone) + 1);
    }

    public float ToSingle(IFormatProvider? provider)
    {
        return Convert.ToSingle(Array.FindIndex(tones, t => t == tone) + 1);
    }

    public string ToString(IFormatProvider? provider)
    {
        return tone.ToString();
    }

    public object ToType(Type conversionType, IFormatProvider? provider)
    {
        return Convert.ChangeType(Array.FindIndex(tones, t => t == tone) + 1, conversionType);
    }

    public ushort ToUInt16(IFormatProvider? provider)
    {
        return Convert.ToUInt16(Array.FindIndex(tones, t => t == tone) + 1);
    }

    public uint ToUInt32(IFormatProvider? provider)
    {
        return Convert.ToUInt32(Array.FindIndex(tones, t => t == tone) + 1);
    }

    public ulong ToUInt64(IFormatProvider? provider)
    {
        return Convert.ToUInt64(Array.FindIndex(tones, t => t == tone) + 1);
    }
}
