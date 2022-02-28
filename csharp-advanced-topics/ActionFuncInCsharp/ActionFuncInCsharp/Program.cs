
using ActionFuncInCsharp;

#region As Parameters Examples
var personList = new PersonList();

Console.WriteLine("Call => WhereWithDelegate");
var resultDelegate = personList.WhereWithDelegate(p => p.Name == "Murat").FirstOrDefault();
Console.WriteLine($"Name: {resultDelegate?.Name}, Lastname: {resultDelegate?.Lastname}");

Console.WriteLine("Call => WhereWithFunc");
var resultFunc = personList.WhereWithFunc(p => p.Name == "Murat").FirstOrDefault();
Console.WriteLine($"Name: {resultFunc?.Name}, Lastname: {resultFunc?.Lastname}");

Console.WriteLine("Call => ForEachWithDelegate");
personList.ForEachWithDelegate(p => Console.WriteLine($"Name: {p.Name}, Lastname: {p.Lastname}"));

Console.WriteLine("Call => ForEachWithAction");
personList.ForEachWithAction(p => Console.WriteLine($"Name: {p.Name}, Lastname: {p.Lastname}"));
#endregion

#region Declaration Method Referances Examples
var declarations = new Declarations();

Console.WriteLine("Call => printMultiplicationDelegateRefer");
declarations.printMultiplicationDelegateRefer(2, 3);
Console.WriteLine("Call => printMultiplicationActionDelegateRefer");
declarations.printMultiplicationActionDelegateRefer(2, 3);

var result1 = declarations.returnMultiplicationDelegateRefer(2, 3);
Console.WriteLine($"Delegate Refer Result is {result1}");
var result2 = declarations.returnMultiplicationFuncDelegateRefer(2, 3);
Console.WriteLine($"Func Delegate Refer Result is {result1}");
#endregion