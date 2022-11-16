namespace ActionFuncInCSharp.Tests
{
    public class DelegateTest
    {
        BasicCalculator basicCalculator;

        public DelegateTest()
        {
            basicCalculator = new BasicCalculator();
        }

        [Fact]
        public void InvocationListShouldbeEqualToNumberOfMethods()
        {

            Action<int, int> calcPrintAction = basicCalculator.AdditionPrint;
            calcPrintAction += basicCalculator.SubtractionPrint;
            calcPrintAction += basicCalculator.MultiplicationPrint;
            calcPrintAction += basicCalculator.DivisionPrint;
            Assert.Equal(4, calcPrintAction.GetInvocationList().Length);
        }

        [Fact]
        public void ShouldActionDelegateCalledSuccessfully()
        {

            var writer = new StringWriter();
            Console.SetOut(writer);
            Action<string> sayHelloAction = (string name) => Console.WriteLine("Hello {0}", name);

            sayHelloAction("Ahmad");

            var sb = writer.GetStringBuilder();

            Assert.Equal("Hello Ahmad", sb.ToString().TrimEnd());
        }

        [Fact]
        public void ShouldFuncDelegateCalledSuccessfully_FloatResult()
        {
            Func<float, float, float> calcFunc = basicCalculator.Addition;

            Assert.Equal(5.2f, calcFunc(2.1f, 3.1f));
        }

        [Fact]
        public void ShouldFuncDelegateCalledSuccessfully_ListResult()
        {
            List<string> progLang = new() { "C", "C++", "C#", "F#", "Rust", "Go" };

            Func<string, bool> whereFunc = (string s) => s.Contains('C');

            List<string> cLang = progLang.Where(whereFunc).ToList();

            Assert.All(cLang, item => Assert.Contains('C', item));
        }
    }
}