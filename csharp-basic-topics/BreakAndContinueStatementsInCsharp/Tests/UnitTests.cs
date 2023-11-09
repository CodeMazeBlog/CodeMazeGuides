using Microsoft.VisualStudio.TestTools.UnitTesting;
using BreakAndContinueStatementsInCsharp;
using System;
using System.IO;
using System.Text;

namespace Tests
{
    [TestClass]
    public class UnitTests
    {
        StringWriter stringWriter = new StringWriter();

        public UnitTests()
        {
            //arrange
            Console.SetOut(stringWriter);
        }

        [TestMethod]
        public void whenBreakLoopAt5IsCalled_MethodPrintsCorrectLoopValues()
        {
            // arrange
            StringBuilder sb = new StringBuilder();
            for(var i = 1; i < 5; i++)
            {
                sb.AppendLine($"Our current number is: {i}");
            }
            var expected = sb.ToString();

            // act
            Program.BreakLoopAt5();
            var output = stringWriter.ToString();

            // assert
            Assert.AreEqual(expected, output);
        }

        [TestMethod]
        public void whenContinueLoopForNonMultipesOf3IsCalled_MethodPrintsCorrectLoopValues()
        {
            // arrange
            StringBuilder sb = new StringBuilder();
            for (var i = 3; i < 10; i+=3)
            {
                sb.AppendLine($"{i} is a multiple of 3");
            }
            var expected = sb.ToString();

            // act
            Program.ContinueLoopForNonMultipesOf3();
            var output = stringWriter.ToString();

            // assert
            Assert.AreEqual(expected, output);
        }
    }
}
