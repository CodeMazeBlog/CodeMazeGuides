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
List<int> evenNumbersUsingLocalFunction = FilterEvenNumbers(numbers);
Console.WriteLine(string.Join(", ", evenNumbersUsingLocalFunction));

static List<int> FilterEvenNumbers(List<int> numbers)
{
    List<int> result = new List<int>();
    foreach (int num in numbers)
    {
        if (IsEven(num))
        {
            result.Add(num);
        }
    }

    bool IsEven(int num)
    {
        return num % 2 == 0;
    }

    return result;
}

List<int> evenNumbersUsingLambdaFunction = numbers.Where(num => num % 2 == 0).ToList();
Console.WriteLine(string.Join(", ", evenNumbersUsingLambdaFunction));
