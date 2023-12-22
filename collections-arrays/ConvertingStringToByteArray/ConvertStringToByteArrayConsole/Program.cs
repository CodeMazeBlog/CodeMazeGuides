// See https://aka.ms/new-console-template for more information
using ConvertingStringToByteArray;

var message = "Welcome to CodeMaze!";

Console.WriteLine(string.Join(",", MessageConversion.ConvertStringToUTF8Bytes(message)));
Console.WriteLine();

Console.WriteLine(string.Join(",", MessageConversion.ConvertStringToByteArrayUsingCasting(message)));
Console.WriteLine();

Console.WriteLine(string.Join(",", MessageConversion.ConvertStringToByteArrayUsingConvertToByte(message)));
Console.WriteLine();

Console.WriteLine(string.Join(",", MessageConversion.ConvertStringToByteArrayUsingEncoding(message)));
Console.WriteLine();
