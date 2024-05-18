using Org.BouncyCastle.Crypto.Generators;
using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Security;
using System.Text;

namespace BouncyCastleCryptography.AsymmetricEncryption;

public static class DsaEncryptor
{
    public static AsymmetricCipherKeyPair GenerateDsaKeyPair()
    {
        // Create DSA parameters
        var dsaParamsGenerator = new DsaParametersGenerator();
        var random = new SecureRandom();
        dsaParamsGenerator.Init(1024, 80, random); // key size: 1024 bits, certainty: 80

        // Generate DSA key pair
        var dsaParams = dsaParamsGenerator.GenerateParameters();
        var dsaKeyParams = new DsaKeyGenerationParameters(random, dsaParams);
        var dsaKeyPairGen = new DsaKeyPairGenerator();
        dsaKeyPairGen.Init(dsaKeyParams);
        return dsaKeyPairGen.GenerateKeyPair();
    }

    public static byte[] DsaSign(string message, AsymmetricKeyParameter privateKey)
    {
        var messageBytes = Encoding.UTF8.GetBytes(message);

        var signer = SignerUtilities.GetSigner("SHA256withDSA");

        signer.Init(true, privateKey);

        signer.BlockUpdate(messageBytes, 0, messageBytes.Length);

        return signer.GenerateSignature();
    }

    public static bool DsaVerify(string message, byte[] signature, AsymmetricKeyParameter publicKey)
    {
        var messageBytes = Encoding.UTF8.GetBytes(message);

        var signer = SignerUtilities.GetSigner("SHA256withDSA");

        signer.Init(false, publicKey);

        signer.BlockUpdate(messageBytes, 0, messageBytes.Length);

        return signer.VerifySignature(signature);
    }
}
