using StackInCSharp;
using System.Collections;

Stack myFirstNonGenericStack = new Stack();

var page1 = new Page("The first visited page", DateTime.Now);
var page2 = new Page("The second visited page", DateTime.Now);

myFirstNonGenericStack.Push(1);
myFirstNonGenericStack.Push(page1);
myFirstNonGenericStack.Push("hello");

Stack<Page> pageStack = new Stack<Page>();

Console.WriteLine($"Push() METHOD");
Console.WriteLine($"before Push pageStack contains {pageStack.Count} items");

pageStack.Push(page1);
pageStack.Push(page2);

Console.WriteLine($"after Push pageStack contains {pageStack.Count} items\n");

Page? topPage = null;

object? lastAddedItem = myFirstNonGenericStack.Peek();
var lastVisitedPage = pageStack.Peek();

Console.WriteLine($"Peek() METHOD");
Console.WriteLine($"the first retrieved element in myFirstNonGenericStack is  {lastAddedItem}");
Console.WriteLine($"the first retrieved element in pageStack is {lastVisitedPage.Title}");
Console.WriteLine($"myFirstNonGenericStack contains {myFirstNonGenericStack.Count} items");
Console.WriteLine($"pageStack contains {myFirstNonGenericStack.Count} items");

var result = pageStack.TryPeek(out topPage);

Console.WriteLine($"TryPeek returns:  {result}");
Console.WriteLine($"the topPage in pageStack is:  {topPage?.Title}");
Console.WriteLine($"pageStack contains {myFirstNonGenericStack.Count} items\n");

lastAddedItem = myFirstNonGenericStack.Pop();
lastVisitedPage = pageStack.Pop();

Console.WriteLine($"Pop() METHOD");
Console.WriteLine($"the first retrieved element in myFirstNonGenericStack is  {lastAddedItem}");
Console.WriteLine($"the first retrieved element in pageStack is {lastVisitedPage.Title}");
Console.WriteLine($"myFirstNonGenericStack contains {myFirstNonGenericStack.Count} items");
Console.WriteLine($"pageStack contains {myFirstNonGenericStack.Count} items");

result = pageStack.TryPop(out topPage);

Console.WriteLine($"TryPop returns:  {result}");
Console.WriteLine($"the topPage in pageStack is: {topPage?.Title}");
Console.WriteLine($"contains {myFirstNonGenericStack.Count} items\n");

Stack synchronizedStack = Stack.Synchronized(myFirstNonGenericStack);

Console.WriteLine($"Thread-safety for non-generic case");
Console.WriteLine($"myFirstNonGenericStack is thread-safe: {myFirstNonGenericStack.IsSynchronized}");
Console.WriteLine($"synchronizedStack is thread-safe: {synchronizedStack.IsSynchronized}");




