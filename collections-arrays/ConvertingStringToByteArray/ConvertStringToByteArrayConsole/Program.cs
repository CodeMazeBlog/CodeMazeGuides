// See https://aka.ms/new-console-template for more information
using ConvertingStringToByteArray;

var message = "Welcome to CodeMaze!";

Console.WriteLine($"Using Encoding GetBytes: {string.Join(",", MessageConversion.ConvertStringToUTF8Bytes(message))}");
Console.WriteLine();

Console.WriteLine($"Using casting: {string.Join(",", MessageConversion.ConvertStringToByteArrayUsingCasting(message))}");
Console.WriteLine();

Console.WriteLine($"Using Convert ToByte: {string.Join(",", MessageConversion.ConvertStringToByteArrayUsingConvertToByte(message))}");
Console.WriteLine();

Console.WriteLine($"Using Encoding GetEncoding: {string.Join(",", MessageConversion.ConvertStringToByteArrayUsingEncoding(message))}");
Console.WriteLine();
