#region Func implementation
//Implementation type 1: usual
Func<int, int, int> funcDel;

int Multiply(int a, int b)
{
    return a * b;
}

int Sum(int a, int b)
{
    return a + b;

}
funcDel = Multiply;
Console.WriteLine("Func Delegate:The result of the multiplication operation is:" + funcDel(4, 5));
funcDel = Sum;
Console.WriteLine("Func Delegate:The result of the sum operation is:" + funcDel(4, 5));
//Implementation type 2: anpnymous function
Func<int, int, string> funcDel1 = delegate (int x, int y)
{
    string result = string.Format("Multiplication of {0} and {1} is: {2}", x, y, (x * y));
    return result;
};
Console.WriteLine("Func Anonymous method: " + funcDel1(4, 5));

//Implementation type 3: lambda expression
Func<int, int, string> funcDel2 = (x, y) =>
string.Format(" Multiplication of {0} and {1} is: {2}", x, y, (x * y));

Console.WriteLine("Func Lambda expression :" + funcDel2(3, 2));
#endregion Func Implementation

#region Action delegate implementation
//Implementation type 1: classic
Action<int, int> action1;

void ActionMultiply(int x, int y)
{
    Console.WriteLine("Action normal delegate multiplication " + (x * y));
}
action1 = ActionMultiply;
action1(10, 20);
//End of implementation type 1

//Implementation type 2: anonymous function
Action<int, int> action2 = delegate (int x, int y)
{
    Console.WriteLine("Action anonymous: Sum is " + (x + y));
};
action2(10, 20);
//end of implementation type 2
//implementation type 3:lambda expression
Action<int, int> action3 = (x, y) =>
{
    Console.WriteLine("Action lambda Sum:" + (x + y));
};
action3(10, 20);
#endregion 
