using EncryptingAndDecryptingStringInCSharp;

var encryptionService = new StringEncryptionService();
const string passphrase = "Sup3rS3curePass!";

var encrypted = await encryptionService.EncryptAsync("We use encryption to obscure a piece of information.",
                                                     passphrase);

Console.WriteLine($"Encrypted data: {BitConverter.ToString(encrypted)}");

var decrypted = await encryptionService.DecryptAsync(encrypted, passphrase);
Console.WriteLine($"Decrypted data: {decrypted}");