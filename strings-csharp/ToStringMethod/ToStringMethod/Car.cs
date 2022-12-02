using System.Globalization;

namespace ToStringMethod;

public class Car
{
    public string Make { get; set; }
    public string Model { get; set; }
    public decimal Price { get; set; }
    public DateTime SoldAt { get; set; }

    public Car(string make, string model, decimal price, DateTime soldAt)
    {
        Model = model;
        Make = make;
        Price = price;
        SoldAt = soldAt;
    }

    public string ToString(string culture)
    {
        return $"{Make} {Model} costs {string.Format(Price.ToString("C", new CultureInfo(culture)))} and was sold on {SoldAt}";
    }

    public string ToString(string culture, string dateFormat)
    {
        return $"{Make} {Model} costs {string.Format(Price.ToString("C", new CultureInfo(culture)))} and was sold on {string.Format(SoldAt.ToString(dateFormat))}";
    }
}