// See https://aka.ms/new-console-template for more information
using ActionFuncDelegates_Library;
using System;



ActionFuncDelegates.ExecuteActionAndFuncDelegate();

ActionFuncDelegates.ExecuteInstantiatedCustomDelegate();
Console.WriteLine(ActionFuncDelegates.ExecuteInstantiatedCustomDelegate(500)); //overloaded method for testing

ActionFuncDelegates.ExecuteCustomDelegatePointer();
Console.WriteLine(ActionFuncDelegates.ExecuteCustomDelegatePointer(5000)); //overloaded method for testing


ActionFuncDelegates.ExecuteDelegateByInvoke();
ActionFuncDelegates.ExecuteDelegateByName();

ActionFuncDelegates.ExecuteDelegateWithParamenters();
ActionFuncDelegates.ExecuteDelegateWithParamenters(10, 10); //overloaded method for testing

