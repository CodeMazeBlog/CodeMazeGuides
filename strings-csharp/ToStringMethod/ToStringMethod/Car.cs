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
        var cultureInfo = new CultureInfo(culture);
        var price = Price.ToString("C", cultureInfo);
        var saleDate = SoldAt.ToString(cultureInfo);

        return $"{Make} {Model} costs {price} and was sold on {saleDate}";
    }

    public string ToString(string culture, string dateFormat)
    {
        var cultureInfo = new CultureInfo(culture);
        var price = Price.ToString("C", cultureInfo);
        var saleDate = SoldAt.ToString(dateFormat, cultureInfo);

        return $"{Make} {Model} costs {price} and was sold on {saleDate}";
    }
}