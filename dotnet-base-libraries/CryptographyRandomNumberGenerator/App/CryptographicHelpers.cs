using System.Security.Cryptography;

namespace App;

public static class CryptographicHelpers
{
    public static byte[] GenerateRandomKey(int bytesCount)
    {
        return RandomNumberGenerator.GetBytes(bytesCount);
    }

    public static int GenerateRandomInteger(int minValue, int maxValue)
    {
        return RandomNumberGenerator.GetInt32(minValue, maxValue);
    }
}