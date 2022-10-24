using ActionAndFuncDelegates;

var data = new int[] {1, 3, 5, 4, 2};

var defaultIndex = new BinarySearchIndex(data, BinarySearchIndex.DefaultIntOrder);

var msgWriter = new MessageWriter("Joe");

defaultIndex.Find(3, msgWriter.ReportElementFound, msgWriter.ReportElementNotFound);
defaultIndex.Find(6, msgWriter.ReportElementFound, msgWriter.ReportElementNotFound);

var index = new BinarySearchIndex(data, (x, y) => x.CompareTo(y));

void ElementFound(int x) => Console.WriteLine($"{x} is found! Yay!");

void ElementNotFound(int x) => Console.WriteLine($"{x} isn't found. Aww.");

index.Find(3, ElementFound, ElementNotFound);
index.Find(6, ElementFound, ElementNotFound);

index.Find(3, x => Console.WriteLine($"{x} is found! Yay!"), x  => Console.WriteLine($"{x} isn't found. Aww."));
index.Find(6, x => Console.WriteLine($"{x} is found! Yay!"), x  => Console.WriteLine($"{x} isn't found. Aww."));

ReportFound rptFoundDelegate = x => Console.WriteLine($"{x} is found! Yay!");
ReportNotFound rptNotFoundDelegate = x => Console.WriteLine($"{x} isn't found. Aww.");

index.Find(3, rptFoundDelegate.Invoke, rptNotFoundDelegate.Invoke);
index.Find(6, rptFoundDelegate.Invoke, rptNotFoundDelegate.Invoke);

public delegate void ReportFound(int x);
public delegate void ReportNotFound(int x);
