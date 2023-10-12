using LocalFunctionInCSharp;

var cart = new ShoppingCart
{
    Products = new List<Product>
            {
                new Product { Name = "Product A", StockQuantity = 10, SelectedQuantity = 2 },
                new Product { Name = "Product B", StockQuantity = 11, SelectedQuantity = 5 }
            }
};

if (cart.Checkout())
{
    Console.WriteLine("Checkout successful.");
}
else
{
    Console.WriteLine("Checkout failed due to validation errors.");
}

List<int> numbers = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
List<int> evenNumbersUsingLocalFunction = FilterEvenNumbersUsingLocalFunction(numbers);
Console.WriteLine(string.Join(", ", evenNumbersUsingLocalFunction));

static List<int> FilterEvenNumbersUsingLocalFunction(List<int> numbers)
{
    return numbers.Where(IsEven).ToList();

    bool IsEven(int num)
    {
        return num % 2 == 0;
    }
}


List<int> evenNumbersUsingLambdaFunction = FilterEvenNumbersUsingLambda(numbers);
Console.WriteLine(string.Join(", ", evenNumbersUsingLambdaFunction));

static List<int> FilterEvenNumbersUsingLambda(List<int> numbers)
{
    return numbers.Where(n => n % 2 == 0).ToList();
}
