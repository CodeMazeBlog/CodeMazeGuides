namespace ValueAndReferenceTypes;

public struct ValueTypeRectangle
{
    public int Length { get; set; }
    public int Breadth { get; set; }
    public Shape MyShape { get; set; }

    public int Area()
    {
        int area = Length * Breadth;
        Console.WriteLine($"length = {Length}");
        Console.WriteLine($"breadth = {Breadth}");
        Console.WriteLine($"shape = {MyShape.Name}");
        Console.WriteLine($"area = {area}");

        return area;
    }
}
