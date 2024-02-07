using ActionAndFuncDelegatesInCSharp;

namespace ActionAndFuncDelegatesInCSharpTests
{
    public class BasicDelegateTests
    {
        private BasicDelegate BasicDelegate;


        [SetUp]
        public void Setup()
        {
            BasicDelegate = new BasicDelegate();
        }

        [TestCase(23)]
        public void Given_An_Any_Number_When_Func_Run_Then_Formatted_Number_Is_Satisfactory(int number)
        {
            var result = BasicDelegate.RunFunc(number);

            var expected = $"Formatted {number}";
            Assert.That(result, Is.EqualTo(expected));
        }
    }
}