

using CodeMazeGuides.Sample.Delegates;

//Action<> Delegates
//No Parameter Action<> Delegate
ActionDelegates.WelcomeToActionDelegate();

//One Parameter Action<T> Delegate 
ActionDelegates.WelcomeToActionDelegateWithParam("Oluleke");

//Two Parameter Action<T1,T2> Delegate 
ActionDelegates.ProductOfTwoNos(10, 4);

//Complex Parameter Action<T1,T2,T3,T4> Delegate 
ActionDelegates.DisplayStdInfo("Alice", 10, "Charice", 11);


//Func<> Delegates
//No Parameter Func<> Delegate
string result = FuncDelegates.ComputeRandom();
Console.WriteLine(result);

//One Parameter Func<T> Delegate
int cubeResult = FuncDelegates.Cube(3);
Console.WriteLine(cubeResult);

//One Parameter Func<T> Delegate
  string stdInfo= FuncDelegates.DisplayStdInfo("Charice", 10);
Console.WriteLine(stdInfo);
