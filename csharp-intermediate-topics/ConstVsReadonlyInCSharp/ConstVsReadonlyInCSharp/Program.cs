using ConstVsReadonlyInCSharp;
using ConstVsReadonlyInCSharp.Library;

public class Program
{
    static void Main(string[] args)
    {
        var circleCalculator = new CircleCalculator();
        Console.WriteLine($"A circle with radius 5.59 has a circumference: {circleCalculator.GetCircumference(5.59)}");
        Console.WriteLine($"A more accurate estimation of this circle's circumference is: {circleCalculator.GetAccurateCircumference(5.59):0.0000}");

        var taxCalculator = new TaxCalculator(0.15M);
        Console.WriteLine($"The VAT for a product valued at 14 euros is: {taxCalculator.CalculateCountryVatInEuro(14):0.00} euros");
        Console.WriteLine($"The VAT for a product valued at 14 euros is: {taxCalculator.CalculateCountryVatInDollars(14):0.00} dollars");

        Console.WriteLine(CircleCalculator.E);

        Console.WriteLine(Values.ReadonlyValue);
        Console.WriteLine(Values.ConstValue);

        Console.ReadLine();
    }
}
