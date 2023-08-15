using FuncActionDelegateSample;

//declare func delegate
Func<int, int, int> Operation;

//declare Action delegate
Action<string, string> Print;

//instantiate FuncActionDelegate class
FuncActionDelegate funcDelegate = new FuncActionDelegate();

//assign func delgate to Subtract method
Operation = funcDelegate.Subtract;
Console.WriteLine(Operation(10, 5));

//assign Action delgate to PrintFullname method
Print = funcDelegate.PrintFullname;
Print("Code", "Maze");
