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
            var dog = new Dog() { Name = "Buddy" };
            var sw = new StringWriter();
            Console.SetOut(sw);

            // Act
            dog.MakeSound();
            var output = sw.ToString();

            // Assert
            Assert.IsTrue(output.Contains(dog.Name) && output.Contains("barks"));
        }

        [TestMethod]
        public void WhenCatMakesSound_ThenMeowMessageIsPrinted()
        {
            // Arrange
            var cat = new Cat() { Name = "Fluffy" };
            var sw = new StringWriter();
            Console.SetOut(sw);

            // Act
            cat.MakeSound();
            var output = sw.ToString();

            // Assert
            Assert.IsTrue(output.Contains(cat.Name) && output.Contains("meows"));
        }
    }

}
