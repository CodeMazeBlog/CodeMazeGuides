
//var myDelegate = new MyDelegate(DisplayText); //Instantiate the delegate
//myDelegate("Hello World!"); //Invoke the DisplayText method using the delegate instance
//Console.Read();
void DisplayText(string str)
{
    Console.WriteLine(str);
}

//delegate void MyDelegate(string str); //Declare a delegate


Action<string> actionDelegate = new Action<string>(DisplayText);
actionDelegate("Hello World!");

Func<double, double> functionDelegate = new Func<double, double>(GetTax);
Console.WriteLine(functionDelegate(100000)); //Invoke the GetTax method using the delegate instance
static double GetTax(double netSalary)
{
    return (double)(netSalary * .3);
}


Console.Read();