namespace LINQSortingAndFiltering;

public sealed record Rectangle : Shape
{
    public Rectangle() => ShapeType = nameof(Rectangle);
}