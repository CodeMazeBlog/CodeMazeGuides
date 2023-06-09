// See https://aka.ms/new-console-template for more information

using BenchmarkDotNet.Running;
using HexToByteArray;

string hexString = "FF008000"; // Hex representaion of color System.Drawing.Color.Green

var convertHex = new ConvertHex();

// Run the built-in first and display the result
var bytes = convertHex.FromHexString(hexString);
foreach (var b in bytes)
    Console.WriteLine(b);

// Run the alternative approach and display the result
var bytesAlternatives = convertHex.FromHexStringAlternative(hexString);
foreach (var b in bytesAlternatives)
    Console.WriteLine(b);

// Benchmark
var summary = BenchmarkRunner.Run<BenchmarkClass>();

