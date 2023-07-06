namespace SortingGenericList.Test;

public static class UnitTestSetupHelpers
{
    public static Shape CreateShapeMock(double area, double circumference)
    {
        var mock = new Mock<Shape> {CallBase = true};
        mock.Setup(s => s.Area).Returns(area);
        mock.Setup(s => s.Circumference).Returns(circumference);

        return mock.Object;
    }
}