namespace ValueAndReferenceTypes;

public class ReferenceTypeRectangle
{
    public int Length { get; set; }
    public int Width { get; set; }

    public int Area()
    {
        int area = Length * Width;
        Console.WriteLine($"length = {Length}");
        Console.WriteLine($"width = {Width}");
        Console.WriteLine($"area = {area}");

        return area;
    }
}
