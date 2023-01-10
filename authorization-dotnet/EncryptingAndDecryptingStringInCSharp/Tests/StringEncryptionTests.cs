using EncryptingAndDecryptingStringInCSharp;
using System.Security.Cryptography;

namespace Tests
{
    public class StringEncryptionTests
    {
        [Fact]
        public async Task WhenDecryptingAnEncryptedText_ThenOriginalTextIsObtained()
        {
            var encryptionService = new StringEncryptionService();
            const string passphrase = "myPassword";
            const string clearText = "We use encryption to obscure a piece of information.";

            var encrypted = await encryptionService.EncryptAsync(clearText, passphrase);
            var decrypted = await encryptionService.DecryptAsync(encrypted, passphrase);

            Assert.Equal(clearText, decrypted);
        }

        [Fact]
        public async Task WhenDecryptingAnEncryptedTextWithInvalidPassPhrase_ThenDecryptionFails()
        {
            var encryptionService = new StringEncryptionService();
            const string passphrase = "myPassword";
            const string clearText = "We use encryption to obscure a piece of information.";

            var encrypted = await encryptionService.EncryptAsync(clearText, passphrase);

            await Assert.ThrowsAsync<CryptographicException>(() =>  encryptionService.DecryptAsync(encrypted, "wrong_password"));
        }
    }
}