using System.Diagnostics;
using System.Text;

namespace ActionFuncInCSharp.Tests
{
    public class ActionExamplesUnitTest
    {
        [Fact]
        public void WhenAssignAnonymousMethodToActionDelegate_ThenActionCallSuccessfully()
        {
            MemoryStream ms = new MemoryStream();
            var sw = new StreamWriter(ms);
            sw.AutoFlush = true;
            Console.SetOut(sw);
            Action<string> sayHelloAction = (string name) => Console.WriteLine("Hello {0}", name);
            sayHelloAction("Ahmad");

            var actual = Encoding.UTF8.GetString(ms.ToArray(), 0, (int)ms.Length);
            Assert.Equal("Hello Ahmad", actual.TrimEnd());
        }

        [Theory]
        [InlineData(3, 2)]
        public void WhenAssignMultipleMethodsToActionDelegate_ThenActionDelegateCallsTheMethodsSuccessfullyInOrder(int numberOne, int numberTwo)
        {
            var intBasicCalculator = new IntBasicCalculator();
            MemoryStream ms = new MemoryStream();
            var sw = new StreamWriter(ms);
            sw.AutoFlush = true;
            Console.SetOut(sw);

            Action<int, int> calcPrintAction = intBasicCalculator.AdditionPrint;
            calcPrintAction += intBasicCalculator.SubtractionPrint;
            calcPrintAction += intBasicCalculator.MultiplicationPrint;
            calcPrintAction += intBasicCalculator.DivisionPrint;

            calcPrintAction(numberOne, numberTwo);
            var actualTemp = Encoding.UTF8.GetString(ms.ToArray(), 0, (int)ms.Length);
            var actual = actualTemp.ToString()
                .Split("\r\n")
                .SkipLast(1)
                .Select(s => int.Parse(s))
                .ToArray();

            var expected = new int[]
{
              numberOne + numberTwo,
              numberOne - numberTwo,
              numberOne * numberTwo,
              numberOne / numberTwo,
};

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void WhenAddingMethodsToActionDelegate_ThenInvocationListLengthShouldbeEqualToNumberOfMethods()
        {
            IntBasicCalculator intBasicCalculator = new();
            Action<int, int> calcPrintAction = intBasicCalculator.AdditionPrint;
            calcPrintAction += intBasicCalculator.SubtractionPrint;
            calcPrintAction += intBasicCalculator.MultiplicationPrint;
            calcPrintAction += intBasicCalculator.DivisionPrint;

            Assert.Equal(4, calcPrintAction.GetInvocationList().Length);
        }

        [Fact]
        public void WhanPassCallbackMethod_ThenActionCallSuccessfully()
        {
            var writer = new StringWriter();
            Console.SetOut(writer);

            void printInt(int number)
            {
                Console.WriteLine("the number is {0}", number);
            }

            var actionExamples = new ActionExamples();
            actionExamples.CalculateAndPrint(4, 5, printInt);
            var actual = writer.ToString().Trim();
            var expected = "the number is 9";

            Assert.Equal(expected, actual);
        }

    }
}
