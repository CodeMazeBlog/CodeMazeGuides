using StaticVsNonstaticMethods;

namespace Tests
{
    [TestClass]
    public class TwoDimensionalObjectTest
    {
        [TestMethod]
        public void GivenTwoDimensionalObject_WhenCallingSurface_ThenCorrectAreaShouldBePrinted()
        {
            var twoDimensionalObject = new TwoDimensionalObject();
            var output = twoDimensionalObject.Surface();

            var expectedLine = "This object does not have a surface.";

            Assert.AreEqual(output, expectedLine);
        }

        [TestMethod]
        public void GivenTwoDimensionalObject_WhenCallingDescription_ThenCorrectDescriptionShouldBePrinted()
        {
            var output = TwoDimensionalObject.Description();
            var expectedLine = "This is a basic 2D object";

            Assert.AreEqual(output, expectedLine);
        }
    }
}
