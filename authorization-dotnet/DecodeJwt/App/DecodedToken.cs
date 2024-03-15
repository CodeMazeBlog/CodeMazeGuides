namespace App;

public record DecodedToken(
    string KeyId,
    string Issuer,
    List<string> Audience,
    List<(string Type, string Value)> Claims,
    DateTime Expiration,
    string SigningAlgorithm,
    string RawData,
    string Subject,
    DateTime ValidFrom,
    string Header,
    string Payload
);