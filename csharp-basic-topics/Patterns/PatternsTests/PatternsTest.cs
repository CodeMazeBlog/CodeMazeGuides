using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using static Patterns.Program;

namespace PatternsTests
{
    [TestClass]
    public class PatternsTest
    {
        [TestMethod]
        public void WhenCallingMatchTypePattern_ThenExpectedString()
        {
            try
            {
                var message = MatchTypePattern(new Patterns.Cat());
                Assert.AreEqual(message, "Meow");
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }

        [TestMethod]
        public void WhenCallingMatchConstantPattern_ThenExpectedString()
        {
            try
            {
                var name = MatchConstantPattern("Bark");
                Assert.AreEqual(name, "Dog");
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }

        [TestMethod]
        public void WhenCallingMatchRelationalPattern_ThenExpectedString()
        {
            try
            {
                var message = MatchRelationalPattern(1);
                Assert.AreEqual(message, "Less than one thousand animals");
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }

        [TestMethod]
        public void WhenCallingMatchLogicalPattern_ThenExpectedString()
        {
            try
            {
                var message = MatchLogicalPattern(20);
                Assert.AreEqual(message, "Adult animal");
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }

        [TestMethod]
        public void WhenCallingMatchPropertyPattern_ThenTrue()
        {
            try
            {
                var isDog = MatchPropertyPattern(new Patterns.Dog());
                Assert.AreEqual(isDog, true);
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }

        [TestMethod]
        public void WhenCallingMatchPositionalPattern_ThenExpectedString()
        {
            try
            {
                var message = MatchPositionalPattern(50, 10000);
                Assert.AreEqual(message, "Unhealthy adult animal weight");
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }

        [TestMethod]
        public void WhenCallingMatchVarPattern_ThenExpectedType()
        {
            try
            {
                var dog = new Patterns.Dog();
                var cloned = MatchVarPattern(dog);
                Assert.AreEqual(cloned, true);
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }
    }
}