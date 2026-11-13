namespace LINQSortingAndFilteringTests;

public class LinqFilteringMethodsTests
{
    private readonly List<Shape?> _shapes =
    [
        new Cone { ShapeId = 1, Height = 3, Width = 2 },
        new Rectangle { ShapeId = 2, Height = 5, Width = 3 },
        new Square { ShapeId = 3, Height = 1, Width = 1 },
        new Cone { ShapeId = 4, Height = 4, Width = 3 },
        null
    ];

    [Fact]
    public void GivenShapeList_WhenFilterWhereCalled_ThenOnlyShapesWithHeightGreaterThan4AreReturned()
    {
        var result = _shapes.Where(s => s?.Height > 4).ToArray();

        var shape = Assert.Single(result);
        Assert.True(shape!.Height > 4);
    }

    [Fact]
    public void GivenShapeList_WhenFilterWhereVerboseCalled_ThenOnlyShapeThatPassCheckShapeAreReturned()
    {
        var result = _shapes.Where(LinqFilteringMethods.FilterIs3DAndWidthLessThan3).ToArray();

        var shape = Assert.Single(result);
        Assert.IsType<Cone>(shape);
        Assert.True(shape!.Width < 3);
    }

    [Fact]
    public void GivenShapeList_WhenFilterOfTypeCalled_ThenOnlyExpectedTypesAreReturned()
    {
        var result = _shapes.OfType<Square>().ToArray();

        var square = Assert.Single(result);
        Assert.Equal(3, square.ShapeId);
    }

    [Fact]
    public void GivenShapeList_WhenFilterNullExtensionCalled_ThenNullShapesAreRemoved()
    {
        var result = _shapes.FilterNotNull().ToArray();

        Assert.Equal(_shapes.Count(x => x is not null), result.Length);
        Assert.All(result, shape => Assert.NotNull(shape));
    }

    [Fact]
    public void GivenShapeList_WhenOfTypeBaseType_ThenSameResultAsFilterNotNull()
    {
        var ofType = _shapes.OfType<Shape>();
        var filterNotNull = _shapes.FilterNotNull();

        Assert.Equal(filterNotNull, ofType);
    }
}