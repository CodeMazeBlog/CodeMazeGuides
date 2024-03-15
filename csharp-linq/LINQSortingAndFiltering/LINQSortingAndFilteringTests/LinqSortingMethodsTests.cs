namespace LINQSortingAndFilteringTests;

public class LinqSortingMethodsTests
{
    private readonly List<Shape> _shapes = new()
    {
        new Rectangle {ShapeId = 2, Height = 4, Width = 2},
        new Square {ShapeId = 1, Height = 2, Width = 2},
        new Cone {ShapeId = 3, Height = 1, Width = 3}
    };

    [Fact]
    public void GivenObjectWithoutDefaultOrderer_WhenCallOrder_ThenThrowsInvalidOperationException()
    {
        var list = Enumerable.Range(0, 10).Select(_ => new SampleNoOrderer()).ToList();

        var action = () => list.Order();

        action.Enumerating().Should().Throw<InvalidOperationException>();
    }

    [Fact]
    public void GivenObjectWithoutDefaultOrderer_WhenCallOrderByWithPropertyWithOrder_ThenExecutesWithoutException()
    {
        var list = Enumerable.Range(0, 10).Select(_ => new SampleNoOrderer()).ToList();

        var action = () => list.OrderBy(x => x.Id);

        action.Enumerating().Should().NotThrow();
    }

    [Fact]
    public void
        GivenMemberPropertyWithNoDefaultOrderer_WhenOrderByProperty_ThenThrowsInvalidOperationException()
    {
        var list = Enumerable.Range(0, 10).Select(_ => new SampleMemberWithNoOrderer()).ToList();

        var action = () => list.OrderBy(x => x.IdHolder);

        action.Enumerating().Should().Throw<InvalidOperationException>();
    }

    [Fact]
    public void GivenObjectWithMemberHavingNoDefaultOrderer_WhenCallOrderByOtherProperty_ThenExecutesWithoutException()
    {
        var list = Enumerable.Range(0, 10).Select(_ => new SampleMemberWithNoOrderer()).ToList();

        var sortByAAction = () => list.OrderBy(x => x.A);
        var sortByBAction = () => list.OrderBy(x => x.B);

        sortByAAction.Enumerating().Should().NotThrow();
        sortByBAction.Enumerating().Should().NotThrow();
    }

    [Fact]
    public void GivenShapeList_WhenCallingOrder_ThenSortedByDefaultOrdererShapeId()
    {
        var result = _shapes.Order().ToArray();

        result.Should().HaveSameCount(_shapes);
        result.Should().BeInAscendingOrder(s => s.ShapeId);
    }

    [Fact]
    public void GivenShapeList_WhenCallingOrderDescending_ThenSortedByDefaultOrdererShapeId()
    {
        var result = _shapes.OrderDescending().ToArray();

        result.Should().HaveSameCount(_shapes);
        result.Should().BeInDescendingOrder(s => s.ShapeId);
    }

    [Fact]
    public void GivenShapeList_WhenOrderByShapeType_ThenSortedByShapeType()
    {
        var result = _shapes.OrderBy(x => x.ShapeType).ToArray();

        result.Should().HaveSameCount(_shapes);
        result.First().Should().BeOfType<Cone>();
        result.Last().Should().BeOfType<Square>();
        result.Should().BeInAscendingOrder(s => s.ShapeType);
    }

    [Fact]
    public void GivenShapeList_WhenOrderByDescending_ThenSortedByShapeIdInDescendingOrder()
    {
        var result = _shapes.OrderByDescending(x => x.ShapeId).ToArray();

        result.Should().HaveSameCount(_shapes);
        result.Should().BeInDescendingOrder(s => s.ShapeId);
    }

    [Fact]
    public void GivenShapeList_WhenOrderByIs3DThenByShapeId_ThenSortedByIs3DAndThenShapeId()
    {
        var result = _shapes.OrderBy(sl => sl.Is3D).ThenBy(sl => sl.ShapeId).ToArray();

        result.Should().HaveSameCount(_shapes);
        result[0].Is3D.Should().BeFalse();
        result[1].Is3D.Should().BeFalse();
        result[2].Is3D.Should().BeTrue();
        result[0].ShapeId.Should().Be(1);
        result[^1].ShapeId.Should().Be(3);
    }

    [Fact]
    public void GivenShapeList_WhenOrderByDescendingIs3DAndThenShapeIdDescending_ThenInDescendingOrder()
    {
        // Act
        var result = _shapes.OrderByDescending(sl => sl.Is3D).ThenByDescending(sl => sl.ShapeId).ToArray();

        // Assert
        result.Should().HaveSameCount(_shapes);
        result[0].Is3D.Should().BeTrue();
        result[1].Is3D.Should().BeFalse();
        result[2].Is3D.Should().BeFalse();
        result[0].ShapeId.Should().Be(3);
        result[^1].ShapeId.Should().Be(1);
    }

    [Fact]
    public void GivenShapeList_WhenReverse_ThenListIsReversed()
    {
        // Arrange
        var listCopy = new List<Shape?>(_shapes);
        listCopy.Reverse();

        // Act
        var result = _shapes.AsEnumerable().Reverse().ToArray();

        // Assert
        result.Should().HaveSameCount(_shapes);
        result[0].Should().Be(_shapes[^1]);
        result[1].Should().Be(_shapes[^2]);
        result[2].Should().Be(_shapes[^3]);
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