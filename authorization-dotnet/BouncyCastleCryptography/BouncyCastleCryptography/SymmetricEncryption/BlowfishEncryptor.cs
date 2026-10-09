using Org.BouncyCastle.Crypto.Digests;
using Org.BouncyCastle.Crypto.Generators;
using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.Security;
using System.Text;

namespace BouncyCastleCryptography.SymmetricEncryption;

public static class BlowfishEncryptor
{
    private const int Iterations = 600_000;

    public static byte[] BlowfishEncrypt(string input, string password, out byte[] salt, out byte[] iv)
    {
        var inputBytes = Encoding.UTF8.GetBytes(input);

        var random = new SecureRandom();
        salt = new byte[16];
        random.NextBytes(salt);
        iv = new byte[8]; // Blowfish uses an 8-byte (64-bit) IV
        random.NextBytes(iv);

        var cipher = CipherUtilities.GetCipher("Blowfish/CBC/PKCS7Padding");

        var keyParam = DeriveKey(password, salt);

        cipher.Init(true, new ParametersWithIV(keyParam, iv));

        return cipher.DoFinal(inputBytes);
    }

    public static string BlowfishDecrypt(byte[] encryptedBytes, string password, byte[] salt, byte[] iv)
    {
        var cipher = CipherUtilities.GetCipher("Blowfish/CBC/PKCS7Padding");

        var keyParam = DeriveKey(password, salt);

        cipher.Init(false, new ParametersWithIV(keyParam, iv));

        var plainBytes = cipher.DoFinal(encryptedBytes);

        return Encoding.UTF8.GetString(plainBytes);
    }

    private static KeyParameter DeriveKey(string password, byte[] salt)
    {
        // PBKDF2 with HMAC-SHA256 stretches the password and salt into a 128-bit key
        var generator = new Pkcs5S2ParametersGenerator(new Sha256Digest());
        generator.Init(Encoding.UTF8.GetBytes(password), salt, Iterations);

        return (KeyParameter)generator.GenerateDerivedParameters("Blowfish", 128);
    }
}
