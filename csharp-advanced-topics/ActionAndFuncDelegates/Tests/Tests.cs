using ActionAndFuncDelegates;

namespace Tests
{
    [TestClass]
    public class Tests
    {
        private Example Example { get; set; }
        private StringWriter StringWriter { get; set; }

        public Tests()
        {
            this.Example = new Example();
            this.StringWriter = new StringWriter();
            Console.SetOut(this.StringWriter);
        }

        [TestMethod]
        public void WhenStringIsPassed_ThenDisplaysItemInConsole()
        {
            //act
            this.Example.ActionDemo();

            //assert
            var outputLines = this.StringWriter.ToString().Split(Environment.NewLine.ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
            Assert.AreEqual("Foo", outputLines[0]);
        }

        [TestMethod]
        public void WhenStringIsPassed_ThenConvertsItemToLowercase()
        {
            //act
            this.Example.FuncDemo();

            //assert
            var outputLines = this.StringWriter.ToString().Split(Environment.NewLine.ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
            Assert.AreEqual("foo", outputLines[0]);
        }
    }
}