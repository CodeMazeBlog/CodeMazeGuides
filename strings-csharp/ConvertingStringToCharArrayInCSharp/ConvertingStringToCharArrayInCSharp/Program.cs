using ConvertingStringToCharArrayInCSharp;

//Convert a string to Char Array
string myString = "Hello World!";
char[] charArray = StringHelper.StringToCharArray(myString);

//Convert a string Containing a Single Character to Char
string singleCharString = "A";
char singleChar = StringHelper.StringToChar(singleCharString);

//Convert a string to Char Array using ReadOnlySpan
ReadOnlySpan<char> charArrayReadOnlySpan = StringHelper.StringToCharArrayUsingReadOnlySpan(myString);
var charArray2 = charArrayReadOnlySpan.ToArray();

//Convert a string Array to Char Array Using For Loop (string[] to char[])
string[] stringArray = { "C#", "is", "awesome" };
char[] combinedCharArray = StringHelper.StringArrayToCharArrayUsingLoop(stringArray);

//Convert a string Array to Char Array Using LINQ (string[] to char[])
char[] combinedCharArrayUsingLinq = StringHelper.StringArrayToCharArrayUsingLinq(stringArray);