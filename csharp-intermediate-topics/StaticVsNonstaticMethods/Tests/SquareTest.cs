using StaticVsNonstaticMethods;

namespace Tests
{
    [TestClass]
    public class SquareTest
    {
        [TestMethod]
        [DataRow(1, 1)]
        [DataRow(3, 9)]
        [DataRow(5, 25)]
        [DataRow(0, 0)]
        [DataRow(-1, 1)]
        [DataRow(-3, 9)]
        [DataRow(-5, 25)]
        public void GivenSquareSideLength_WhenCallingSurface_ThenCorrectAreaShouldBePrinted(int sideLength, int area)
        {
            var square = Square.Create(sideLength);
            var output = square.Surface();

            var expectedLine1 = "Base object's surface: This object does not have a surface.";
            var expectedLine2 = $"Square object's surface: {area}";
            var expectedOutput = $"{expectedLine1}{Environment.NewLine}{expectedLine2}";

            Assert.AreEqual(output, expectedOutput);
        }

        [TestMethod]
        public void GivenSquare_WhenCallingDescription_ThenCorrectDescriptionShouldBePrinted()
        {
            var output = Square.Description();

            var expectedLine1 = "Base object's description: This is a basic 2D object";
            var expectedLine2 = "Square object's description: This is a square";
            var expectedOutput = $"{expectedLine1}{Environment.NewLine}{expectedLine2}";

            Assert.AreEqual(output, expectedOutput);
        }
    }
}
