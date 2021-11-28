using ActionAndFuncInCsharp;
using NUnit.Framework;
using System;
using System.IO;

namespace Tests
{
    public class FuncAndActionUnitTest
    {
        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public void whenFuncPointingToCountMethodIsInvoked_thenResultIsSameAsMethodCountCalled()
        {
            Func<string, int> methodPointer = CountMethods.Count;
            int result = methodPointer.Invoke("Testing");

            Assert.AreEqual(result, CountMethods.Count("Testing"));
        }

        [Test]
        public void whenActionPointingToPrintCountMethodIsInvoked_thenResultIsSameAsMethodPrintCountCalled()
        {
            var stringWriter = new StringWriter();
            Console.SetOut(stringWriter);
            Action<string> voidMethodPointer = CountMethods.PrintCount;

            voidMethodPointer("Testing");
            bool result = stringWriter.ToString().Contains("7");
            Assert.True(result);

        }
    }
}