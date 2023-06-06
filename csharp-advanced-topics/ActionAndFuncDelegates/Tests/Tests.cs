using ActionAndFuncDelegates;

namespace Tests
{
    [TestClass]
    public class Tests
    {
        [TestMethod]
        public void WhenStringIsPassed_DisplaysItemInConsole()
        {
            //arrange
            var example = new Example();

            var stringWriter = new StringWriter();
            Console.SetOut(stringWriter);

            //act
            example.ActionDemo();

            //assert
            // List<string> items = new List<string>() { "Foo", "Bar", "Bob", "Alice" };
            var outputLines = stringWriter.ToString().Split(Environment.NewLine.ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
            Assert.AreEqual("Foo", outputLines[0]);
        }

        [TestMethod]
        public void WhenStringIsPassed_ConvertsItemToLowercase()
        {
            //arrange
            var example = new Example();

            var stringWriter = new StringWriter();
            Console.SetOut(stringWriter);

            //act
            example.FuncDemo();

            //assert
            // List<string> items = new List<string>() { "Foo", "Bar", "Bob", "Alice" };
            var outputLines = stringWriter.ToString().Split(Environment.NewLine.ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
            Assert.AreEqual("foo", outputLines[0]);
        }
    }
}