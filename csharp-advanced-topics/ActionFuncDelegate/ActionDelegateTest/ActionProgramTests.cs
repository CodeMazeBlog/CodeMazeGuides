namespace ActionFuncDelegateTests
{
    public class ActionProgramTests
    {
        private StringWriter stringWriter;

        [SetUp]
        public void SetUp()
        {
            stringWriter = new StringWriter();
            Console.SetOut(stringWriter);
        }

        [TearDown]
        public void TearDown()
        {
            stringWriter.Dispose();
            var standardOutput = new StreamWriter(Console.OpenStandardOutput());
            Console.SetOut(standardOutput);
        }

        [Test]
        public void TestActionDelegateWithZeroParameter()
        {
            //Arrange
            Action actionDelegateWithZeroParameter = () => Console.WriteLine("Action delegate with zero parameter and return void");

            //Act
            actionDelegateWithZeroParameter();

            //Assert
            Assert.That(stringWriter.ToString(), Is.EqualTo("Action delegate with zero parameter and return void\n"));
        }

        [Test]
        public void TestActionDelegateWithOneParameter()
        {
            //Arrange
            Action<string> actionDelegateWithOneParameter = (message) => Console.WriteLine(message);
            string expectedMessage = "Action delegate with one parameter and return void";

            //Act
            actionDelegateWithOneParameter(expectedMessage);

            //Assert
            Assert.That(stringWriter.ToString(), Is.EqualTo(expectedMessage + "\n"));
        }

        [Test]
        public void TestActionDelegateWithTwoParameters()
        {
            //Arrange
            Action<int, int> actionDelegateWithTwoParameters = (value1, value2) => Console.WriteLine($"The Action delegate can take {value1} to {value2} parameters and returns void");
            int expectedValue1 = 0;
            int expectedValue2 = 16;

            //Act
            actionDelegateWithTwoParameters(expectedValue1, expectedValue2);

            //Assert
            Assert.That(stringWriter.ToString(), Is.EqualTo($"The Action delegate can take {expectedValue1} to {expectedValue2} parameters and returns void\n"));
        }
    }
}
