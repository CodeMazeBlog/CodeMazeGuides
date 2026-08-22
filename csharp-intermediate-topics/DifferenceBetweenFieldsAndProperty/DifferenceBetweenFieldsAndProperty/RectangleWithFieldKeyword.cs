namespace DifferenceBetweenFieldsAndProperty;

// The same validation as Rectangle.Width, written with the C# 14 `field` keyword
// instead of a hand-declared private backing field.
public class RectangleWithFieldKeyword
{
    public double Width
    {
        get;
        set => field = value >= 0
            ? value
            : throw new ArgumentException("A Rectangle can't have negative width", nameof(value));
    }
}
