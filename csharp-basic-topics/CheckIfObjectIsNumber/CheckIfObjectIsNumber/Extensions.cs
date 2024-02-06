namespace CheckIfObjectIsNumber
{
    public static class Extensions
    {
        public static bool IsNumber(this object value)
        {
            return value is sbyte
                    || value is byte
                    || value is short
                    || value is ushort
                    || value is int
                    || value is uint
                    || value is long
                    || value is ulong
                    || value is Int128
                    || value is UInt128
                    || value is nint
                    || value is nuint
                    || value is Half
                    || value is float
                    || value is double
                    || value is decimal;
        }
    }
}
