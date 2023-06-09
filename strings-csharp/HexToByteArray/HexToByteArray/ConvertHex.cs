namespace HexToByteArray
{
    public class ConvertHex
    {
        public byte[] FromHexString(string hex)
        {
            try
            {
                return Convert.FromHexString(hex);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public byte[] FromHexStringAlternative(string hex)
        {
            try
            {
                int length = hex.Length;
                byte[] bytes = new byte[length / 2];
                for (int i = 0; i < length; i += 2)
                    bytes[i / 2] = Convert.ToByte(hex.Substring(i, 2), 16);

                return bytes;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
