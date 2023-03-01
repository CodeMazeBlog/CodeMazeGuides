using ActionFuncInCSharp;

int[] array = { 5, 5, 5 };

DemonstrateAction demonstrateAction = new();
demonstrateAction.Main(array);

DemonstrateFunc demonstrateFunc = new();
demonstrateFunc.Main(array);

Console.Read();