using ActionAndFuncDelegatesInCSharp;

namespace ActionAndFuncDelegatesInCSharpTests
{
    public class BasicDelegateTests
    {
        private BasicDelegate _basicDelegate = new();

        [TestCase(23)]
        public void GivenAnAnyNumber_WhenFuncRun_ThenFormattedNumberIsSatisfactory(int number)
        {
            var result = _basicDelegate.RunFunc(number);

            var expected = $"Formatted {number}";

            Assert.That(result, Is.EqualTo(expected));
        }
    }
}