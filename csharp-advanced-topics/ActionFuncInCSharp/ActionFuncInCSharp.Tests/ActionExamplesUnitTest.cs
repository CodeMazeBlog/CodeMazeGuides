using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Text;

namespace ActionFuncInCSharp.Tests
{
    public class ActionExamplesUnitTest
    {
        StringWriter _writer;

        public ActionExamplesUnitTest()
        {
            _writer = new StringWriter();
            Console.SetOut(_writer);
        }

        [Fact]
        public void WhenAssignAnonymousMethodToActionDelegate_ThenActionCallSuccessfully()
        {
            _writer.Flush();
            Action<string> sayHelloAction = (string name) => Console.WriteLine("Hello {0}", name);
            sayHelloAction("Ahmad");

            var actual = _writer.ToString();

            Assert.Equal("Hello Ahmad", actual.TrimEnd());
        }

        [Theory]
        [InlineData(3, 2)]
        public void WhenAssignMultipleMethodsToActionDelegate_ThenActionDelegateCallsTheMethodsSuccessfullyInOrder(int numberOne, int numberTwo)
        {
            var intBasicCalculator = new IntBasicCalculator();
            _writer.Flush();
            Action<int, int> calcPrintAction = intBasicCalculator.AdditionPrint;
            calcPrintAction += intBasicCalculator.SubtractionPrint;
            calcPrintAction += intBasicCalculator.MultiplicationPrint;
            calcPrintAction += intBasicCalculator.DivisionPrint;

            calcPrintAction(numberOne, numberTwo);

            var actual = _writer.ToString().Split("\n").SkipLast(1).Select(s => int.Parse(s)).ToArray();
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
            _writer.Flush();
            void PrintInt(int number)
            {
                Console.WriteLine("the number is {0}", number);
            }

            var actionExamples = new ActionExamples();
            actionExamples.CalculateAndPrint(4, 5, PrintInt);
            var actual = _writer.ToString().Trim();
            var expected = "the number is 9";

            Assert.Equal(expected, actual);
        }

    }
}
