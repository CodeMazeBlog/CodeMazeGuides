using FuncActionDelegate;

namespace Test
{
    [TestFixture]
    public class ActionFuncSampleTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Given_ListOfNames_When_GreetingIsCalled_Then_ShouldPrintCorrectMessages()

        {
            var names = new List<string> { "Alice", "Bob", "Charlie" };
            var actionSample = new ActionSample();
            var output = new StringWriter();

            Console.SetOut(output);

            actionSample.Greeting(names);

            
            var outputString = output.ToString();

            StringAssert.Contains("Hello, Alice!", outputString);
            StringAssert.Contains("Hello, Bob!", outputString);
            StringAssert.Contains("Hello, Charlie!", outputString);

            
            Console.SetOut(Console.Out);
        }

        [Test]
        public void Given_ListOfIntegers_When_FilterAndSumIsCalled_Then_ShouldReturnSumOfEvenNumbers()
        {

            var numbers = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            var funcSample = new FuncSample();

           
            int result = funcSample.FilterAndSum(numbers);

           
            Assert.That(result, Is.EqualTo(30)); 
        }
    }
}