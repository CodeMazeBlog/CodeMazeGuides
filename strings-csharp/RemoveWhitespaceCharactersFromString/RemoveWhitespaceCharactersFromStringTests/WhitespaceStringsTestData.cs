using System.Collections;
using System.Text;

namespace RemoveWhitespaceCharactersFromStringTests;

public class WhitespaceStringsTestData : IEnumerable<object[]>
{
    private const int BigStringLength = 1024;
    private const string ExpectedResultHelloWorld = "HelloWorld!";

    private static readonly Random Rand = new(42);

    private static readonly string TestStringWithMixedSpaces = GetTestStringWithMixedSpaces(ExpectedResultHelloWorld);

    private static readonly string LargeTestStringNoSpaces = GenerateBigStringNoSpaces();

    private static readonly string LargeTestStringWithSpaces = GetTestStringWithMixedSpaces(LargeTestStringNoSpaces);

    public IEnumerator<object[]> GetEnumerator()
    {
        // Sanity check, no spaces to remove so string should be unchanged
        yield return
            new object[]
            {
                ExpectedResultHelloWorld, ExpectedResultHelloWorld
            };

        // Simple test with just a space character
        yield return
            new object[] {"Hello World!", ExpectedResultHelloWorld};

        // Extra space at the front
        yield return new object[] {$"\t{ExpectedResultHelloWorld}", ExpectedResultHelloWorld};

        // Extra space at the front and back
        yield return
            new object[] {$"\t{ExpectedResultHelloWorld}\n", ExpectedResultHelloWorld};

        // Extra space at the front, middle and back
        yield return
            new object[]
                {"\tHello  World!\n", ExpectedResultHelloWorld};

        // A whitespace only string, should return empty
        yield return
            new object[]
            {
                new string(Constants.WhiteSpaceCharacters), string.Empty
            };

        // Random jumble of different whitespace in the string
        yield return
            new object[]
            {
                TestStringWithMixedSpaces, ExpectedResultHelloWorld
            };

        // Large test string (needed to test both paths in array method) - sanity check
        yield return
            new object[]
            {
                LargeTestStringNoSpaces, LargeTestStringNoSpaces
            };

        // Large test string (needed to test both paths in array method)
        yield return
            new object[]
            {
                LargeTestStringWithSpaces, LargeTestStringNoSpaces
            };
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    private static string GetTestStringWithMixedSpaces(string input)
    {
        var spaces = Constants.WhiteSpaceCharacters.OrderBy(x => Rand.Next());
        var sb = new StringBuilder(input.Length + Constants.WhiteSpaceCharacters.Length);
        sb.Append(input);
        foreach (var space in spaces) sb.Insert(Rand.Next(0, sb.Length), space);

        return sb.ToString();
    }

    private static string GenerateBigStringNoSpaces()
    {
        const string sourceChars =
            "abcdefghijklmnopqrstuvwxyzабцдефгхийклмнопярстужвьъзABCDEFGHIJKLMNOPQRSTUVWXYZАБЦДЕФГХИЙКЛМНОПЯРСТУЖВЬЪЗ";

        return string.Create(BigStringLength, Rand, (chars, random) =>
        {
            var pos = 0;
            while (pos < chars.Length) chars[pos++] = sourceChars[random.Next(0, sourceChars.Length)];
        });
    }
}