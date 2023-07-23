namespace PermutationsOfAString
{
    public static class ByteArray2StringConverter
    {
        public static string BytesToString(byte[] number)
        {
            return string.Join("", number);
        }

        public static List<string> ListOfBytesToListOfString(List<byte[]> number)
        {
            return number.Select(BytesToString).ToList();
        }
    }
}
