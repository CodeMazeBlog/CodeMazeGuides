using ActionAndFuncDelegatesInCsharp;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Test
{
    [TestClass]
    public class BasketballCounterUnitTest
    {
        [TestMethod]
        public void GivenFreshlyInitialisedCounter_ThenReturnCorrectScore()
        {
            var counter = new BasketballCounter();
            int score = int.MinValue;
            counter.ShowScore(x => score = x);
            
            Assert.AreEqual(0, score);
        }
        
        [TestMethod]
        public void GivenFreshlyInitialisedCounter_WhenUpdateScoreCalled_ThenReturnCorrectScore()
        {
            var counter = new BasketballCounter();
            counter.UpdateScore(x => x + 5);
            int score = int.MinValue;
            counter.ShowScore(x => score = x);

            Assert.AreEqual(score, 5);
        }

        [TestMethod]
        public void GivenFreshlyInitialisedCounter_ThenReturnCorrectScoreWithCorrectFormatting()
        {
            var counter = new BasketballCounter();            

            using (ConsoleRedirector cr = new ConsoleRedirector())
            {
                Assert.IsFalse(cr.ToString().Contains("The team's score is 0"));
                counter.ShowScore(x => Console.WriteLine($"The team's score is {x}"));
                Assert.IsTrue(cr.ToString().Contains("The team's score is 0"));
            }
        }

    }
}