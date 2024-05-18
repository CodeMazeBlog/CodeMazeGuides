using BouncyCastleCryptography.AsymmetricEncryption;
using BouncyCastleCryptography.Hashing;
using BouncyCastleCryptography.SymmetricEncryption;

var input = "Hello, Bouncy Castle!";

// HASHING
Console.WriteLine("Hashing:");

var hash = Md5Hasher.Md5Hash(input);

var hashAsStr = Convert.ToBase64String(hash);

Console.WriteLine("MD5 hash result: " + hashAsStr);

hash = ShaHasher.ShaHash(input);

hashAsStr = Convert.ToBase64String(hash);

Console.WriteLine("SHA hash result: " + hashAsStr);
Console.WriteLine();

// Symmetric Encryption

Console.WriteLine("Symmetric Encryption:");

var encryptedData = AesEncryptor.AesEncrypt(input, out byte[] iv, out byte[] key);

var encryptedString = Convert.ToBase64String(encryptedData);

Console.WriteLine("AES encryption result: " + encryptedString);

encryptedData = TripleDesEncryptor.TripleDesEncrypt(input, out byte[] iv2, out byte[] key2);

encryptedString = Convert.ToBase64String(encryptedData);

Console.WriteLine("TripleDES encryption result: " + encryptedString);
Console.WriteLine();

// Asymmetric Encryption

Console.WriteLine("Asymmetric Encryption:");

var keyPair = RsaEncryptor.GenerateRsaKeyPair();

var encryptedBytes = RsaEncryptor.RsaEncrypt(input, keyPair.Public);

encryptedString = Convert.ToBase64String(encryptedBytes);

Console.WriteLine("RSA encryption result: " + encryptedString);

var keyPair2 = DsaEncryptor.GenerateDsaKeyPair();

var signature = DsaEncryptor.DsaSign(input, keyPair2.Private);

var signatureAsStr = Convert.ToBase64String(encryptedData);

var isSignatureValid = DsaEncryptor.DsaVerify(input, signature, keyPair2.Public);

Console.WriteLine("DSA signature result: " + signatureAsStr);
Console.WriteLine("DSA signature is valid: " + isSignatureValid.ToString());