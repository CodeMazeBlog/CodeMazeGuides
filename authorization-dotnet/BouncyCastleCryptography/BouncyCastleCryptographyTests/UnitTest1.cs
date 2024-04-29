using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Crypto.Digests;
using Org.BouncyCastle.Security;
using Org.BouncyCastle.Crypto.Parameters;
using System.Net.Sockets;
using System.Text;
using Org.BouncyCastle.Utilities;
using Org.BouncyCastle.Crypto.Generators;
using Org.BouncyCastle.Crypto.Encodings;
using Org.BouncyCastle.Crypto.Engines;

namespace BouncyCastleCryptographyTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void GivenSecretData_WhenMd5IsUsed_ThenSecretIsHashed()
        {
            var secretValue = "This is my pasword! Dont read me!";

            var hash = Md5Hash(secretValue);

            Assert.IsNotNull(hash);
        }

        [TestMethod]
        public void GivenSecretData_WhenMd5HashingMultipleTimes_ThenResultIsDeterministic()
        {
            var secretValue = "This is my pasword! Dont read me!";

            var hash = Md5Hash(secretValue);

            var hash2 = Md5Hash(secretValue);

            CollectionAssert.AreEqual(hash, hash2);
        }

        [TestMethod]
        public void GivenSecretData_WhenShaIsUsed_ThenSecretIsHashed()
        {
            var secretValue = "This is my pasword! Dont read me!";

            var hash = ShaHash(secretValue);

            Assert.IsNotNull(hash);
        }

        [TestMethod]
        public void GivenSecretData_WhenShaHashingMultipleTimes_ThenResultIsDeterministic()
        {
            var secretValue = "This is my pasword! Dont read me!";

            var hash = ShaHash(secretValue);

            var hash2 = ShaHash(secretValue);

            CollectionAssert.AreEqual(hash, hash2);
        }

        [TestMethod]
        public void GivenSecretData_WhenAesEncrypting_ThenDataIsEncrypted()
        {
            string input = "Hello, Bouncy Castle!";

            var encryptedData = AesEncrypt(input, out byte[] iv, out byte[] key, out byte[] encryptedBytes, out var cipher);

            Assert.IsNotNull(encryptedData);
            Assert.AreNotEqual(input, encryptedData);
        }

        [TestMethod]
        public void GivenSecretData_WhenAesEncrypting_ThenDataCanBeDecrypted()
        {
            string input = "Hello, Bouncy Castle!";

            var myStr = AesEncrypt(input, out byte[] iv, out byte[] key, out byte[] encryptedBytes, out var cipher);
            //byte[] encryptedBytes = Encoding.UTF8.GetBytes(myStr);

            Assert.IsNotNull(myStr);

            //IBufferedCipher cipher = CipherUtilities.GetCipher("AES/CBC/PKCS7Padding");

            var myDecryptedStr = AesDecrypt(cipher, key, iv, encryptedBytes);

            Assert.IsNotNull(myDecryptedStr);
            Assert.AreEqual(input, myDecryptedStr);
        }

        [TestMethod]
        public void GivenSecretData_WhenTripleDesEncrypting_ThenDataIsEncrypted()
        {
            string input = "Hello, Bouncy Castle!";

            var myStr = TripleDesEncrypt(input, out byte[] iv, out byte[] key, out byte[] encryptedBytes);
            //byte[] encryptedBytes = Encoding.UTF8.GetBytes(myStr);

            Assert.IsNotNull(myStr);
        }

        [TestMethod]
        public void GivenSecretData_WhenTripleDesEncrypting_ThenDataCanBeDecrypted()
        {
            string input = "Hello, Bouncy Castle!";

            var myStr = AesEncrypt(input, out byte[] iv, out byte[] key, out byte[] encryptedBytes, out var cipher);
            //byte[] encryptedBytes = Encoding.UTF8.GetBytes(myStr);

            Assert.IsNotNull(myStr);

            //IBufferedCipher cipher = CipherUtilities.GetCipher("AES/CBC/PKCS7Padding");

            var myDecryptedStr = AesDecrypt(cipher, key, iv, encryptedBytes);

            Assert.IsNotNull(myDecryptedStr);
            Assert.AreEqual(input, myDecryptedStr);
        }

        [TestMethod]
        public void rsaEncrypt()
        {
            string input = "Hello, Bouncy Castle!";

            // Generate RSA key pair
            AsymmetricCipherKeyPair keyPair = GenerateRsaKeyPair();

            // Encrypt the input data using the public key
            byte[] encryptedBytes = RsaEncrypt(input, keyPair.Public);

            // Decrypt the encrypted data using the private key
            string decryptedString = RsaDecrypt(encryptedBytes, keyPair.Private);

            // Print the decrypted data
            Console.WriteLine("Decrypted data: " + decryptedString);

            Assert.IsNotNull(encryptedBytes);

            Assert.AreEqual(input, decryptedString);
        }

        // -------------------------------------------------------------------------------

        // SYMETRICAL -  AES and Triple DES
        public string AesEncrypt(string input, out byte[] ivBytes, out byte[] keyBytes, out byte[] encryptedBytes, out IBufferedCipher cipher)
        {
            // Convert the input string to bytes
            byte[] inputBytes = Encoding.UTF8.GetBytes(input);

            // Generate a random 128-bit key
            keyBytes = new byte[16];
            SecureRandom random = new SecureRandom();
            random.NextBytes(keyBytes);

            // Generate a random 128-bit IV (initialization vector)
            ivBytes = new byte[16];
            random.NextBytes(ivBytes);

            // Create AES cipher with CBC mode
            cipher = CipherUtilities.GetCipher("AES/CBC/PKCS7Padding");

            // Initialize the cipher with the key and IV
            cipher.Init(true, new ParametersWithIV(new KeyParameter(keyBytes), ivBytes));

            // Encrypt the input data
            encryptedBytes = cipher.DoFinal(inputBytes);

            // Convert the encrypted bytes to a Base64 string for easier display
            string encryptedBase64 = Convert.ToBase64String(encryptedBytes);

            // Print the encrypted data
            Console.WriteLine("Encrypted data: " + encryptedBase64);

            return encryptedBase64;
        }

        public string AesDecrypt(IBufferedCipher cipher, byte[] key, byte[] iv, byte[] encryptedBytes)
        {
            // Initialize the cipher for decryption
            cipher.Init(false, new ParametersWithIV(new KeyParameter(key), iv));

            // Decrypt the encrypted data
            byte[] decryptedBytes = cipher.DoFinal(encryptedBytes);

            // Convert the decrypted bytes back to a string
            string decryptedString = System.Text.Encoding.UTF8.GetString(decryptedBytes);

            // Print the decrypted data
            Console.WriteLine("Decrypted data: " + decryptedString);

            return decryptedString;
        }

        public string TripleDesEncrypt(string input, out byte[] ivBytes, out byte[] keyBytes, out byte[] encryptedBytes)
        {
            // Convert the input string to bytes
            byte[] inputBytes = System.Text.Encoding.UTF8.GetBytes(input);

            // Generate a random 192-bit key (Triple DES key size)
            keyBytes = new byte[24];
            SecureRandom random = new SecureRandom();
            random.NextBytes(keyBytes);

            // Generate a random 64-bit IV (initialization vector)
            ivBytes = new byte[8];
            random.NextBytes(ivBytes);

            // Create Triple DES cipher with CBC mode
            IBufferedCipher cipher = CipherUtilities.GetCipher("DESede/CBC/PKCS7Padding");

            // Initialize the cipher with the key and IV
            cipher.Init(true, new ParametersWithIV(new DesEdeParameters(keyBytes), ivBytes));

            // Encrypt the input data
            encryptedBytes = cipher.DoFinal(inputBytes);

            // Convert the encrypted bytes to a Base64 string for easier display
            string encryptedBase64 = Convert.ToBase64String(encryptedBytes);

            // Print the encrypted data
            Console.WriteLine("Encrypted data: " + encryptedBase64);

            return encryptedBase64;
        }

        public string TripleDesDecrypt(IBufferedCipher cipher, byte[] key, byte[] iv, byte[] encryptedBytes)
        {
            // Initialize the cipher for decryption
            cipher.Init(false, new ParametersWithIV(new DesEdeParameters(key), iv));

            // Decrypt the encrypted data
            byte[] decryptedBytes = cipher.DoFinal(encryptedBytes);

            // Convert the decrypted bytes back to a string
            string decryptedString = System.Text.Encoding.UTF8.GetString(decryptedBytes);

            // Print the decrypted data
            Console.WriteLine("Decrypted data: " + decryptedString);

            return decryptedString;
        }

        // Asymetrical - RSA and DSA

        public static AsymmetricCipherKeyPair GenerateRsaKeyPair()
        {
            // Generate RSA key pair with 2048-bit key size
            RsaKeyPairGenerator rsaKeyPairGen = new RsaKeyPairGenerator();
            rsaKeyPairGen.Init(new Org.BouncyCastle.Crypto.KeyGenerationParameters(new SecureRandom(), 2048));
            return rsaKeyPairGen.GenerateKeyPair();
        }

        public static byte[] RsaEncrypt(string input, AsymmetricKeyParameter publicKey)
        {
            // Convert the input string to bytes
            byte[] inputBytes = System.Text.Encoding.UTF8.GetBytes(input);

            // Create RSA cipher with PKCS1 v1.5 padding
            IAsymmetricBlockCipher cipher = new Pkcs1Encoding(new RsaEngine());

            // Initialize the cipher for encryption with the public key
            cipher.Init(true, publicKey);

            // Encrypt the input data
            return cipher.ProcessBlock(inputBytes, 0, inputBytes.Length);
        }

        public static string RsaDecrypt(byte[] encryptedBytes, AsymmetricKeyParameter privateKey)
        {
            // Create RSA cipher with PKCS1 v1.5 padding
            IAsymmetricBlockCipher cipher = new Pkcs1Encoding(new RsaEngine());

            // Initialize the cipher for decryption with the private key
            cipher.Init(false, privateKey);

            // Decrypt the encrypted data
            byte[] decryptedBytes = cipher.ProcessBlock(encryptedBytes, 0, encryptedBytes.Length);

            // Convert the decrypted bytes back to a string
            return System.Text.Encoding.UTF8.GetString(decryptedBytes);
        }

        // Hashing

        public byte[] Md5Hash(string secret)
        {
            IDigest hash = new MD5Digest();

            byte[] result = new byte[hash.GetDigestSize()];

            using (var stream = new MemoryStream(Encoding.UTF8.GetBytes(secret)))
            {
                byte[] buffer = new byte[4092];
                int bytesRead;

                while ((bytesRead = stream.Read(buffer, 0, buffer.Length)) > 0)
                {
                    hash.BlockUpdate(buffer, 0, bytesRead);
                }

                hash.DoFinal(result, 0);
            }

            return result;
        }

        public byte[] ShaHash(string secret)
        {
            IDigest hash = new Sha256Digest();

            byte[] result = new byte[hash.GetDigestSize()];

            using (var stream = new MemoryStream(Encoding.UTF8.GetBytes(secret)))
            {
                byte[] buffer = new byte[4092];
                int bytesRead;

                while ((bytesRead = stream.Read(buffer, 0, buffer.Length)) > 0)
                {
                    hash.BlockUpdate(buffer, 0, bytesRead);
                }

                hash.DoFinal(result, 0);
            }

            return result;
        }
    }
}