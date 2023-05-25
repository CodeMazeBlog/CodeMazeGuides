using System.Collections;

namespace RemoveWhitespaceCharactersFromStringTests;

public class WhitespaceStringTrimTestData : IEnumerable<object[]>
{
    private const string ExpectedResultHelloWorldWithSpace = "Hello World!";
    private static readonly string AllWhitespaceString = new(Constants.WhiteSpaceCharacters);

    public IEnumerator<object[]> GetEnumerator()
    {
        // Sanity test - empty string remains empty
        yield return new object[] {string.Empty, string.Empty};

        // Sanity test - No leading or trailing whitespace 
        yield return new object[] {ExpectedResultHelloWorldWithSpace, ExpectedResultHelloWorldWithSpace};

        // Leading common whitespace 
        yield return new object[]
            {$"\r\n\t      {ExpectedResultHelloWorldWithSpace}", ExpectedResultHelloWorldWithSpace};

        // Trailing common whitespace 
        yield return new object[]
            {$"{ExpectedResultHelloWorldWithSpace}\r\n\t      ", ExpectedResultHelloWorldWithSpace};

        // Leading and trailing common whitespace
        yield return new object[]
            {$"\r\n\t {ExpectedResultHelloWorldWithSpace}\r\n\t ", ExpectedResultHelloWorldWithSpace};

        // Leading - all whitespace characters
        yield return new object[]
            {$"{AllWhitespaceString}{ExpectedResultHelloWorldWithSpace}", ExpectedResultHelloWorldWithSpace};

        // Trailing - all whitespace characters
        yield return new object[]
        {
            $"{ExpectedResultHelloWorldWithSpace}{AllWhitespaceString}",
            ExpectedResultHelloWorldWithSpace
        };

        // Leading and trailing all whitespace characters
        yield return new object[]
        {
            $"{AllWhitespaceString}{ExpectedResultHelloWorldWithSpace}{AllWhitespaceString}",
            ExpectedResultHelloWorldWithSpace
        };
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}