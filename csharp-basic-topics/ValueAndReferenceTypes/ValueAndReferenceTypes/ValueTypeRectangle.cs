namespace ValueAndReferenceTypes;

public struct ValueTypeRectangle
{
    public int Length { get; set; }
    public int Width { get; set; }
    public Shape MyShape { get; set; }

    public int Area()
    {
        int area = Length * Width;
        Console.WriteLine($"length = {Length}");
        Console.WriteLine($"width = {Width}");
        Console.WriteLine($"shape = {MyShape.Name}");
        Console.WriteLine($"area = {area}");

        return area;
    }
}
