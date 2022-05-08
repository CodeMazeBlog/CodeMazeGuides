using StackInCSharp;
using System.Collections;

List<string> letters = new List<string>() { "a", "b", "c" };
Stack lettersStack = new Stack(letters);

var page1 = new Page("The first visited page", DateTime.Now);
var page2 = new Page("The second visited page", DateTime.Now);

Console.WriteLine($"before push lettersStack contains {lettersStack.Count} items");

lettersStack.Push(1);
lettersStack.Push(page1);
lettersStack.Push("hello");

Console.WriteLine($"after 3 Push lettersStack contains {lettersStack.Count} items\n");

Stack<Page> pageStack = new Stack<Page>();

Console.WriteLine($"Push() METHOD");
Console.WriteLine($"before Push pageStack contains {pageStack.Count} items");

pageStack.Push(page1);
pageStack.Push(page2);

Console.WriteLine($"after 2 Push pageStack contains {pageStack.Count} items\n");


object? lastAddedItem = lettersStack.Peek();
var lastVisitedPage = pageStack.Peek();

Console.WriteLine($"Peek() METHOD");
Console.WriteLine($"the first retrieved element in lettersStack is  {lastAddedItem}");
Console.WriteLine($"the first retrieved element in pageStack is {lastVisitedPage.Title}");
Console.WriteLine($"lettersStack contains {lettersStack.Count} items");
Console.WriteLine($"pageStack contains {pageStack.Count} items\n");

var result = pageStack.TryPeek(out var topPage);

Console.WriteLine($"TryPeek METHOD");
Console.WriteLine($"TryPeek returns:  {result}");
Console.WriteLine($"the title of the topPage in pageStack is:  {topPage?.Title}");
Console.WriteLine($"pageStack contains {pageStack.Count} items\n");

lastAddedItem = lettersStack.Pop();
lastVisitedPage = pageStack.Pop();

Console.WriteLine($"Pop() METHOD");
Console.WriteLine($"the first retrieved element in lettersStack is  {lastAddedItem}");
Console.WriteLine($"the first retrieved element in pageStack is {lastVisitedPage.Title}");
Console.WriteLine($"lettersStack contains {lettersStack.Count} items");
Console.WriteLine($"pageStack contains {pageStack.Count} items\n");

result = pageStack.TryPop(out topPage);

Console.WriteLine($"TryPop() METHOD");
Console.WriteLine($"TryPop returns:  {result}");
Console.WriteLine($"the title of the topPage in pageStack is: {topPage?.Title}");
Console.WriteLine($"pageStack contains {pageStack.Count} items\n");

lettersStack.Clear();

Console.WriteLine($"Clear() METHOD");
Console.WriteLine($"lettersStack contains {lettersStack.Count} items\n");

Stack synchronizedStack = Stack.Synchronized(lettersStack);

Console.WriteLine($"Thread-safety for non-generic case");
Console.WriteLine($"lettersStack is thread-safe: {lettersStack.IsSynchronized}");
Console.WriteLine($"synchronizedStack is thread-safe: {synchronizedStack.IsSynchronized}");




