
using BenchmarkDotNet.Running;
using HexToByteArray;

string hexString = "FF008000"; // Hex representaion of color System.Drawing.Color.Green

// Run the built-in first and display the result
var bytes = ConvertHex.FromHexString(hexString);
PrintArray(bytes);

// Run the alternative approaches and display the result

bytes = ConvertHex.FromHexWithCharacterWiseTranslation(hexString);
PrintArray(bytes);

bytes = ConvertHex.FromHexWithPointers(hexString);
PrintArray(bytes);

bytes = ConvertHex.FromHexWithSwitchComputation(hexString);
PrintArray(bytes);

bytes = ConvertHex.FromHexWithBitFiddle(hexString);
PrintArray(bytes);

bytes = ConvertHex.FromHexWithLookup(hexString);
PrintArray(bytes);

// Benchmark
BenchmarkRunner.Run<BenchmarkClass>();

static void PrintArray(byte[] bytes)
{
    Console.WriteLine($"{{{string.Join(", ", bytes)}}}");
}
