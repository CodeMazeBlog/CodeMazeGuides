

using CodeMazeGuides.Sample.Delegates;

//Action<> Delegates
//No Parameter Action<> Delegate
ActionDelegates.welcomeToActionDelegate();

//One Parameter Action<T> Delegate 
ActionDelegates.welcomeToActionDelegateWithParam("Oluleke");

//Two Parameter Action<T1,T2> Delegate 
ActionDelegates.productOfTwoNos(10, 4);

//Complex Parameter Action<T1,T2,T3,T4> Delegate 
ActionDelegates.displayStdInfo("Alice", 10, "Charice", 11);


//Func<> Delegates
//No Parameter Func<> Delegate
string result = FuncDelegates.computeRandom();
Console.WriteLine(result);

//One Parameter Func<T> Delegate
int cubeResult = FuncDelegates.Cube(3);
Console.WriteLine(cubeResult);

//One Parameter Func<T> Delegate
  string stdInfo= FuncDelegates.displayStdInfo("Charice", 10);
Console.WriteLine(stdInfo);
