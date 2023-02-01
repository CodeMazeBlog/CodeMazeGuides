//Console.WriteLine("*** An Action delegate demo ***");

//// Create a function that an Action delegate will reference.
//void PrintInfo(string first, string last, int age)
//{
//    Console.WriteLine($"FirstName: {first}\nLastName: {last}\nAge: {age}");
//}

//// Action delegate in action...
//Action<string, string, int> info = PrintInfo;
//info("don", "go", 25);

//Console.WriteLine("--- end of demo ---");


////
//Console.WriteLine("*** A Func delegate demo ***");

//// Create a function that a Func delegate will reference.
//int GetAge(DateOnly bd)
//{
//    int i = DateTime.Today.Year - bd.Year;
//    return i;
//}

//// Func delegate in action...
//Func<DateOnly, int> target = GetAge;
//DateOnly birthDay = new DateOnly(1998, 12, 25);
//int age = target(birthDay);

//// Print the Age according to birthday
//Console.WriteLine($"If your birthday is: {birthDay}\nYour age is: {age}");
//Console.WriteLine("--- end of demo ---");
using ActionFuncDelegates;
Demo.ActionDemo();
Demo.FuncDemo();

