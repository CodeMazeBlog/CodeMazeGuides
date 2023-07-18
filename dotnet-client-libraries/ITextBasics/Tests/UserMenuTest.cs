using ITextBasics;
using ITextBasics.ConsoleManager;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Text;

namespace Tests
{
    [TestClass]
    public class UserMenuTest
    {
        [TestMethod]
        public void GivenKey_WhenGettingUserInput_ThenExpectCorrectAction()
        {
            StringBuilder screenOutput = new();
            List<ConsoleKeyInfo> pressedKeys = new()
            {
                new ConsoleKeyInfo('1', ConsoleKey.D1, false, false, false),
                new ConsoleKeyInfo('x', ConsoleKey.X, false, false, false),
                new ConsoleKeyInfo('k', ConsoleKey.K, false, false, false),
                new ConsoleKeyInfo('3', ConsoleKey.D3, false, false, false)
            };

            FakeConsole console = new(screenOutput, pressedKeys);
            UserMenu userMenu = new(console);

            Assert.AreEqual(UserMenu.UserAction.CreateBasicPDF, userMenu.GetSelection());
            Assert.AreEqual(UserMenu.UserAction.Exit, userMenu.GetSelection());
            Assert.AreEqual(UserMenu.UserAction.Unknown, userMenu.GetSelection());
            Assert.AreEqual(UserMenu.UserAction.CreateAdvancedMoreParagraphsPDF, userMenu.GetSelection());
        }
    }
}
