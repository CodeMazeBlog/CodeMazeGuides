
using FuncAndActionDelegate;
using static System.Runtime.InteropServices.JavaScript.JSType;

FuncEx funcEx = new();
funcEx.FuncExample();
funcEx.FuncRealExample( new List<string> { "Test1", "Test2", "Test3" });

ActionEx actionEx = new();
actionEx.ActionExample();
actionEx.ActionRealExample(new List<string>() { "Test1", "Test2", "Test3" });