using System;
using System.IO;
using System.Text;
using Xunit;

namespace AnctionsAndFuncExmaplesTests
{
    public class ActionFuncDelegatesTest
    {
        private class Operations
        {
            public int Add(int a, int b)
            {
                return a + b;
            }

            public static int Multiply(int a, int b)
            {
                return a * b;
            }

        }

        private class DisplayHelper
        {
            public void DisplayTextWithHiPrefix(string value)
            {
                Console.WriteLine("Hi, " + value);
            }

            public static void DisplayTextWithHelloPrefix(string value)
            {
                Console.WriteLine("Hello, " + value);
            }
        }

        //point to a method which accepts two integer parameters
        //and returns an integer
        delegate int Calculator(int left, int right);

        //point to a method which accepts one string parameter
        //and returns nothing
        delegate void Display(string value);

        [Fact]
        public void WhenFuncTypeIsUsed_ThenMethodsShouldHaveReturnValue()
        {
            //given
            Func<int, int, int> funcPointingToNamedMethod = new Operations().Add;
            Func<int, int, int> funcPointingToAnonymousMethod = delegate (int a, int b) { return a - b; };
            Func<int, int, int> funcPointingToStaticMethod = Operations.Multiply;
            Func<int, int, int> funcPointingToLambda = (a, b) => a / b;

            //when
            var additionResult = funcPointingToNamedMethod(6, 3);
            var subtractionResult = funcPointingToAnonymousMethod(6, 3);
            var multiplyResult = funcPointingToStaticMethod(6, 3);
            var divisionResult = funcPointingToLambda(6, 3);

            //then
            Assert.Equal(9, additionResult);
            Assert.Equal(3, subtractionResult);
            Assert.Equal(18, multiplyResult);
            Assert.Equal(2, divisionResult);
        }

        [Fact]
        public void WhenDelegateTypeIsUsed_ThenMethodsCanHaveReturnValue()
        {
            //given
            Calculator delegatePointingToNamedMethod = new Operations().Add;
            Calculator delegatePointingToAnonymousMethod = delegate (int a, int b) { return a - b; };
            Calculator delegatePointingToStaticMethod = Operations.Multiply;
            Calculator delegatePointingToLambda = (a, b) => a / b;

            //when
            var additionResult = delegatePointingToNamedMethod(6, 3);
            var subtractionResult = delegatePointingToAnonymousMethod(6, 3);
            var multiplyResult = delegatePointingToStaticMethod(6, 3);
            var divisionResult = delegatePointingToLambda(6, 3);

            //then
            Assert.Equal(9, additionResult);
            Assert.Equal(3, subtractionResult);
            Assert.Equal(18, multiplyResult);
            Assert.Equal(2, divisionResult);
        }

        [Fact]
        public void WhenDelegateTypeIsUsed_ThenMethodsCanHaveNoReturnValue()
        {
            //given
            Display delegatePointingToNamedMethod = new DisplayHelper().DisplayTextWithHiPrefix;
            Display delegatePointingToAnonymousMethod = delegate (string value) { Console.WriteLine("Hola, " + value); };
            Display delegatePointingToStaticMethod = DisplayHelper.DisplayTextWithHelloPrefix;
            Display delegatePointingToLambda = (value) => Console.WriteLine(value);

            StringBuilder sb = new StringBuilder();
            using TextWriter tw = new StringWriter(sb);
            Console.SetOut(tw);

            //when
            delegatePointingToNamedMethod("Named Method");
            delegatePointingToAnonymousMethod("Anonymous Method");
            delegatePointingToStaticMethod("Static Method");
            delegatePointingToLambda("Lambda");

            //then
            var result = sb.ToString();
            Assert.Equal("Hi, Named Method\r\nHola, Anonymous Method\r\nHello, Static Method\r\nLambda\r\n", result);
        }

        [Fact]
        public void WhenActionTypeIsUsed_ThenMethodsShouldHaveNoReturnValue()
        {
            //given
            Action<string> actionPointingToNamedMethod = new DisplayHelper().DisplayTextWithHiPrefix;
            Action<string> actionPointingToAnonymousMethod = delegate (string value) { Console.WriteLine("Hola, " + value); };
            Action<string> actionPointingToStaticMethod = DisplayHelper.DisplayTextWithHelloPrefix;
            Action<string> actionPointingToLambda = (value) => Console.WriteLine(value);

            StringBuilder sb = new StringBuilder();
            using TextWriter tw = new StringWriter(sb);
            Console.SetOut(tw);

            //when
            actionPointingToNamedMethod("Named Method");
            actionPointingToAnonymousMethod("Anonymous Method");
            actionPointingToStaticMethod("Static Method");
            actionPointingToLambda("Lambda");

            //then
            var result = sb.ToString();
            Assert.Equal(
                String.Format("Hi, Named Method{0}Hola, Anonymous Method{0}Hello, Static Method{0}Lambda{0}",
                    System.Environment.NewLine),
                result);
        }


    }
}