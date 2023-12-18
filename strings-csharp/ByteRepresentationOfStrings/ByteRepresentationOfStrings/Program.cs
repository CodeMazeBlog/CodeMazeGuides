using ByteRepresentationOfStrings;
using System.Text;

//Enable Unicode characters for the console
Console.OutputEncoding = Encoding.Unicode;

string sampleString = "𝓒𝓸𝓭𝓮𝓜𝓪𝔃𝓮";
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
string cafe = "Café";
byte[] ascii = Encoding.ASCII.GetBytes(cafe);
byte[] unicode = Encoding.Unicode.GetBytes(cafe);

//Different byte length
Console.WriteLine(ascii.Length);
Console.WriteLine(unicode.Length);

Console.WriteLine("ASCII Output: " + Encoding.ASCII.GetString(ascii));
Console.WriteLine("Unicode Output: " + Encoding.Unicode.GetString(unicode));