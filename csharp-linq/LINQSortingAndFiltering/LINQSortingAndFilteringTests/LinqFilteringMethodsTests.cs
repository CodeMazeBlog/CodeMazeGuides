namespace LINQSortingAndFilteringTests;

public class LinqFilteringMethodsTests
{
    private readonly List<Shape?> _shapes = new()
    {
        new Cone {ShapeId = 1, Height = 3, Width = 2},
        new Rectangle {ShapeId = 2, Height = 5, Width = 3},
        new Square {ShapeId = 3, Height = 1, Width = 1},
        new Cone {ShapeId = 4, Height = 4, Width = 3},
        null
    };

    [Fact]
    public void GivenShapeList_WhenFilterWhereCalled_ThenOnlyShapesWithHeightLessThan4AreReturned()
    {
        var result = _shapes.Where(s => s?.Height > 4).ToArray();

        result.Should().ContainSingle();
        result.First()!.Height.Should().BeGreaterThan(4);
    }

    [Fact]
    public void GivenShapeList_WhenFilterWhereVerboseCalled_ThenOnlyShapeThatPassCheckShapeAreReturned()
    {
        var result = _shapes.Where(LinqFilteringMethods.FilterIs3DAndWidthLessThan3).ToArray();

        result.Should().ContainSingle();
        result.First().Should().BeOfType<Cone>();
        result.First()!.Width.Should().BeLessThan(3);
    }

    [Fact]
    public void GivenShapeList_WhenFilterOfTypeCalled_ThenOnlyExpectedTypesAreReturned()
    {
        var result = _shapes.OfType<Square>().ToArray();

        result.Should().ContainSingle();
        result.First().Should().BeOfType<Square>();
        result.First()!.ShapeId.Should().Be(3);
    }

    [Fact]
    public void GivenShapeList_WhenFilterNullExtensionCalled_ThenNullShapesAreRemoved()
    {
        var result = _shapes.FilterNotNull().ToArray();

        result.Should().HaveSameCount(_shapes.Where(x => x is not null));
        result.Should().NotContainNulls();
    }
}