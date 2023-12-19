//Declare Action delegate with no parameters
Action display = PrintMessage;
//Calling Action delegate
display();
static void PrintMessage()
{
    Console.WriteLine("Hello is printed");
}

//Creating Action delegate with parameters
Action<string, int> printEmployeeNameAndNo = (name, no) =>
{
    Console.WriteLine($"Employee Name: {name},and No: {no}");
};
//Calling Action delegate
printEmployeeNameAndNo("John", 146);

//Creating Func delegate with parameters
Func<int, int, int> add = (x, y) => x + y;
//Calling Func delegate
Console.WriteLine(add.Invoke(10, 20));

//Creating Func delegate with no parameters
Func<string> sayHello = () => "Hello";
//Calling Func delegate
sayHello();