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
        var price = Price.ToString("C", new CultureInfo(culture));

        return $"{Make} {Model} costs {price} and was sold on {SoldAt}";
    }

    public string ToString(string culture, string dateFormat)
    {
        var price = Price.ToString("C", new CultureInfo(culture));
        var saleDate = SoldAt.ToString(dateFormat);

        return $"{Make} {Model} costs {price} and was sold on {saleDate}";
    }
}