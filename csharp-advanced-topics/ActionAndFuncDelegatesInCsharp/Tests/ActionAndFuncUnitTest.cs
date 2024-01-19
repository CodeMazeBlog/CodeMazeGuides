using ActionAndFuncDelegatesInCsharp;

namespace Tests
{
	public class ActionAndFuncUnitTest
	{
		[Fact]
		public void WhenActionDelegateIsCalled_ThenAddActionNumbersMethodIsInvoked()
		{
			int a = 4, b = 8;
			Program.AddActionNumbers(a, b);
		}

		[Fact]
		public void WhenFuncDelegateIsCalled_ThenAddFuncNumbersMethodIsInvoked()
		{
			int i = 4, j = 8;
			int expectedSum = i + j;
			int actualSum = Program.AddFuncNumbers(i, j);
			Assert.Equal(expectedSum, actualSum);
		}
	}
}