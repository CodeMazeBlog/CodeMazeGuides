using ByteRepresentationOfStrings;

string sampleString = "CodeMaze";
byte[] byteArray = StringByteConverter.GetBytes(sampleString);
string reconstructedString = StringByteConverter.GetString(byteArray);

Console.WriteLine(reconstructedString);


//Example using System.Text.Encoding
string cafe = "Café";
byte[] ascii = System.Text.Encoding.ASCII.GetBytes(cafe);
byte[] utf8 = System.Text.Encoding.UTF8.GetBytes(cafe);

//Different byte length
Console.WriteLine(ascii.Length);
Console.WriteLine(utf8.Length);

Console.WriteLine(System.Text.Encoding.ASCII.GetString(ascii));
Console.WriteLine(System.Text.Encoding.UTF8.GetString(utf8));