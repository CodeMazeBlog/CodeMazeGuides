namespace ComparingTwoJsonObjects;

public class Car
{
    public string Name { get; set; }
    public string Make { get; set; }
    public string Model { get; set; }
    public Price Price { get; set; }

    public override bool Equals(object obj)
    {
        if (obj == null || GetType() != obj.GetType())
        {
            return false;
        }

        var car = (Car)obj;

        return Name == car.Name && Model == car.Model && Make == car.Make && Price == car.Price;
    }
}