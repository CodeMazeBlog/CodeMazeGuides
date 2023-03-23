using ActionAndFuncDelegates;

var addValues = new MyDelegates.CombineTwoValuesDelegate(MyMathOperations.AddTwoNumbers);
var subtractValues = new MyDelegates.CombineTwoValuesDelegate(MyMathOperations.SubtractTwoNumbers);
var writeOutput = new MyDelegates.WriteOutput(MyOutputOperations.WriteOutput);

writeOutput($"{addValues(20, 10)}");
writeOutput($"{subtractValues(20, 10)}");