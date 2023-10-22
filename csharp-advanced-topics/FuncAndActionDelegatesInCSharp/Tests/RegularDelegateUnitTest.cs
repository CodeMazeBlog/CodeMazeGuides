using FuncAndActionDelegatesInCSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests
{
    public delegate string GenerateText(string word, int number);

    public class RegularDelegateUnitTest
    {
        string PrintSomething(string word, int number)
        {
            return word + number;
        }

        [Fact]
        public void WhenReferencesAMethod_ThenCallsReferencedMethod()
        {
            // Arrange
            GenerateText Generate = PrintSomething;

            // Act
            var resultFromMethod = PrintSomething("day ", 2);
            var resultFromDelegate = Generate("day ", 2);

            // Assert
            var expected = resultFromMethod == resultFromDelegate;
            Assert.True(expected);
        }
    }
}
