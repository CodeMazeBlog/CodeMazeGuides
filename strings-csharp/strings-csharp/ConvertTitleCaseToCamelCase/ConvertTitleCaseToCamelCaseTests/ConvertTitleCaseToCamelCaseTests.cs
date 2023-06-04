using ConvertTitleCaseToCamelCase;
using System;
using System.IO;
using Xunit;

namespace ConvertTitleCaseToCamelCaseTests
{
    public class ConvertTitleCaseToCamelCaseUnitTest 
    {
        [Theory]
        [InlineData("Welcome to the Maze", "welcomeToTheMaze")]
        [InlineData("Welcome To The Maze", "welcomeToTheMaze")]
        [InlineData("WelcomeToTheMaze", "welcomeToTheMaze")]
        [InlineData("Welcome_To_The_Maze", "welcomeToTheMaze")]
        [InlineData("ISODate", "isoDate")]
        [InlineData("IOStream", "ioStream")]
        public void GivenTitleCaseString_WhenConvertedByToCamelCase_ThenVerifyOutputAsCamelCaseString(string inputString, string expectedOutput)
        {
            var camelCaseString = inputString.ToCamelCase();

            Assert.Equal(expectedOutput, camelCaseString);
        }
    }
}