using ConvertingStringToCharArrayInCSharp;

string myString = "Hello World!";
char[] charArray = StringHelper.StringToCharArray(myString);

string singleCharString = "A";
char singleChar = StringHelper.StringToChar(singleCharString);

ReadOnlySpan<char> charArrayReadOnlySpan = StringHelper.StringToCharArrayUsingReadOnlySpan(myString);
var charArrayUsingReadOnlySpan = charArrayReadOnlySpan.ToArray();

string[] stringArray = { "C#", "is", "awesome" };
char[] combinedCharArray = StringHelper.StringArrayToCharArrayUsingLoop(stringArray);

char[] combinedCharArrayUsingLinq = StringHelper.StringArrayToCharArrayUsingLinq(stringArray);