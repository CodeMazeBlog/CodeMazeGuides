using static RandomAlphaNumericString.Methods;

var length = 32;

//Test all 13 methods
Console.WriteLine(nameof(AesMethod) + ": " + AesMethod(length));
Console.WriteLine(nameof(PathMethod) + ": " + PathMethod(length));
Console.WriteLine(nameof(RandomNumberGenGetStringMethod) + ": " + RandomNumberGenGetStringMethod(length));
Console.WriteLine(nameof(CryptographicUniqueMethod) + ": " + CryptographicUniqueMethod(length));
Console.WriteLine(nameof(GuidMethod) + ": " + GuidMethod(length));
Console.WriteLine(nameof(GuidMethod) + ": " + GuidMethod(length));
Console.WriteLine(nameof(LinqMethod) + ": " + LinqMethod(length));
Console.WriteLine(nameof(StringCreateMethod) + ": " + StringCreateMethod(length));
Console.WriteLine(nameof(StringCreateSecureMethod) + ": " + StringCreateSecureMethod(length));
Console.WriteLine(nameof(StringBuilderMethod) + ": " + StringBuilderMethod(length));
Console.WriteLine(nameof(SpanSecureMethod) + ": " + SpanSecureMethod(length));
Console.WriteLine(nameof(SpanMethod) + ": " + SpanMethod(length));
