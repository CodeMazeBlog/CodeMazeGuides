using System.Security.Cryptography;

namespace App;

public static class CryptographicHelpers
{
    private static readonly Random PseudoRandomNumberGenerator = new(10);
    
    public static byte[] GenerateRandomKey(int bytesCount) => RandomNumberGenerator.GetBytes(bytesCount);
    
    public static int GenerateRandomInteger(int minValue, int maxValue) => RandomNumberGenerator.GetInt32(minValue, maxValue);
    
    public static int GeneratePseudoRandom(int minValue, int maxValue) => PseudoRandomNumberGenerator.Next(minValue, maxValue);
}