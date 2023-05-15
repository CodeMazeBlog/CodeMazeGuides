using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using ActionAndFuncDelegatesInCSharp;

namespace Tests
{
    [TestClass]
    public class ActionAndFuncDelegatesInCSharpUnitTest
    {
        [TestMethod]
        public void GivenADelegate_WhenSayingCurrentDate_ThenReturnCurrentDate()
        {
            var delegateMock = new Mock<DelegateExample.SayDate>();
            delegateMock.Setup(_ => _()).Returns(DateTime.Today);
            var subject = new DelegateExample();

            var expected = delegateMock.Object.Invoke();
            var actual = subject.SayCurrentDate();

            delegateMock.Verify(_ => _(), Times.Once);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GivenAnAction_WhenDisplayingWelcomeMessageToNewReader_ThenDisplayWelcomeMessage()
        {
            var actionMock = new Mock<Action<string>>();
            actionMock.Setup(_ => _("Samuel"));
            var subject = new ActionExample();
            var expected = "Hello Samuel! Welcome to CodeMaze, the best C# blog";

            actionMock.Object.Invoke("Samuel");
            subject.DisplayWelcomeMessageToNewReader("Samuel");

            actionMock.Verify(_ => _(It.IsAny<string>()), Times.Once);
            Assert.AreEqual(expected, subject.TextToDisplay);
        }

        [TestMethod]
        public void GivenAFunc_WhenDisplayingWelcomeMessageToUser_ThenReturnWelcomeMessage()
        {
            var funcMock = new Mock<Func<string>>();
            funcMock.Setup(_ => _()).Returns("Hello! Welcome to a new day");
            var subject = new FuncExampleOne();

            var expected = funcMock.Object.Invoke();
            var result = subject.DisplayWelcomeMessageToUser();

            funcMock.Verify(_ => _(), Times.Once);
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void GivenAFunc_WhenChangingTextToUpperCase_ThenReturnTextInUpperCase()
        {
            var funcMock = new Mock<Func<string, string>>();
            funcMock.Setup(_ => _("codemaze is great")).Returns("CODEMAZE IS GREAT");
            var subject = new FuncExampleTwo();

            var expected = funcMock.Object.Invoke("codemaze is great");
            var result = subject.ChangeTextToUpperCase("codemaze is great");

            funcMock.Verify(_ => _(It.IsAny<string>()), Times.Once);
            Assert.AreEqual(expected, result);
        }
    }
}