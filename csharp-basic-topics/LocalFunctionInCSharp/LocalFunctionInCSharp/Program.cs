using LocalFunctionInCSharp;

var cart = new ShoppingCart
{
    Products = new List<Product>
    {
        new() { Name = "Product A", StockQuantity = 10, SelectedQuantity = 2 },
        new() { Name = "Product B", StockQuantity = 11, SelectedQuantity = 5 }
    }
};

Console.WriteLine(cart.Checkout() ? "Checkout successful." : "Checkout failed due to validation errors.");

var numbers = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
var evenNumbersUsingLocalFunction = FilterEvenNumbersUsingLocalFunction(numbers);
Console.WriteLine(string.Join(", ", evenNumbersUsingLocalFunction));

static List<int> FilterEvenNumbersUsingLocalFunction(List<int> numbers)
{
    return numbers.Where(IsEven).ToList();

    bool IsEven(int num) => num % 2 == 0;
}

var evenNumbersUsingLambdaFunction = FilterEvenNumbersUsingLambda(numbers);
Console.WriteLine(string.Join(", ", evenNumbersUsingLambdaFunction));

static List<int> FilterEvenNumbersUsingLambda(List<int> numbers)
{
    return numbers.Where(n => n % 2 == 0).ToList();
}
