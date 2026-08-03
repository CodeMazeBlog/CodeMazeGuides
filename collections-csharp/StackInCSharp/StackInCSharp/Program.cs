using StackInCSharp;
using System.Collections;

var page1 = new Page("\nThe first visited page", DateTime.Now);
var page2 = new Page("The second visited page", DateTime.Now);

var nonGenericStackHelper = new NonGenericStackHelper();
var genericStackHelper = new GenericStackHelper<Page>();

nonGenericStackHelper.PushItem(1);
nonGenericStackHelper.PushItem(page1);
nonGenericStackHelper.PushItem("hello");
nonGenericStackHelper.PrintCount();

genericStackHelper.PushItem(page1);
genericStackHelper.PushItem(page2);
genericStackHelper.PrintCount();

object? lastAddedItem = nonGenericStackHelper.PeekItem();
var lastVisitedPage = genericStackHelper.PeekItem();

Console.WriteLine($"\nPeek() METHOD");
Console.WriteLine($"the first retrieved element in lettersStack is {lastAddedItem}");
Console.WriteLine($"the first retrieved element in pageStack is {lastVisitedPage.Title}");

nonGenericStackHelper.PrintCount();
genericStackHelper.PrintCount();

bool result = genericStackHelper.TryPeekItem(out var topPage);

Console.WriteLine($"\nTryPeek METHOD");
Console.WriteLine($"TryPeek returns: {result}");
Console.WriteLine($"the title of the topPage in pageStack is: {topPage?.Title}");
genericStackHelper.PrintCount();

lastAddedItem = nonGenericStackHelper.PopItem();
lastVisitedPage = genericStackHelper.PopItem();

Console.WriteLine($"\nPop() METHOD");
Console.WriteLine($"the first retrieved element in lettersStack is {lastAddedItem}");
Console.WriteLine($"the first retrieved element in pageStack is {lastVisitedPage.Title}");

nonGenericStackHelper.PrintCount();
genericStackHelper.PrintCount();

result = genericStackHelper.TryPopItem(out topPage);

Console.WriteLine($"\nTryPop() METHOD");
Console.WriteLine($"TryPop returns:  {result}");
Console.WriteLine($"the title of the topPage in pageStack is: {topPage?.Title}");
genericStackHelper.PrintCount();

nonGenericStackHelper.ClearStack();
genericStackHelper.ClearStack();

Console.WriteLine($"\nClear() METHOD");
nonGenericStackHelper.PrintCount();
genericStackHelper.PrintCount();

Stack synchronizedStack = nonGenericStackHelper.CreateSynchonizedStack();

Console.WriteLine($"Thread-safety for non-generic case");
Console.WriteLine($"{nameof(nonGenericStackHelper.NonGenericStack)} is thread-safe: {nonGenericStackHelper.IsSynchronizedStack(nonGenericStackHelper.NonGenericStack)}");
Console.WriteLine($"{nameof(synchronizedStack)} is thread-safe: {nonGenericStackHelper.IsSynchronizedStack(synchronizedStack)}");