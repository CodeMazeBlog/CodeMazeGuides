using ByteRepresentationOfStrings;
using System.Runtime.InteropServices;

//Enable Unicode characters for the console
Console.OutputEncoding = System.Text.Encoding.Unicode;

string sampleString = "𝓒𝓸𝓭𝓮𝓜𝓪𝔃𝓮";
byte[] byteArray = StringByteConverter.GetBytes(sampleString);
string reconstructedString = StringByteConverter.GetString(byteArray);

Console.WriteLine($"Original String: {sampleString}");
Console.WriteLine($"Converted String: {reconstructedString}");


// Convert string to bytes using Span
ReadOnlySpan<char> charSpan = sampleString.AsSpan();
byte[] bytes = StringByteConverter.GetBytesWithSpan(charSpan);

// Convert bytes back to string using Span
string convertedString = StringByteConverter.GetString(bytes);

Console.WriteLine($"Converted String using span: {convertedString}");


//Example using System.Text.Encoding
string cafe = "Café";
byte[] ascii = System.Text.Encoding.ASCII.GetBytes(cafe);
byte[] utf8 = System.Text.Encoding.UTF8.GetBytes(cafe);

//Different byte length
Console.WriteLine(ascii.Length);
Console.WriteLine(utf8.Length);

Console.WriteLine(System.Text.Encoding.ASCII.GetString(ascii));
Console.WriteLine(System.Text.Encoding.UTF8.GetString(utf8));