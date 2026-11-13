using System.Text;
using static StringReverse.Methods;

Console.OutputEncoding = Encoding.UTF8;

var input = "abcdefg";
Console.WriteLine($"Input: {input}");

Console.WriteLine(nameof(ArrayReverseString) + ": " + ArrayReverseString(input));
Console.WriteLine(nameof(EnumerableReverseMethod) + ": " + EnumerableReverseMethod(input));
Console.WriteLine(nameof(RecursiveStringReverseMethod) + ": " + RecursiveStringReverseMethod(input));
Console.WriteLine(nameof(ReverseXorMethod) + ": " + ReverseXorMethod(input));
Console.WriteLine(nameof(StackReverseMethod) + ": " + StackReverseMethod(input));
Console.WriteLine(nameof(StringBuilderReverseMethod) + ": " + StringBuilderReverseMethod(input));
Console.WriteLine(nameof(StringCreateMethod) + ": " + StringCreateMethod(input));
Console.WriteLine(nameof(StringExtensionReverseMethod) + ": " + StringExtensionReverseMethod(input));
Console.WriteLine(nameof(TextElementEnumeratorMethod) + ": " + TextElementEnumeratorMethod(input));

var musicNotes = "\U0001D15E\U0001D11E\U0001D160\U0001D161";
var accented = "Les Mise\u0301rables";

foreach (var text in new[] { musicNotes, accented })
{
    Console.WriteLine();
    Console.WriteLine($"Input: {text} (Length: {text.Length})");
    Console.WriteLine(nameof(ArrayReverseString) + ": " + ArrayReverseString(text));
    Console.WriteLine(nameof(TextElementEnumeratorMethod) + ": " + TextElementEnumeratorMethod(text));
}
