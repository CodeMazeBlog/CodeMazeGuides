using ActionAndFuncDelegateAssessment;

var numbers = new List<int> { 1, 2, 3, 4, 5 };

Examples.ActionDelegateExample(numbers);
Console.WriteLine(Examples.FuncDelegateExample(numbers));
Console.WriteLine(Examples.MultithreadExample());