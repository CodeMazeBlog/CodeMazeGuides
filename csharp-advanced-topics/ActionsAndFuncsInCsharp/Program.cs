using ActionsAndFuncsInCsharp.ActionSample;
using ActionsAndFuncsInCsharp.DelegateSample;
using ActionsAndFuncsInCsharp.FuncSample;

// Delegate Sample
Console.WriteLine("Delegate Sample");
var personDelegate = new PersonDelegate()
{
    FirstName = "John",
    LastName = "Doe"
};

Console.WriteLine(personDelegate.ConstructFullName(NameConstructorLibrary.NameFirst));
Console.WriteLine(personDelegate.ConstructFullName(NameConstructorLibrary.SurnameFirst));


// Func Sample
Console.WriteLine("Func Sample");
var personFunc = new PersonFunc()
{
    FirstName = "John",
    LastName = "Doe"
};

Console.WriteLine(personFunc.ConstructFullName(NameConstructorLibrary.NameFirst));
Console.WriteLine(personFunc.ConstructFullName(NameConstructorLibrary.SurnameFirst));

// Action Sample
Console.WriteLine("Action Sample");
var personAction = new PersonAction()
{
    FirstName = "John",
    LastName = "Doe"
};

personAction.LogFullName(NameLoggingLibrary.LogInDatabase);
personAction.LogFullName(NameLoggingLibrary.LogInFile);


Console.ReadKey();