namespace ConversionsInCSharp;

public class Note : IConvertible
{
    private readonly char _tone;
    private static readonly char[] _tones = ['A', 'B', 'C', 'D', 'E', 'F', 'G'];

    public Note(char tone) => _tone = tone;

    public TypeCode GetTypeCode() => TypeCode.Object;

    public bool ToBoolean(IFormatProvider? provider) => _tones.Contains(_tone);

    public byte ToByte(IFormatProvider? provider) => Convert.ToByte(Array.FindIndex(_tones, t => t == _tone) + 1);

    public char ToChar(IFormatProvider? provider) => _tone;

    public DateTime ToDateTime(IFormatProvider? provider)
    {
        throw new InvalidCastException();
    }

    public decimal ToDecimal(IFormatProvider? provider) => Convert.ToDecimal(Array.FindIndex(_tones, t => t == _tone) + 1);

    public double ToDouble(IFormatProvider? provider) => Convert.ToDouble(Array.FindIndex(_tones, t => t == _tone) + 1);
    
    public short ToInt16(IFormatProvider? provider) => Convert.ToInt16(Array.FindIndex(_tones, t => t == _tone) + 1);
    
    public int ToInt32(IFormatProvider? provider) => Convert.ToInt32(Array.FindIndex(_tones, t => t == _tone) + 1);
    
    public long ToInt64(IFormatProvider? provider) => Convert.ToInt64(Array.FindIndex(_tones, t => t == _tone) + 1);
    
    public sbyte ToSByte(IFormatProvider? provider) => Convert.ToSByte(Array.FindIndex(_tones, t => t == _tone) + 1);
    
    public float ToSingle(IFormatProvider? provider) => Convert.ToSingle(Array.FindIndex(_tones, t => t == _tone) + 1);
    
    public string ToString(IFormatProvider? provider) => _tone.ToString();

    public object ToType(Type conversionType, IFormatProvider? provider) => Convert.ChangeType(Array.FindIndex(_tones, t => t == _tone) + 1, conversionType);
    
    public ushort ToUInt16(IFormatProvider? provider) => Convert.ToUInt16(Array.FindIndex(_tones, t => t == _tone) + 1);
    
    public uint ToUInt32(IFormatProvider? provider) => Convert.ToUInt32(Array.FindIndex(_tones, t => t == _tone) + 1);
    
    public ulong ToUInt64(IFormatProvider? provider) => Convert.ToUInt64(Array.FindIndex(_tones, t => t == _tone) + 1);    
}