#region Func

#region simple method
string Sum(int a, int b)
{
    return (a + b).ToString();
}

Func<int, int, string> calculateSum = Sum;

Console.WriteLine("Simple method: {0}",calculateSum(2, 3));
#endregion


#region anonymous method
Func<long, int, double> calculateMultiplication = delegate (long a, int b)
  {
      return a + b;
  };

Console.WriteLine("Anonymous method: {0}",calculateMultiplication(12, 13));
#endregion

#region lambda expression
var fruits = new List<string> { "apple", "mango", "dates", "orange" };
string fruit = "orange";
Func<string, bool> isFruitExist = (s) => s == fruit;

var result = fruits.Where(isFruitExist);
foreach (var item in result)
{
    Console.Write("Lambda expression: {0}", item);
}
#endregion

#endregion

Console.WriteLine();Console.WriteLine();
Console.WriteLine("Action");
#region Action
#region simple method
void Subtract(int a, int b, int c)
{
    var result = a - b - c;
    Console.WriteLine("Simple method: {0}", result);
}

Action<int, int, int> calculateSubtraction = Subtract;

calculateSubtraction(12, 3, 5);
#endregion

#region anonymous method
Action<string, string> concatString = delegate (string a, string b)
{
    var result = a + b;
    Console.WriteLine("Anonymous method: {0}", result);
};

concatString("code", "maze");
#endregion

#region lambda expression
var names = new List<string> { "John", "Milo", "Rambo", "Joseph" };
string toFind = "John";
Action<string> iNameExist = (n) =>
{
    var result = names.Exists(s => s == toFind);
    Console.WriteLine("Lambda Expression {0}",result);
};
iNameExist(toFind);
#endregion

#endregion
