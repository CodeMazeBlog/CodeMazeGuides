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
        public void GivenAnAnyNumber_WhenFuncRun_ThenFormattedNumberIsSatisfactory(int number)
        {
            var result = BasicDelegate.RunFunc(number);

            var expected = $"Formatted {number}";

            Assert.That(result, Is.EqualTo(expected));
        }
    }
}