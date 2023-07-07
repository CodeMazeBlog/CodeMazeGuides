using ActionAndFuncDelegateInCSharp;

DelegatesDefinition delegatesDefinition = new();

Action<int, int> getSumofNumbers = delegatesDefinition.GetSumOfNumbers;

getSumofNumbers.Invoke(1, 2);

Func<string, string, string> getFullNameDelegate = delegatesDefinition.GetFullName;

Console.WriteLine(getFullNameDelegate.Invoke("Code", "Maze"));