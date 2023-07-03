using Microsoft.VisualStudio.TestTools.UnitTesting;
using ValueAndReferenceTypes;
namespace Tests
{
    [TestClass]
    public class UnitTest
    {
        [TestMethod]
        public void WhenValueTypeAssignation_ThenValueTypeMembersHaveDifferentReference()
        {
            var firstRectangle = new ValueTypeRectangle();
            firstRectangle.Length = 10;
            firstRectangle.Breadth = 10;
            firstRectangle.MyShape = new Shape { Name = "Square" };

            var secondRectangle = firstRectangle;

            firstRectangle.Length = 20;
            firstRectangle.Breadth = 20;
            firstRectangle.MyShape.Name = "Circle";

            Assert.AreNotEqual(firstRectangle.Area(), secondRectangle.Area());
        }

        [TestMethod]
        public void WhenValueTypeAssignation_ThenReferenceTypeMembersHaveSameReference()
        {
            var firstRectangle = new ValueTypeRectangle();
            firstRectangle.MyShape = new Shape { Name = "Square" };

            var secondRectangle = firstRectangle;
            secondRectangle.MyShape.Name = "Circle";

            Console.WriteLine($"First rectangle shape -> {firstRectangle.MyShape.Name}");
            Console.WriteLine($"Second rectangle shape -> {secondRectangle.MyShape.Name}");

            Assert.AreEqual(firstRectangle.MyShape.Name, secondRectangle.MyShape.Name);
        }

        [TestMethod]
        public void WhenValueTypeEquality_ThenBothObjectsHaveSameValues()
        {
            var firstRectangle = new ValueTypeRectangle();
            firstRectangle.Length = 10;
            firstRectangle.Breadth = 10;
            firstRectangle.MyShape = new Shape { Name = "Square" };

            var secondRectangle = firstRectangle;

            secondRectangle.Length = 10;
            secondRectangle.Breadth = 10;
            secondRectangle.MyShape.Name = "Square";

            Assert.AreEqual(firstRectangle, secondRectangle);
        }
       
        [TestMethod]
        public void WhenReferenceTypeAssignation_ThenBothRectanglesHaveReferencesToSameAddress()
        {
            var firstRectangle = new ReferenceTypeRectangle();
            firstRectangle.Length = 10;
            firstRectangle.Breadth = 10;

            var secondRectangle = firstRectangle;

            firstRectangle.Length = 20;
            firstRectangle.Breadth = 20;

            Assert.AreEqual(firstRectangle.Area(), secondRectangle.Area());
        }

        [TestMethod]
        public void WhenReferenceTypeEquality_ThenBothObjectsHaveSameReference()
        {
            var firstRectangle = new ReferenceTypeRectangle();
            firstRectangle.Length = 10;
            firstRectangle.Breadth = 10;

            var secondRectangle = firstRectangle;

            secondRectangle.Length = 20;
            secondRectangle.Breadth = 20;

            Assert.AreEqual(firstRectangle, secondRectangle);
        }

        [TestMethod]
        public void WhenValueTypeAsMethodArguments_ThenLengthHaveDifferentCopies()
        {
            var pass = new ValueAndReferenceAsMethodArgumentsSample();
            ValueTypeRectangle rect = new ValueTypeRectangle { Length = 20 };
            pass.ValueTypeArguments(rect);

            Console.WriteLine($"Length outside function = {rect.Length}");

            Assert.AreEqual(20, rect.Length);
        }

        [TestMethod]
        public void WhenReferenceTypeAsMethodArguments_ThenLengthHaveSameReference()
        {
            var pass = new ValueAndReferenceAsMethodArgumentsSample();
            ReferenceTypeRectangle rect = new ReferenceTypeRectangle { Length = 20 };
            pass.ReferenceTypeArguments(rect);
            Console.WriteLine($"Length outside function = {rect.Length}");

            Assert.AreEqual(21, rect.Length);
        }

        [TestMethod]
        public void WhenBoxingUnBoxing_ThenValueToReferenceAndReferenceToValueConversion()
        {
            var conv = new BoxingAndUnboxing();
            int input = 500;
            var output = conv.BoxingUnBoxing(input);

            Assert.AreEqual(output, input);
        }
    }
}