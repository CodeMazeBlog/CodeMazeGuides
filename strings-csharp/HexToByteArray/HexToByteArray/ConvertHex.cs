namespace HexToByteArray
{
    public static class ConvertHex
    {
        public static byte[] FromHexString(string hex)
        {
            return Convert.FromHexString(hex);
        }

        public static byte[] FromHexStringAlternative(ReadOnlySpan<char> hex)
        {
            int length = hex.Length;
            byte[] bytes = GC.AllocateUninitializedArray<byte>(length >> 1);
            for (int i = 0; i < length; i += 2)
                bytes[i >> 1] = byte.Parse(hex.Slice(i, 2),
                    System.Globalization.NumberStyles.HexNumber);
            return bytes;
        }
    }
}
