using ActionAndFunc;

namespace Tests
{
    public class UnitTests
    {
        [Fact]
        public void whenActionDelegate_DelegateInvocationListNotEmpty()
        {
            Action<string> toppingAction = Program.PrintToping;
            var invocationList = toppingAction.GetInvocationList();
            Assert.Single(invocationList);
        }
    }
}