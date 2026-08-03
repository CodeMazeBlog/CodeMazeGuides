namespace LambdaExpressionsInCsharp;
public class LambdaExpressionsInLinq
{
    Func<string[], string> GetCommaSeparatedList = (values) => string.Join(",", values);
    string[] Fruits = new[] { "apple", "orange", "mango", "pineapple" };

    public void LinqOrderBy()
    {
        var fruitsOrdered = Fruits.OrderBy(name => name).ToArray();
        Console.WriteLine(GetCommaSeparatedList(fruitsOrdered));
    }

    public void LinqSelect()
    {
        var fruitsUpperCase = Fruits.Select(name => name.ToUpper()).ToArray();
        Console.WriteLine($"Fruits in upper case: {GetCommaSeparatedList(fruitsUpperCase)}");
    }

    public void LinqFirst()
    {
        var mango = Fruits.First(name => name == "mango");
        Console.WriteLine($"Matched fruit is {mango}");
    }
}