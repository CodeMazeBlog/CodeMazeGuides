using ConvertHexStringToByteArray.Library;

const string input = "0xDEADBEEFDECAFBAD";

var result = ConversionHelpers.FromHexWithModularArithmetic(input);
PrintResult(nameof(ConversionHelpers.FromHexWithModularArithmetic), result);

result = ConversionHelpers.FromHexWithSwitchComputation(input);
PrintResult(nameof(ConversionHelpers.FromHexWithSwitchComputation), result);

result = ConversionHelpers.FromHexWithBitManipulation(input.ToLowerInvariant());
PrintResult(nameof(ConversionHelpers.FromHexWithBitManipulation), result);

result = ConversionHelpers.FromHexWithConvert(input);
PrintResult(nameof(ConversionHelpers.FromHexWithConvert), result);

result = ConversionHelpers.FromHexWithLookup(input);
PrintResult(nameof(ConversionHelpers.FromHexWithLookup), result);

Span<byte> buffer = stackalloc byte[8];
var status = Convert.FromHexString("ABC", buffer, out var charsConsumed, out var bytesWritten);
Console.WriteLine($"odd: {status} consumed={charsConsumed} written={bytesWritten}");

static void PrintResult(string method, IEnumerable<byte> input) =>
    Console.WriteLine($"{method}: \t[{string.Join(',', input)}]");