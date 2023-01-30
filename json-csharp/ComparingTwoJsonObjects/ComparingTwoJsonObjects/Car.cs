namespace ComparingTwoJsonObjects;

public class Car
{
    public string Name { get; set; }
    public string Make { get; set; }
    public string Model { get; set; }
    public Price Price { get; set; }   
}

public class Price
{   
    public double Amount { get; set; }
    public string Currency { get; set; }
}