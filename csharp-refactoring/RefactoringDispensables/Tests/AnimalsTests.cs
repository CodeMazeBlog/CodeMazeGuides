using RefactoringDispensables.DuplicatedCode.Correct;

namespace Tests
{
    [TestClass]
    public class AnimalsTests
    {
        [TestMethod]
        public void WhenGettingToysAsString_ThenCommaSeparatedStringShouldBeReturned()
        {
            // Arrange
            ICollection<string> toys = new List<string> { "Toy 1", "Toy 2", "Toy 3" };
            var cat = new Cat
            {
                Toys = toys
            };

            // Act
            string toysAsString = cat.GetToysAsString();

            // Assert
            string expected = "Toy 1,Toy 2,Toy 3";
            Assert.AreEqual(expected, toysAsString);
        }
    }
}
