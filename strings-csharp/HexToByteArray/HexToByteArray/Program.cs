
using BenchmarkDotNet.Running;
using HexToByteArray;

string hexString = "FF008000"; // Hex representaion of color System.Drawing.Color.Green

// Run the built-in first and display the result
var bytes = ConvertHex.FromHexString(hexString);
PrintArray(bytes);

// Run the alternative approach and display the result
var bytesAlternatives = ConvertHex.FromHexStringAlternative(hexString);
PrintArray(bytesAlternatives);

// Benchmark
BenchmarkRunner.Run<BenchmarkClass>();

static void PrintArray(byte[] bytes)
{
    Console.WriteLine($"{{{string.Join(", ", bytes)}}}");
}
