using FuncAndActionCsharp;

namespace Tests
{
    [TestFixture]
    public class DelegateExampleTests
    {
        [Test]
        public void TestGreetingDelegate()
        {
            // Arrange
            DelegateExample delegateExample = new DelegateExample();
            StringWriter stringWriter = new StringWriter();
            Console.SetOut(stringWriter);

            // Act
            DelegateExample.Say say = delegateExample.Greeting;
            say("Hello");

            // Assert
            Assert.That(stringWriter.ToString(), Is.EqualTo("Hello\r\n"));
        }

        [Test]
        public void TestAddDelegate()
        {
            // Arrange
            DelegateExample delegateExample = new DelegateExample();

            // Act
            DelegateExample.Calculate calculate = delegateExample.Add;
            int result = calculate(2, 3);

            // Assert
            Assert.That(result, Is.EqualTo(5));
        }

        [Test]
        public void TestCheckDelegate()
        {
            // Arrange
            DelegateExample delegateExample = new DelegateExample();
            StringWriter stringWriter = new StringWriter();
            Console.SetOut(stringWriter);

            // Act
            delegateExample.CheckDelegate();

            // Assert
            Assert.That(stringWriter.ToString(), Is.EqualTo("Results using delegates\r\nHello\r\n5\r\n"));
        }
    }

}