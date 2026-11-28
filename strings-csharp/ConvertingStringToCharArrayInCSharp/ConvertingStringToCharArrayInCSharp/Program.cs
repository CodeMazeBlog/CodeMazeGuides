using ConvertingStringToCharArrayInCSharp;

string myString = "Hello World!";
char[] charArray = StringHelper.ConvertStringToCharArray(myString);
PrintArray(charArray);

string singleCharString = "A";
char singleChar = StringHelper.ConvertSingleCharacterStringToChar(singleCharString);
Console.WriteLine(singleChar);

char firstChar = StringHelper.GetCharacterAtIndex(myString, 0);
char lastChar = myString[^1];
Console.WriteLine($"{firstChar} {lastChar}");

if (StringHelper.TryConvertSingleCharacterStringToChar("AB", out char parsed))
    Console.WriteLine(parsed);
else
    Console.WriteLine("Not a single character");

ReadOnlySpan<char> charArrayReadOnlySpan = StringHelper.ConvertStringToCharArrayUsingReadOnlySpan(myString);
PrintArray(charArrayReadOnlySpan);

string[] stringArray = ["C#", "is", "awesome"];
char[] combinedCharArray = StringHelper.ConvertStringArrayToCharArrayUsingLoop(stringArray);
PrintArray(combinedCharArray);

char[] combinedCharArrayUsingLinq = StringHelper.ConvertStringArrayToCharArrayUsingLinq(stringArray);
PrintArray(combinedCharArrayUsingLinq);

return;

static void PrintArray(ReadOnlySpan<char> input)
{
    foreach(var c in input)
        Console.Write(c);
    Console.WriteLine();
}