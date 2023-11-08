using CodeMazeGuides.Sample.Delegates;

namespace CodeMazeGuides.Sample.DelegatesTests
{
	public class ActionDelegatesTests
	{
		[SetUp]
		public void Setup()
		{
		}

		[Test]
		public void WelcomeToActionDelegateTest()
		{
			ActionDelegates.welcomeToActionDelegate();
			Assert.True(true);
		}

		[Test]
		public void WelcomeToActionDelegateWithParam()
		{
			ActionDelegates.welcomeToActionDelegateWithParam("Oluleke");
			Assert.True(true);
		}

		[Test]
		public void ProductOfTwoNosTest()
		{
			ActionDelegates.productOfTwoNos(3,4);
			Assert.True(true);
		}

		[Test]
		public void DisplayStdInfo()
		{
			ActionDelegates.displayStdInfo("Michaiah Ezra",12, "Michelle Ezra", 8)			;
			Assert.True(true);
		}

		
	}
}