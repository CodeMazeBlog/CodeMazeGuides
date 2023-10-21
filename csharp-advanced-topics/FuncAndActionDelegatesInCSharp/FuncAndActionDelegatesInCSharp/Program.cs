using FuncAndActionDelegatesInCSharp;

// Regular delegate
Console.WriteLine("Using a regular delegate");
RegularDelegate.UseRegularDelegateToRepeatWord();
Console.WriteLine();

// Func delegate
Console.WriteLine("Using the Func delegate instead");
Utilities.UseFuncDelegateToRepeatWord();
Console.WriteLine();

// Action Delegate
Console.WriteLine("Using the non-generic Action delegate");
Utilities.UseNonGenericActionToBark();
Console.WriteLine();

Console.WriteLine("Using the generic Action delegate");
Utilities.UseGenericActionToGreet();
Console.WriteLine();

// Instantiation
Console.WriteLine("Instantiating with the new keyword - long syntax");
Utilities.UseLongNewKeywordInstantiation();
Console.WriteLine();

Console.WriteLine("Instantiating with the new keyword - short syntax");
Utilities.UseShortNewKeywordInstantiation();
Console.WriteLine();

Console.WriteLine("Instantiating with an anonymous method");
Utilities.UseAnonymousMethodInstantiation();
Console.WriteLine();

Console.WriteLine("Instantiating with a lambda expression");
Utilities.UseLambdaExpressionInstantiation();
Console.WriteLine();

// Delegates as arguments
Console.WriteLine("Using Action as an argument");
Utilities.UseActionAsArgument();
Console.WriteLine();

Console.WriteLine("Using Func as an argument");
Utilities.UseFuncAsArgument();
Console.WriteLine();

Console.WriteLine("Using dynamic method assignment");
Utilities.UseDynamicMethodAssignment();
Console.WriteLine();
