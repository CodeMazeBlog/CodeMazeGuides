using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using Xunit;
using Xunit.Abstractions;

namespace Test
{
    public class HashingAndSaltingPasswordsTests
    {
        private readonly ITestOutputHelper _output;

        public HashingAndSaltingPasswordsTests(ITestOutputHelper output)
        {
            _output = output;
        }

        const int keySize = 64;
        const int iterations = 350000;
        HashAlgorithmName hashAlgorithm = HashAlgorithmName.SHA512;

        string HashPasword(string password, out byte[] salt)
        {
            salt = RandomNumberGenerator.GetBytes(keySize);

            var hash = Rfc2898DeriveBytes.Pbkdf2(
                Encoding.UTF8.GetBytes(password),
                salt,
                iterations,
                hashAlgorithm,
                keySize);

            return Convert.ToHexString(hash);
        }

        bool VerifyPassword(string password, string hash, byte[] salt)
        {
            var hashToCompare = Rfc2898DeriveBytes.Pbkdf2(password, salt, iterations, hashAlgorithm, keySize);

            return CryptographicOperations.FixedTimeEquals(hashToCompare, Convert.FromHexString(hash));
        }

        [Fact]
        public void WhenHasingPassword_ThenReturnsHashAndSalt()
        {
            var hash = HashPasword("clear_password", out var salt);

            _output.WriteLine($"Password hash: {hash}");
            _output.WriteLine($"Generated salt: {Convert.ToHexString(salt)}");

            Assert.NotNull(hash);
            Assert.NotNull(salt);
        }

        [Fact]
        public void WhenVerifyingPassword_ThenPositiveVerificationSucceeds()
        {
            var hash = HashPasword("clear_password", out var salt);

            var verificationResult = VerifyPassword("clear_password", hash, salt);

            Assert.True(verificationResult);
        }

        [Fact]
        public void WhenVerifyingPassword_ThenNegativeVerificationSucceeds()
        {
            var hash = HashPasword("clear_password", out var salt);

            var verificationResult = VerifyPassword("wrong_password", hash, salt);

            Assert.False(verificationResult);
        }
    }
}