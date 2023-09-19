using Moq;


namespace ActionandFuncDelagates.Tests
{
    [TestClass()]
    public class UnitTest
    {
        [TestMethod()]
        public void AddTest()
        {
            //arrange
            int[] nums = { 4, 4 } ;
            var TestAdd = new Mock<Func<int,int,int>>();
            TestAdd.Setup(func => func(It.IsAny<int>(), It.IsAny<int>()));
            var AddOperation = new Program(TestAdd.Object, null);
            //act
            var result = AddOperation.Add(nums[0], nums[1]);

            //assert
            Assert.AreEqual(8, result);
        }

        [TestMethod()]
        public void ActionMethodTest()
        {
            //arrange
            int[] nums = { 4, 4 };
            var TestAdd = new Mock<Action<int, int>>();
            var Operation = new Program(null, TestAdd.Object);

            // Capture the console output for assertions
            using (var consoleOutput = new ConsoleOutput())
            {

                //act
                Operation.ActionMethod(nums[0], nums[1]);

                //assert
                Assert.AreEqual($"{nums[0] * nums[1]}\r\n", consoleOutput.GetOuput());
            }
        }

        //helper class to capture console output for the actionmethod
        private class ConsoleOutput : IDisposable
        {
            private StringWriter stringWriter;
            private TextWriter originalOutput;

            public ConsoleOutput()
            {
                stringWriter = new StringWriter();
                originalOutput = Console.Out;
                Console.SetOut(stringWriter);
            }

            public string GetOuput()
            {
                return stringWriter.ToString();
            }

            public void Dispose()
            {
                stringWriter.Dispose();
                Console.SetOut(originalOutput);
            }
        }


    }
}

