using Func_Action_Delegate_Library.Action;
using Func_Action_Delegate_Library.Func;

#region Func
Console.WriteLine("Function Delegate");

#region simple method
var funcWithSimpleMethod = new FuncWithSimpleMethod();
funcWithSimpleMethod.calculateSum = funcWithSimpleMethod.Sum;
Console.WriteLine("Simple method: {0}", funcWithSimpleMethod.calculateSum(3, 5));
#endregion


#region anonymous method
var funcWithAnnonymousMethod = new FuncWithAnnonymousMethod();
Console.WriteLine("Anonymous method: {0}", funcWithAnnonymousMethod.calculateMultiplication(12, 13));
#endregion


#region lambda expression
var funcWithLambdaExpression = new FuncWithLambdaExpression();
funcWithLambdaExpression.IsFruitExist = s => s == funcWithLambdaExpression.Fruit;
var result = funcWithLambdaExpression.Fruits.Where(funcWithLambdaExpression.IsFruitExist);
foreach (var item in result)
{
    Console.WriteLine("Lambda expression: {0}", item);
}
#endregion

#endregion

Console.WriteLine(); Console.WriteLine();
#region Action
Console.WriteLine("Action Delegate");

#region simple method
var actionWithSimpleMethod = new ActionWithSimpleMethod();
actionWithSimpleMethod.calculateSubtraction = actionWithSimpleMethod.Subtract;
actionWithSimpleMethod.calculateSubtraction(12, 3, 5);
if (actionWithSimpleMethod.result < 0)
    Console.WriteLine("Cant print as subtraction result in less than 0");
else
    Console.WriteLine("Simple method: {0}", actionWithSimpleMethod.result);
#endregion

#region anonymous method
var actionWithAnnonymousMethod = new ActionWithAnnonymousMethod();
actionWithAnnonymousMethod.concatString("code", "maze");
if (ActionWithAnnonymousMethod.Result == "codemaze")
    Console.WriteLine("yes, concatenated correctly");
else
    Console.WriteLine("no, not concatenated correctly");
#endregion

#region lambda expression
var actionWithLambdaExpression = new ActionWithLambdaExpression();
actionWithLambdaExpression.ToFind = "John";
actionWithLambdaExpression.IsNameExist = n =>
{
    actionWithLambdaExpression.IsFound = actionWithLambdaExpression.Names.Exists(s => s == actionWithLambdaExpression.ToFind);
};
actionWithLambdaExpression.IsNameExist(actionWithLambdaExpression.ToFind);
Console.WriteLine("Found in List : {0}", actionWithLambdaExpression.IsFound?"YES":"NO");
#endregion

#endregion
