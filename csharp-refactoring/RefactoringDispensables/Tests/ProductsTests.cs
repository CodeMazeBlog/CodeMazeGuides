using RefactoringDispensables.DuplicatedCode.Correct;

namespace Tests
{
    [TestClass]
    public class ProductsTests
    {
        [TestMethod]
        public void WhenGettingMaterialsAsString_ThenCommaSeparatedStringShouldBeReturned()
        {
            // Arrange
            ICollection<string> materials = new List<string> { "Wool", "Cotton", "Silk" };
            var scarf = new Scarf(materials);

            // Act
            string materialsAsString = scarf.GetMaterialsAsString();

            // Assert
            string expected = "Wool,Cotton,Silk";
            Assert.AreEqual(expected, materialsAsString);
        }
    }
}
