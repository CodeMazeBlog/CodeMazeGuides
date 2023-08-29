using ConvertHexStringToByteArray.Library;

const string source = "0xDEADBEEFDECAFBAD";

var result = ConversionHelpers.FromHexWithBitFiddle(source);
PrintResult(nameof(ConversionHelpers.FromHexWithBitFiddle),result);

result = ConversionHelpers.FromHexWithLookup(source);
PrintResult(nameof(ConversionHelpers.FromHexWithLookup),result);

result = ConversionHelpers.FromHexWithConvert(source);
PrintResult(nameof(ConversionHelpers.FromHexWithConvert),result);

result = ConversionHelpers.FromHexWithModularArithmetic(source);
PrintResult(nameof(ConversionHelpers.FromHexWithModularArithmetic),result);

result = ConversionHelpers.FromHexWithSwitchComputation(source);
PrintResult(nameof(ConversionHelpers.FromHexWithSwitchComputation),result);


static void PrintResult(string method, byte[] input) => Console.WriteLine($"{method}: \t{{{string.Join(',', input)}}}");