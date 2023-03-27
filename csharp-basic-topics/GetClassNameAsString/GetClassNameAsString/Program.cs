var name = nameof(Program);
Console.WriteLine($"nameof result: {name}");

name = typeof(Program).Name;
Console.WriteLine($"typeof result: {name}");

Program p = new();
name = p.GetType().Name;
Console.WriteLine($"GetType result: {name}");

name = MethodBase.GetCurrentMethod()!.DeclaringType!.Name;
Console.WriteLine($"GetCurrentMethod result: {name}");

// Base class and child class behavior differences
var baseClass = new BaseClass();
name = baseClass.GetNameByGetCurrentMethod();
Console.WriteLine($"BaseClass.GetNameByGetCurrentMethod result: {name}");

name = baseClass.GetNameByGetType();
Console.WriteLine($"BaseClass.GetNameByGetType result: {name}");

name = BaseClass.StaticGetNameByGetCurrentMethod();
Console.WriteLine($"BaseClass.StaticGetNameByGetCurrentMethod result: {name}");

int myPropertyInt = baseClass.MyPropertyInt;
baseClass.MyPropertyInt = 1; 

var childClass = new ChildClass();
name = childClass.GetNameByGetCurrentMethod();
Console.WriteLine($"ChildClass.GetNameByGetCurrentMethod result: {name}");

name = childClass.GetNameByGetType();
Console.WriteLine($"ChildClass.GetNameByGetType result: {name}");

name = ChildClass.StaticGetNameByGetCurrentMethod();
Console.WriteLine($"ChildClass.StaticGetNameByGetCurrentMethod result: {name}");

myPropertyInt = childClass.MyPropertyInt;
childClass.MyPropertyInt = 1;