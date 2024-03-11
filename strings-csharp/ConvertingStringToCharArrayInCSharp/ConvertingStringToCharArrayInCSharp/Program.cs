using ConvertingStringToCharArrayInCSharp;

string myString = "Hello World!";
char[] charArray = StringHelper.ConvertStringToCharArray(myString);

string singleCharString = "A";
char singleChar = StringHelper.ConvertSingleCharacterStringToChar(singleCharString);

ReadOnlySpan<char> charArrayReadOnlySpan = StringHelper.ConvertStringToCharArrayUsingReadOnlySpan(myString);
char[] charArrayUsingReadOnlySpan = charArrayReadOnlySpan.ToArray();

string[] stringArray = { "C#", "is", "awesome" };
char[] combinedCharArray = StringHelper.ConvertStringArrayToCharArrayUsingLoop(stringArray);

char[] combinedCharArrayUsingLinq = StringHelper.ConvertStringArrayToCharArrayUsingLinq(stringArray);