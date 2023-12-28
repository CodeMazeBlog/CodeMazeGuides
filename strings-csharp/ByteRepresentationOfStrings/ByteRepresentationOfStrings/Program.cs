using ByteRepresentationOfStrings;
using System.Text;

//Enable Unicode characters for the console
Console.OutputEncoding = Encoding.Unicode;

const string sampleString = "𝓒𝓸𝓭𝓮𝓜𝓪𝔃𝓮";
byte[] byteArray = StringByteConverter.GetBytes(sampleString);
string reconstructedString = StringByteConverter.GetString(byteArray);

Console.WriteLine($"Original String: {sampleString}");
Console.WriteLine($"Converted String: {reconstructedString}");

// Convert string to bytes using Span
byte[] bytes = StringByteConverter.GetBytesWithSpan(sampleString);

// Convert bytes back to string using Span
string convertedString = StringByteConverter.GetString(bytes);

Console.WriteLine($"Converted String using span: {convertedString}");

//Example using System.Text.Encoding
const string cafe = "Café";
byte[] asciiBytes = Encoding.ASCII.GetBytes(cafe);
byte[] utf8Bytes = Encoding.UTF8.GetBytes(cafe);

//Different byte length
Console.WriteLine(asciiBytes.Length);
Console.WriteLine(utf8Bytes.Length);

Console.WriteLine("ASCII Output: " + Encoding.ASCII.GetString(asciiBytes));
Console.WriteLine("UTF-8 Output: " + Encoding.UTF8.GetString(utf8Bytes));