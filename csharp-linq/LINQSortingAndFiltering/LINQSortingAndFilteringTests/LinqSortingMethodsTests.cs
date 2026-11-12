namespace LINQSortingAndFilteringTests;

public class LinqSortingMethodsTests
{
    private readonly List<Shape> _shapes =
    [
        new Rectangle { ShapeId = 2, Height = 4, Width = 2 },
        new Square { ShapeId = 1, Height = 2, Width = 2 },
        new Cone { ShapeId = 3, Height = 1, Width = 3 }
    ];

    [Fact]
    public void GivenObjectWithoutDefaultOrderer_WhenCallOrder_ThenThrowsInvalidOperationException()
    {
        var list = Enumerable.Range(0, 10).Select(_ => new SampleNoOrderer()).ToList();

        var ordered = list.Order();

        Assert.Throws<InvalidOperationException>(() => ordered.ToList());
    }

    [Fact]
    public void GivenObjectWithoutDefaultOrderer_WhenCallOrderByWithPropertyWithOrder_ThenExecutesWithoutException()
    {
        var list = Enumerable.Range(0, 10).Select(_ => new SampleNoOrderer()).ToList();

        var result = list.OrderBy(x => x.Id).ToList();

        Assert.Equal(list.Count, result.Count);
    }

    [Fact]
    public void GivenMemberPropertyWithNoDefaultOrderer_WhenOrderByProperty_ThenThrowsInvalidOperationException()
    {
        var list = Enumerable.Range(0, 10).Select(_ => new SampleMemberWithNoOrderer()).ToList();

        var ordered = list.OrderBy(x => x.IdHolder);

        Assert.Throws<InvalidOperationException>(() => ordered.ToList());
    }

    [Fact]
    public void GivenObjectWithMemberHavingNoDefaultOrderer_WhenCallOrderByOtherProperty_ThenExecutesWithoutException()
    {
        var list = Enumerable.Range(0, 10).Select(_ => new SampleMemberWithNoOrderer()).ToList();

        var byA = list.OrderBy(x => x.A).ToList();
        var byB = list.OrderBy(x => x.B).ToList();

        Assert.Equal(list.Count, byA.Count);
        Assert.Equal(list.Count, byB.Count);
    }

    [Fact]
    public void GivenShapeList_WhenCallingOrder_ThenSortedByDefaultOrdererShapeId()
    {
        var result = _shapes.Order().Select(s => s.ShapeId).ToArray();

        Assert.Equal([1, 2, 3], result);
    }

    [Fact]
    public void GivenShapeList_WhenCallingOrderDescending_ThenSortedByDefaultOrdererShapeId()
    {
        var result = _shapes.OrderDescending().Select(s => s.ShapeId).ToArray();

        Assert.Equal([3, 2, 1], result);
    }

    [Fact]
    public void GivenShapeList_WhenOrderByShapeType_ThenSortedByShapeType()
    {
        var result = _shapes.OrderBy(x => x.ShapeType).ToArray();

        Assert.Equal(_shapes.Count, result.Length);
        Assert.IsType<Cone>(result.First());
        Assert.IsType<Square>(result.Last());
        Assert.Equal(["Cone", "Rectangle", "Square"], result.Select(s => s.ShapeType));
    }

    [Fact]
    public void GivenShapeList_WhenOrderByDescending_ThenSortedByShapeIdInDescendingOrder()
    {
        var result = _shapes.OrderByDescending(x => x.ShapeId).Select(s => s.ShapeId).ToArray();

        Assert.Equal([3, 2, 1], result);
    }

    [Fact]
    public void GivenShapeList_WhenOrderByIs3DThenByShapeId_ThenSortedByIs3DAndThenShapeId()
    {
        var result = _shapes.OrderBy(sl => sl.Is3D).ThenBy(sl => sl.ShapeId).ToArray();

        Assert.False(result[0].Is3D);
        Assert.False(result[1].Is3D);
        Assert.True(result[2].Is3D);
        Assert.Equal(1, result[0].ShapeId);
        Assert.Equal(3, result[^1].ShapeId);
    }

    [Fact]
    public void GivenShapeList_WhenOrderByDescendingIs3DAndThenShapeIdDescending_ThenInDescendingOrder()
    {
        var result = _shapes.OrderByDescending(sl => sl.Is3D).ThenByDescending(sl => sl.ShapeId).ToArray();

        Assert.True(result[0].Is3D);
        Assert.False(result[1].Is3D);
        Assert.False(result[2].Is3D);
        Assert.Equal(3, result[0].ShapeId);
        Assert.Equal(1, result[^1].ShapeId);
    }

    [Fact]
    public void GivenShapeList_WhenReverse_ThenListIsReversed()
    {
        var result = _shapes.AsEnumerable().Reverse().ToArray();

        Assert.Equal(_shapes.Count, result.Length);
        Assert.Equal(_shapes[^1], result[0]);
        Assert.Equal(_shapes[^2], result[1]);
        Assert.Equal(_shapes[^3], result[2]);
    }

    [Fact]
    public void GivenEqualKeys_WhenOrderByAndOrderByDescending_ThenOriginalOrderIsKept()
    {
        List<Shape> shapes =
        [
            new Square { ShapeId = 7, Height = 1, Width = 1 },
            new Cone { ShapeId = 5, Height = 1, Width = 1 },
            new Square { ShapeId = 2, Height = 1, Width = 1 },
            new Square { ShapeId = 9, Height = 1, Width = 1 }
        ];

        var ascending = shapes.OrderBy(s => s.ShapeType).Select(s => s.ShapeId);
        var descending = shapes.OrderByDescending(s => s.ShapeType).Select(s => s.ShapeId);

        Assert.Equal([5, 7, 2, 9], ascending);
        Assert.Equal([7, 2, 9, 5], descending);
    }

    [Fact]
    public void GivenQuerySyntax_WhenOrderByTwoKeys_ThenSameAsOrderByThenByDescending()
    {
        List<Shape?> shapes = [.. _shapes, null, new Square { ShapeId = 0, Height = 1, Width = 1 }];

        var querySyntax =
            from s in shapes
            orderby s?.ShapeType, s?.ShapeId descending
            select s;
        var methodSyntax = shapes.OrderBy(s => s?.ShapeType).ThenByDescending(s => s?.ShapeId);

        Assert.Equal(methodSyntax, querySyntax);
    }

    [Fact]
    public void GivenShapeList_WhenSorted_ThenSourceListIsUnchanged()
    {
        var before = _shapes.ToArray();

        _ = _shapes.OrderByDescending(s => s.ShapeId).ToList();

        Assert.Equal(before, _shapes);
    }

    [Fact]
    public void GivenSortedQuery_WhenSourceChangesBeforeEnumeration_ThenResultIncludesNewItem()
    {
        var shapes = new List<Shape>(_shapes);
        var ordered = shapes.OrderBy(s => s.ShapeId);

        shapes.Add(new Square { ShapeId = 0, Height = 1, Width = 1 });

        Assert.Equal([0, 1, 2, 3], ordered.Select(s => s.ShapeId));
    }

    private sealed class SampleNoOrderer
    {
        public string Id { get; } = Guid.NewGuid().ToString();
    }

    private sealed class SampleMemberWithNoOrderer
    {
        public int A { get; } = Random.Shared.Next();
        public double B { get; } = Random.Shared.NextDouble();
        public SampleNoOrderer IdHolder { get; } = new();
    }
}