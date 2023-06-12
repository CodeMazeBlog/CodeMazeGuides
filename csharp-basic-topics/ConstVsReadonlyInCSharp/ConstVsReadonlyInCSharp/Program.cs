using ConstVsReadonlyInCSharp;

public class Program
{
    static void Main(string[] args)
    {
        CircleCalculator circleCalculator = new CircleCalculator();

        Console.WriteLine($"A circle with radius 5.59 has a cerconference: {circleCalculator.GetCircumference(5.59)}");
        Console.WriteLine($"Is more accurate estimation of this circle cerconference: {String.Format("{0:0.0000}", circleCalculator.GetAccurateCircumference(5.59))}");

        TaxCalculator taxCalculator = new TaxCalculator(0.15);
        Console.WriteLine($"The VAT for a 14euros value product is: {taxCalculator.CalculateCountryVatInEuro(14)} euros");
        Console.WriteLine($"The VAT for a 14euros value product is: {String.Format("{0:0.0000}", taxCalculator.CalculateCountryVatInDollars(14))} dollars");
    }
}
