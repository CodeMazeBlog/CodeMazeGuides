using ActionFuncDelegates;

Action printText = new Action(DelegatesMethods.PrintText);
Action<string> print = new Action<string>(DelegatesMethods.Print);
Action<int, int> printNumber = new Action<int, int>(DelegatesMethods.PrintNumbers);

Func<int, int, int> add1 = new Func<int, int, int>(DelegatesMethods.Addition);
Func<int, int, string> add2 = new Func<int, int, string>(DelegatesMethods.DisplayAddition);
Func<string, string, string> completeName = new Func<string, string, string>(DelegatesMethods.FullName);

Console.WriteLine("\n***************** Action<> Delegate Methods ***************\n");

printText();            //Parameter: 0 , Returns: nothing
print("Mathasuriya");   //Parameter: 1 , Returns: nothing
printNumber(50, 40);    //Parameter: 2 , Returns: nothing
Console.WriteLine();

Console.WriteLine("**************** Func<> Delegate Methods *****************\n");

int addition = add1(50, 10);                            //Parameter: 2 , Returns: int
string addition2 = add2(10, 20);                        //Parameter: 2 , Returns: string
string name = completeName("Ajay", "Mathasuriya");      //Parameter:2 , Returns: string

Console.WriteLine("Addition: {0}", addition);
Console.WriteLine(addition2);
Console.WriteLine(name);

Console.ReadLine();
