using System.Security.Cryptography;

namespace App;

public static class CryptographicHelpers
{
   public static byte[] GenerateSecureRandomKey(int bytesCount) => RandomNumberGenerator.GetBytes(bytesCount);
   
   public static int GenerateSecureRandomInteger(int minValue, int maxValue) => RandomNumberGenerator.GetInt32(minValue, maxValue);
   
   public static int GenerateGeneralRandomInteger(int minValue, int maxValue) => Random.Shared.Next(minValue, maxValue);
}
