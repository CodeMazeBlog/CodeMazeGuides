#region Action Delegate

#region Action delegate Example

//Action<string> printMessage = PrintMessage;
//printMessage("Hello World!");

//void PrintMessage(string message)
//{
//    Console.WriteLine(message);
//}

#endregion

#region Action delegate (Anonymous method) Example

//Action<string> printMessage = delegate (string message)
//{
//    Console.WriteLine(message);
//};

//printMessage("Hello World!");

#endregion

#region Action delegate (Lambda expression) Example

//Action<string> printMessage = (string message) => Console.WriteLine(message);

//printMessage("Hello World!");

#endregion

#endregion

#region Func Delegate

#region Func delegate Example

//Func<int, int, int> substract = Substraction;
//int calculation = substract(40, 30);
//Console.WriteLine(calculation);

//int Substraction(int x, int y)
//{
//    return x - y;
//}

#endregion

#region Func delegate (Anonymous method) Example

Func<int> getRandomNumber = delegate ()
{
    Random rnd = new Random();
    return rnd.Next(1, 100);
};

// getRandomNumber.Invoke() - use to invoke the delegate to display result

Console.WriteLine(getRandomNumber.Invoke());

#endregion

#region Func delegate (Lambda expression) Example

Func<int, int, int> substract = (int x, int y) => x - y;
Console.WriteLine(substract(10, 5));

#endregion

#endregion