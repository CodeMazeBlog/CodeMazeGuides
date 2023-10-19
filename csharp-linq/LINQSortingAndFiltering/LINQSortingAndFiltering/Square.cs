namespace LINQSortingAndFiltering;

public sealed record Square : Shape
{
    public Square() => ShapeType = nameof(Square);
}