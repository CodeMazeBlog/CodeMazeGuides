namespace Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using RefactoringObjectOrientationAbusers.AlternativeClassesWithDifferentInterfaces.Correct;

    [TestClass]
    public class AnimalsUnitTests
    {
        [TestMethod]
        public void WhenDogMakesSound_ThenBarkMessageIsPrinted()
        {
            // Arrange
            Dog dog = new Dog() { Name = "Buddy" };
            StringWriter sw = new StringWriter();
            Console.SetOut(sw);

            // Act
            dog.MakeSound();
            string output = sw.ToString();

            // Assert
            Assert.AreEqual("Buddy barks.\r\n", output);
        }

        [TestMethod]
        public void WhenCatMakseSound_ThenMeowMessageIsPrinted()
        {
            // Arrange
            Cat cat = new Cat() { Name = "Fluffy" };
            StringWriter sw = new StringWriter();
            Console.SetOut(sw);

            // Act
            cat.MakeSound();
            string output = sw.ToString();

            // Assert
            Assert.AreEqual("Fluffy meows.\r\n", output);
        }
    }

}
