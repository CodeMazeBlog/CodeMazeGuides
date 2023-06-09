using ConvertHexStringToByteArray.Library;

const string source = "0xDEADBEEFDECAFBAD";

var result = ConversionHelpers.FromHexWithBitFiddle(source);
PrintResult(result);

result = ConversionHelpers.FromHexWithSwitchComputation(source);
PrintResult(result);

result = ConversionHelpers.FromHexWithLookup(source);
PrintResult(result);

result = ConversionHelpers.FromHexWithConvert(source);
PrintResult(result);

static void PrintResult(byte[] input) => Console.WriteLine($"{{{string.Join(',', input)}}}");