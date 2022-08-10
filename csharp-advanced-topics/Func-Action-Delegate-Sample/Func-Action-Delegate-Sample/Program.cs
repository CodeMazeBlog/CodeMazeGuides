#region Func

#region simple method
string Sum(int a, int b)
{
    return (a + b).ToString();
}

Func<int, int, string> calculateSum = Sum;

Console.Write("Simple method: ");
Console.WriteLine(calculateSum(2, 3));
#endregion


#region anonymous method
Func<long, int, double> calculateMultiplication = delegate (long a, int b)
  {
      return a + b;
  };

Console.Write("Anonymous method: ");
Console.WriteLine(calculateMultiplication(12, 13));
#endregion

#region lambda expression
var fruits = new List<string> { "apple", "mango", "dates", "orange" };
string fruit = "orange";
Func<string, bool> isFruitExist = (s) => s == fruit;

Console.Write("Lambda expression: ");
var result = fruits.Where(isFruitExist);
foreach (var item in result)
{
    Console.WriteLine(item);
}
#endregion

#endregion


#region Action
#region simple method
void Subtract(int a, int b, int c)
{
    var result = a + b + c;
}

Action<int, int, int> calculateSubtraction = Subtract;

Console.Write("Simple method: ");
calculateSubtraction(12, 3, 5);
#endregion

#region anonymous method
Action<string, string> concatString = delegate (string a, string b)
{
    var result = a + b;
};

Console.Write("Anonymous method: ");
concatString("code", "maze");
#endregion

#region lambda expression
var names = new List<string> { "John", "Milo", "Rambo", "Joseph" };
string toFind = "John";
Action<string> iNameExist = (n) =>
{
    var result = names.Exists(s => s == toFind);
    Console.WriteLine(result);
};
iNameExist(toFind);
#endregion

#endregion
Console.WriteLine("Hello, World!");
