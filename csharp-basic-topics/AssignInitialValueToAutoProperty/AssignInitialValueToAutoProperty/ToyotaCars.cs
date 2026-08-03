namespace AssignInitialValueToAutoProperty;

public class ToyotaCars
{
    public ToyotaCars()
    {
        Color = "Black";
        Cost = 400000.00m;
    }

    public string Color { get; set; }
    public decimal Cost { get; set; }
}
