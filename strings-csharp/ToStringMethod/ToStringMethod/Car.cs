using System.Globalization;

namespace ToStringMethod;

public class Car
{
    public string Make { get; set; }
    public string Model { get; set; }
    public decimal Price { get; set; }
    public DateTime SoldAt { get; set; }

    public Car()
    {
    }

    public Car(string make, string model, decimal price, DateTime soldAt)
    {
        Model = model;
        Make = make;
        Price = price;
        SoldAt = soldAt;
    }

    public string ToString(string culture)
    {
        if (string.IsNullOrEmpty(Make) || string.IsNullOrEmpty(Model))
        {
            return string.Empty;
        }

        return $"{Make} {Model} costs {Price.ToString("C", new CultureInfo(culture))} and was sold on {SoldAt}";
    }

    public string ToString(string culture, string dateFormat)
    {
        if (string.IsNullOrEmpty(Make) || string.IsNullOrEmpty(Model))
        {
            return string.Empty;
        }

        return $"{Make} {Model} costs {Price.ToString("C", new CultureInfo(culture))} and was sold on {string.Format(SoldAt.ToString(dateFormat))}";
    }
}