namespace LINQSortingAndFiltering;

public abstract record Shape : IComparable<Shape>
{
    public int ShapeId { get; init; }
    public string? ShapeType { get; protected init; }
    public int Width { get; init; }
    public int Height { get; init; }
    public bool Is3D { get; protected init; }

    public override string ToString() =>
        $"ShapeId: {ShapeId} ShapeType: {ShapeType} ShapeWidth: {Width} ShapeHeight: {Height} is3D: {Is3D}";

    public int CompareTo(Shape? other)
    {
        if (ReferenceEquals(this, other)) return 0;

        return other is null ? 1 : ShapeId.CompareTo(other.ShapeId);
    }
}