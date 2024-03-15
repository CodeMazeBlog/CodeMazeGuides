namespace LINQSortingAndFiltering;

public sealed record Cone : Shape
{
    public Cone()
    {
        ShapeType = nameof(Cone);
        Is3D = true;
    }
}