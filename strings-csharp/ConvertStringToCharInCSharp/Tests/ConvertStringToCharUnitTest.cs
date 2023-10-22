using System;
using Xunit;
using ConvertString2CharArray;

public class ConvertString2CharArrayUnitTests
{
    [Fact]
    public void GivenString_WhenConvertedToCharArrayWithToCharArray_ThenCharArrayConverted()
    {
        string str = "Code Maze";
        char[] expected = str.ToCharArray();
        char[] result = Program.ConvertToCharArray(str);

        Assert.Equal(expected, result);
    }

    [Fact]
    public void GivenString_WhenConvertedToCharArrayWithForLoop_ThenCharArrayConverted()
    {
        string str = "Code Maze";
        char[] expected = str.ToCharArray();
        char[] result = Program.ConvertUsingForLoop(str);

        Assert.Equal(expected, result);
    }

    [Fact]
    public void GivenString_WhenConvertedToCharArrayWithReadOnlySpan_ThenCharArrayConverted()
    {
        string str = "Code Maze";
        char[] expected = str.ToCharArray();
        char[] result = Program.ConvertUsingReadOnlySpan(str);

        Assert.Equal(expected, result);
    }

    [Fact]
    public void GivenString_WhenConvertedToCharArrayWithUnsafeCode_ThenCharArrayConverted()
    {
        string str = "Code Maze";
        char[] expected = str.ToCharArray();
        char[] result = Program.ConvertUsingUnsafeCode(str);

        Assert.Equal(expected, result);
    }

    [Fact]
    public void GivenString_WhenConvertedToCharArrayWithLinq_ThenCharArrayConverted()
    {
        string str = "Code Maze";
        char[] expected = str.ToCharArray();
        char[] result = Program.ConvertUsingLinq(str);

        Assert.Equal(expected, result);
    }

    [Fact]
    public void GivenString_WhenReversed_ThenStringReversed()
    {
        string input = "Hello, C#";
        char[] expected = "#C ,olleH".ToCharArray();
        char[] result = Program.ReverseString(input);

        Assert.Equal(expected, result);
    }

    [Fact]
    public void GivenString_WhenSorted_ThenStringSorted()
    {
        string input = "Hello, C#";
        char[] expected = " #,CHello".ToCharArray();
        char[] result = Program.SortString(input);

        Assert.Equal(expected, result);
    }

    [Fact]
    public void GivenString_WhenUppercased_ThenStringUppercased()
    {
        string input = "Hello, C#";
        char[] expected = "HELLO, C#".ToCharArray();
        char[] result = Program.UppercaseString(input);

        Assert.Equal(expected, result);
    }

    [Fact]
    public void GivenString_WhenSubstringReplaced_ThenSubstringReplaced()
    {
        string input = "Hello, C#";
        string expected = "Hello, C++";
        string result = Program.ReplaceString(input, "C#", "C++");

        Assert.Equal(expected, result);
    }
}