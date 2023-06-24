using ActionAndFuncDelegatesDemo;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Text;

public class Program
{    
    public static void Main()
    {
        string[] fruits = { "Banana", "Mango", "Raspberry","Guava", "Papaya", "Cranberry", "Apple", "Plum", "Grapes", "Blueberry", "Pineapple", "Strawberry" };
        string subStr = "berry";

        FuncDelegates funcDel = new FuncDelegates(fruits, subStr);
        funcDel.FuncDelegateWithParameterlessMethod();
        funcDel.FuncDelegateWithParameterizedMethod();
        funcDel.FuncDelegateWithAnonymousMethod();
        funcDel.FuncDelegateWithLambdaExpression();

        ActionDelegates actionDel = new ActionDelegates(fruits, subStr);
        actionDel.ActionDelegateParameterlessMethod();
        actionDel.ActionDelegateWithParameterizedMethod();
        actionDel.ActionDelegateWithAnonymousMethod();
        actionDel.ActionDelegateWithLambdaExpression();

        Console.ReadKey();
    }   
}