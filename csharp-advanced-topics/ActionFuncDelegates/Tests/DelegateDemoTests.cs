using ActionFuncDelegates;

namespace Tests
{
    [TestClass()]
    public class DelegateDemoTests
    {
        StringWriter stringWriter = new StringWriter();

        public DelegateDemoTests()
        {
            //Arrange
            Console.SetOut(stringWriter);
        }


        [TestMethod]
        public void WhenActionDelegateInvoked_ThenCorrectValueDisplayed()
        {
            //Act
            Program.Greet("PHP");
            var output = stringWriter.ToString().Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);
            var expected = "Welcome to PHP demo!";
            
            //Assert
            Assert.AreEqual(output[0], expected);
        }
      
        [TestMethod]
        public void WhenFuncDelegateInvoked_ThenCorrectValueDisplayed()
        {                      
            var expected = Program.ConvertMethod("florida");
            
            Assert.AreEqual(expected, "Florida");
        }
    }
}