using DelegatesExample;
using static DelegateExample;

var delegateExample = new DelegateExample();

var products = new List<Product>() {
    new Product()
    {
        Label = "Backpack",
        Price = 50.7M
    },
    new Product()
    {
        Label = "Bluetooth Headset",
        Price = 89.2M
    }
};

//Create delegate object
DelegateCalculator myCalculatorDelegate = new DelegateCalculator(delegateExample.CalculcateTotal);

Func<List<Product>, decimal> myfuncCalculator = delegateExample.CalculcateTotal;

Action<decimal> myAction = delegateExample.DisplayResult;

//Invoke delegate
var total = myCalculatorDelegate(products);
Console.WriteLine($"The total is: {total:C2}");

Console.WriteLine($"Total from Func: {myfuncCalculator(products):C2}");

myAction(delegateExample.CalculcateTotal(products));

public class DelegateExample
{
    //Declare delegate
    public delegate decimal DelegateCalculator(List<Product> products);

    //This is our method which returns a decimal and has a single parameter of type list of products
    public decimal CalculcateTotal(List<Product> products)
    {
        return products.Sum(x => x.Price);
    }

    public void DisplayResult(decimal total)
    {
        Console.WriteLine($"Total from Action: {total:C2}");
    }
}
