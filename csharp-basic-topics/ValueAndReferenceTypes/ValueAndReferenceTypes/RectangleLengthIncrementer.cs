namespace ValueAndReferenceTypes;

public class RectangleLengthIncrementer
{
    public void IncrementRectangleLength(ValueTypeRectangle rect)
    {
        rect.Length = rect.Length + 1;
        Console.WriteLine($"Length inside function = {rect.Length}");
    }

    public void IncrementRectangleLength(ReferenceTypeRectangle rect)
    {
        rect.Length = rect.Length + 1;
        Console.WriteLine($"Length inside function = {rect.Length}");
    }

}
