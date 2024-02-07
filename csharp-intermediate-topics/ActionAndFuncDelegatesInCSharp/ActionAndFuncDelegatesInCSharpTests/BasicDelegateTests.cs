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

        [TestCase(8)]
        public void Given_An_Any_Number_When_Delegate_Run_Then_Execution_Is_Satifactory(int number)
        {
            BasicDelegate.Run(number);
        }

        [TestCase(5)]
        public void Given_An_Any_Number_When_Action_Run_Then_Execution_Is_Satifactory(int number)
        {
            BasicDelegate.RunAction(number);
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