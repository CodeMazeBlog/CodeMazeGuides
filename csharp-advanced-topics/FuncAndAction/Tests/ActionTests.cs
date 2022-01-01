using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Tests
{
    [TestClass]
    public class ActionTests
    {

        [TestMethod]
        public void WhenPassingStringToActionThenStringIsCapitalized()
        {
            string Text = "hello world";
            void Capitalize()
            {
                Text = Text.ToUpper();
            }
            var capitalizeAction = new Action(Capitalize);
            capitalizeAction();
            Assert.AreEqual(Text, "hello world".ToUpper());
        }

        [TestMethod]
        public void WhenPassingStringToAnonymousActionThenStringIsCapitalized()
        {
            string Text = "hello world";
            var anonymousCapitalizeAction = new Action(() => Text = Text.ToUpper());
            anonymousCapitalizeAction();
            Assert.AreEqual(Text, "hello world".ToUpper());
        }
    }
}
