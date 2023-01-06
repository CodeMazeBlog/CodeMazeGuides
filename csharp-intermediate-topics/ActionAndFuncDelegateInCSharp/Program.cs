
// Action Delegate 
Action<int> actionExample = x => Console.WriteLine("Write {0}", x);
actionExample(5);

// Func Delegate
Func<int, string> funcExample = x => string.Format("{0:n0}", x);

Console.WriteLine(funcExample(5000));



 static void PrintNumbers()
{
    var numbers = new[] { 1000, 224000, 3000, 523000, 70000, 94000 };
    foreach (var item in numbers)
    {
        Console.WriteLine(item);
    }
}

 static void PrintNumbersByFormula(Func<int, string> formula)
{
    var numbers = new[] { 1000, 224000, 3000, 523000, 70000, 94000 };
    foreach (var item in numbers)
    {
        var data = formula(item);
        Console.WriteLine(data);
    }
}

PrintNumbersByFormula(number => string.Format("{0:n0}", number));