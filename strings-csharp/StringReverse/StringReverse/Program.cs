using System.Text;
using static StringReverse.Methods;

var input = "123456";
Console.OutputEncoding = Encoding.UTF8;
Console.WriteLine(input);

Console.WriteLine(nameof(ArrayReverseString) + ": " + ArrayReverseString(input));
Console.WriteLine(nameof(EnumerableReverseMethod) + ": " + EnumerableReverseMethod(input));
Console.WriteLine(nameof(RecursiveStringReverseMethod) + ": " + RecursiveStringReverseMethod(input));
Console.WriteLine(nameof(ReverseXorMethod) + ": " + ReverseXorMethod(input));
Console.WriteLine(nameof(StackReverseMethod) + ": " + StackReverseMethod(input));
Console.WriteLine(nameof(StringBuilderReverseMethod) + ": " + StringBuilderReverseMethod(input));
Console.WriteLine(nameof(StringCreateMethod) + ": " + StringCreateMethod(input));
Console.WriteLine(nameof(StringExtensionReverseMethod) + ": " + StringExtensionReverseMethod(input));
Console.WriteLine(nameof(TextElementEnumeratorMethod) + ": " + TextElementEnumeratorMethod(input));