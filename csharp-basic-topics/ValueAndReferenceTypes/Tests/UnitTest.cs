using Microsoft.VisualStudio.TestTools.UnitTesting;
using ValueAndReferenceTypes;
namespace Tests;

[TestClass]
public class UnitTest
{
    [TestMethod]
    public void WhenValueTypeAssignation_ThenValueTypeMembersHaveDifferentReference()
    {
        var firstRectangle = new ValueTypeRectangle
        {
            Length = 10,
            Width = 10,
            MyShape = new Shape { Name = "Square" }
        };

        var secondRectangle = firstRectangle;

        firstRectangle.Length = 20;
        firstRectangle.Width = 20;
        firstRectangle.MyShape.Name = "Circle";

        Assert.AreNotEqual(firstRectangle.Area(), secondRectangle.Area());
    }

    [TestMethod]
    public void WhenValueTypesMemberAreEqual_ThenTheValueTypeInstancesAreEqual()
    {
        var firstRectangle = new ValueTypeRectangle
        {
            Length = 10,
            Width = 10,
        };

        var secondRectangle = new ValueTypeRectangle
        {
            Length = 10,
            Width = 10,
        };

        Assert.AreEqual(firstRectangle, secondRectangle);
    }

    [TestMethod]
    public void WhenReferenceTypeAssignation_ThenBothRectanglesHaveReferencesToSameAddress()
    {
        var firstRectangle = new ReferenceTypeRectangle()
        {
            Length = 10,
            Width = 10
        };

        var secondRectangle = firstRectangle;

        firstRectangle.Length = 20;
        firstRectangle.Width = 20;

        Assert.AreEqual(firstRectangle.Area(), secondRectangle.Area());
    }

    [TestMethod]
    public void WhenReferenceTypesHaveDifferentReferences_ThenInstancesAreEqual()
    {
        var firstRectangle = new ReferenceTypeRectangle()
        {
            Length = 10,
            Width = 10
        };

        var secondRectangle = new ReferenceTypeRectangle()
        {
            Length = 10,
            Width = 10
        };

        Assert.AreNotEqual(firstRectangle, secondRectangle);
    }

    [TestMethod]
    public void WhenValueTypeIsPassedAsArgument_ThenACopyIsPassed()
    {
        var lengthIncrementer = new RectangleLengthIncrementer();
        ValueTypeRectangle rect = new ValueTypeRectangle
        {
            Length = 20
        };
        lengthIncrementer.IncrementRectangleLength(rect);

        Assert.AreEqual(20, rect.Length);
    }

    [TestMethod]
    public void WhenReferenceTypeIsPassedAsArgument_ThenAReferenceIsPassed()
    {
        var lengthIncrementer = new RectangleLengthIncrementer();
        ReferenceTypeRectangle rect = new ReferenceTypeRectangle
        {
            Length = 20
        };
        lengthIncrementer.IncrementRectangleLength(rect);

        Assert.AreEqual(21, rect.Length);
    }

    [TestMethod]
    public void WhenBoxingAndUnboxing_ThenResultIsEqualToOriginalValue()
    {
        int number = 10;

        object boxedNumber = number;
        int unboxedNumber = (int)boxedNumber;

        Assert.AreEqual(number, unboxedNumber);
    }
}