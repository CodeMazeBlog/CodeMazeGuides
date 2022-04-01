using ExpressionTreeInCsharp;
using System.Linq.Expressions;

Func<int, bool> isEvenNumber = x => (x % 2) == 0;
Expression<Func<int, bool>> isEvenNumberExpr = x => x % 2 == 0;

var isEven = isEvenNumber(10);
Console.WriteLine(isEvenNumber.Invoke(10));
Console.WriteLine(isEvenNumberExpr.Compile());

var type = isEvenNumberExpr.Type;
var body = isEvenNumberExpr.Body;
var pes = isEvenNumberExpr.Parameters;
var name = isEvenNumberExpr.Name;
var returnType = isEvenNumberExpr.ReturnType;

Console.WriteLine($"isEvenNumberExpr info:");
Console.WriteLine($"Type: {type}");
Console.WriteLine($"Body: {body}");
foreach (ParameterExpression pe in pes)
{
    Console.WriteLine($"ParameterExpression\n \tname: {pe.Name}\n\ttype: {pe.Type}\n\tnode type: {pe.NodeType}");
}
Console.WriteLine($"Name: {name}");
Console.WriteLine($"Return Type: {returnType}");

var parameter = Expression.Parameter(typeof(int), "x");

var utility = new ExpressionUtility();
var be = utility.CreateExpression(parameter);
var isEvenOrMultipleOfThree = utility.EvenOrMultipleOfThree();

Console.WriteLine(isEvenOrMultipleOfThree(14));
Console.WriteLine(isEvenOrMultipleOfThree(9));
Console.WriteLine(isEvenOrMultipleOfThree(19));


var treeModifier = new CustomExpressionVisitor();
var modifiedExpr = treeModifier.Modify((Expression)be);

Console.WriteLine("Before: " + be);
Console.WriteLine("After: " + modifiedExpr);

Func<int, bool> isEvenAndMultipleOfThree = Expression.Lambda<Func<int, bool>>(modifiedExpr, parameter).Compile();

Console.WriteLine(isEvenAndMultipleOfThree(14));
Console.WriteLine(isEvenAndMultipleOfThree(9));
Console.WriteLine(isEvenAndMultipleOfThree(19));
