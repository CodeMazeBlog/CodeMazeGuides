using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ConvertString2CharArray;

namespace TestProject
{
    public class ConvertString2CharArrayUnitTests
    {
        [Fact]
        public void ConvertToCharArray_Test()
        {
            string str = "Code Maze";
            char[] expected = str.ToCharArray();
            char[] result = Program.ConvertToCharArray(str);

            Assert.Equal(expected, result);
        }

        [Fact]
        public void ConvertUsingForLoop_Test()
        {
            string str = "Code Maze";
            char[] expected = str.ToCharArray();
            char[] result = Program.ConvertUsingForLoop(str);

            Assert.Equal(expected, result);
        }

        [Fact]
        public void ConvertUsingReadOnlySpan_Test()
        {
            string str = "Code Maze";
            char[] expected = str.ToCharArray();
            char[] result = Program.ConvertUsingReadOnlySpan(str);

            Assert.Equal(expected, result);
        }

        [Fact]
        public void ConvertUsingUnsafeCode_Test()
        {
            string str = "Code Maze";
            char[] expected = str.ToCharArray();
            char[] result = Program.ConvertUsingUnsafeCode(str);

            Assert.Equal(expected, result);
        }

        [Fact]
        public void ConvertUsingLinq_Test()
        {
            string str = "Code Maze";
            char[] expected = str.ToCharArray();
            char[] result = Program.ConvertUsingLinq(str);

            Assert.Equal(expected, result);
        }

        [Fact]
        public void ReverseString_Test()
        {
            string input = "Hello, C#";
            char[] expected = "C# ,olleH".ToCharArray();
            char[] result = Program.ReverseString(input);

            Assert.Equal(expected, result);
        }

        [Fact]
        public void SortString_Test()
        {
            string input = "Hello, C#";
            char[] expected = " #,CHello".ToCharArray();
            char[] result = Program.SortString(input);

            Assert.Equal(expected, result);
        }

        [Fact]
        public void UppercaseString_Test()
        {
            string input = "Hello, C#";
            char[] expected = "HELLO, C#".ToCharArray();
            char[] result = Program.UppercaseString(input);

            Assert.Equal(expected, result);
        }

        [Fact]
        public void ReplaceString_Test()
        {
            string input = "Hello, C#";
            string expected = "Hello, C++";
            string result = Program.ReplaceString(input, "C#", "C++");

            Assert.Equal(expected, result);
        }
    }
}