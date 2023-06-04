using DelegatesDemo;
using Xunit;

namespace DelegatesTests
{
    public class DelegatesUnitTests
    {
        private readonly DelegateDemo delegateDemo;
        private readonly FuncDemo funcDemo;
        private readonly ActionDemo actionDemo;
        private readonly PredicateDemo predicateDemo;
        public DelegatesUnitTests()
        {
            delegateDemo = new DelegateDemo();
            funcDemo = new FuncDemo();
            actionDemo = new ActionDemo();
            predicateDemo = new PredicateDemo();
        }

        [Fact]
        public void RunDelegate_UpdatesValueAndPrintsCorrectValues()
        {
            delegateDemo.Value = 0;

            int expectedValue1 = 25;
            int expectedValue2 = 125;

            using (var sw = new StringWriter())
            {
                Console.SetOut(sw);

                delegateDemo.RunDelegate();

                string[] lines = sw.ToString().Trim().Split(Environment.NewLine);

                Assert.Equal($"Value of Num: {expectedValue1}", lines[0]);
                Assert.Equal($"Value of Num: {expectedValue2}", lines[1]);
            }
        }

        [Fact]
        public void RunFunc_SumAndMultiplyAndPrintsCorrectValues()
        {
            funcDemo.value1 = 0;
            funcDemo.value2 = 2;
            string expectedValue1 = "0";
            string expectedValue2 = "2";

            using (var sw = new StringWriter())
            {
                Console.SetOut(sw);

                funcDemo.RunFunc();

                string[] lines = sw.ToString().Trim().Split(Environment.NewLine);

                Assert.Equal(expectedValue1, lines[0]);
                Assert.Equal(expectedValue2, lines[1]);
            }
        }

        [Fact]
        public void RunAction_DisplayCorrectValue()
        {
            actionDemo.nameToDisplay = "mark";

            using (var sw = new StringWriter())
            {
                Console.SetOut(sw);

                actionDemo.RunAction();

                string[] lines = sw.ToString().Trim().Split(Environment.NewLine);

                Assert.Equal($"Hello, MARK!", lines[0]);
            }
        }

        [Fact]
        public void RunPredicate_DisplayCorrectValue()
        {
            predicateDemo.stringToCheck = "mark";

            using (var sw = new StringWriter())
            {
                Console.SetOut(sw);

                predicateDemo.RunPredicate();

                string[] lines = sw.ToString().Trim().Split(Environment.NewLine);

                Assert.Equal($"True", lines[0]);
            }
        }
    }
}