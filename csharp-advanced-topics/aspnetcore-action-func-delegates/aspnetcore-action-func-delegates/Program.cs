// See https://aka.ms/new-console-template for more information
using aspnetcore_action_func_delegates.ActionDelegate;
using aspnetcore_action_func_delegates.DelegateClass;
using aspnetcore_action_func_delegates.FuncDelegate;

Console.WriteLine("Project to explain the delegate type");

// Test the delegate class
Console.WriteLine("\n\n-------------------------------------");
MyDelegateClass.MainDelegateClass();

// Test the delegate action
Console.WriteLine("\n\n-------------------------------------");
MyDelegateAction.MainAction();

// Test the delegate func
Console.WriteLine("\n\n-------------------------------------");
MyDelegateFunc.MainFunc();