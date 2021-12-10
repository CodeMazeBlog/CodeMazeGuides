using System.Collections.Generic;
using ActionAndFuncDelegatesInCsharp;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
	public class ActionAndFuncExampleUnitTest
	{
		[TestMethod]
		public void WhenShouldNotAskHowAreYou_ThenSayHi()
		{
			var jack = new Audience
			{
				Name = "Jack",
				LikesChatting = true
			};
			var output = new List<string>();
			ActionAndFuncExample.SayHi(jack, (message, audience) => output.Add(message),
				_ => false);

			Assert.IsTrue(output.Count == 1 && output[0] == "Hi!");
		}

		[TestMethod]
		public void WhenShouldAskHowAreYou_ThenSayHiAndHowAreYou()
		{
			var jack = new Audience
			{
				Name = "Jack",
				LikesChatting = true
			};
			var output = new List<string>();
			ActionAndFuncExample.SayHi(jack, (message, audience) => output.Add(message),
				_ => true);

			Assert.IsTrue(output.Count == 2 && output[0] == "Hi!" && output[1] == "How are you?");
		}
    }
}
