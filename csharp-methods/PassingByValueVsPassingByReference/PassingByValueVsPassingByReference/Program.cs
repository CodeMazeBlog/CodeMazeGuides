namespace PassingByValueVsPassingByReference;

public class Program
{
    public static void Main()
    {
        int discountRate = 50;
        double productAPrice = 60;

        double zero;

        var product = new Product
        {
            ProductId = 1,
            Price = 60,
            Cost = 10
        };

        ApplyDiscount(product, 50);
        Console.WriteLine($"{nameof(product)}: {product.Price}");

        Console.WriteLine("Initial");
        Console.WriteLine($"{nameof(productAPrice)}: {productAPrice}");

        UpdatePriceByPercent(productAPrice, discountRate);
        Console.WriteLine("After passing by value");
        Console.WriteLine($"{nameof(productAPrice)}: {productAPrice}");

        UpdatePriceByPercentByRef(ref productAPrice, discountRate);
        Console.WriteLine("After passing by ref");
        Console.WriteLine($"{nameof(productAPrice)}: {productAPrice}");

        double productANewPrice = CalculateDiscount(productAPrice, discountRate);
        Console.WriteLine($"{nameof(productANewPrice)}: {productANewPrice}");

        double[] prices = [30, 15, 21.5, 50];
        UpdatePricesByPercent(prices, -10);

        MakeItZero(out zero);
        Console.WriteLine($"{nameof(zero)}: {zero}");
    }

    public static void UpdatePricesByPercent(double[] prices, int rate)
    {
        for (int i = 0; i < prices.Length; i++)
        {
            prices[i] += prices[i] * rate / 100;
        }
    }

    public static double CalculateDiscount(double price, int discountRate)
    {
        return price - price * discountRate / 100;
    }

    public static void UpdatePriceByPercent(double price, int discountRate)
    {
        price = price - price * discountRate / 100;
    }

    public static void UpdatePriceByPercentByRef(ref double price, int discountRate)
    {
        price -= price * discountRate / 100;
    }

    public static void ApplyDiscount(Product product, int discountRate)
    {
        product.Price -= product.Price * discountRate / 100;
    }

    public static void MakeItZero(out double price)
    {
        price = 0;
    }
}

public class Product
{
    public int ProductId { get; set; }
    public double Price { get; set; }
    public double Cost { get; set; }
}
