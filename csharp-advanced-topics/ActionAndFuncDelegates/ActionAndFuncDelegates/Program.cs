using ActionAndFuncDelegates;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Text;

public class Program
{
    public static void Main()
    {
        string[] inputStr = { "Banana", "Mango", "Raspberry", "Guava", "Papaya", "Cranberry", "Apple", "Plum", "Grapes", "Blueberry", "Pineapple", "Strawberry" };
        string subStr = "berry";

        FuncDelegates funcDel = new(inputStr, subStr);
        FuncDelegates.FuncDelegateWithParameterlessMethod();
        funcDel.FuncDelegateWithParameterizedMethod();
        funcDel.FuncDelegateWithAnonymousMethod();
        funcDel.FuncDelegateWithLambdaExpression();

        ActionDelegates actionDel = new(inputStr, subStr);
        ActionDelegates.ActionDelegateParameterlessMethod();
        actionDel.ActionDelegateWithParameterizedMethod();
        actionDel.ActionDelegateWithAnonymousMethod();
        actionDel.ActionDelegateWithLambdaExpression();

        Console.ReadKey();
    }
}
