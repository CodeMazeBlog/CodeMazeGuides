using HowToCreateAnOuterJoinInLINQLeftAndRight;

Console.WriteLine("Left outer join - query syntax");
Console.WriteLine();

var results = Utilities.PerformLeftJoinWithQuerySyntax(Utilities.Songs, Utilities.Authors);

foreach (var item in results)
{
    Console.WriteLine($"Title: {item.Title}, Author: {item.AuthorName}");
}

Console.WriteLine();
Console.WriteLine();

Console.WriteLine("Right outer join - query syntax");
Console.WriteLine();

results = Utilities.PerformRightJoinWithQuerySyntax(Utilities.Songs, Utilities.Authors);

foreach (var item in results)
{
    Console.WriteLine($"Title: {item.Title}, Author: {item.AuthorName}");
}

Console.WriteLine();
Console.WriteLine();

Console.WriteLine("Left outer join - method syntax");
Console.WriteLine();

results = Utilities.PerformLeftJoinWithMethodSyntax(Utilities.Songs, Utilities.Authors);

foreach (var item in results)
{
    Console.WriteLine($"Title: {item.Title}, Author: {item.AuthorName}");
}

Console.WriteLine();
Console.WriteLine();

Console.WriteLine("Right outer join - method syntax");
Console.WriteLine();

results = Utilities.PerformRightJoinWithMethodSyntax(Utilities.Songs, Utilities.Authors);

foreach (var item in results)
{
    Console.WriteLine($"Title: {item.Title}, Author: {item.AuthorName}");
}

Console.WriteLine();
Console.WriteLine();

Console.WriteLine("Full outer join");
Console.WriteLine();

results = Utilities.PerformFullOuterJoin(Utilities.Songs, Utilities.Authors);

foreach (var item in results)
{
    Console.WriteLine($"Title: {item.Title}, Author: {item.AuthorName}");
}

Console.WriteLine();
Console.WriteLine();

Console.WriteLine("Left excluding join");
Console.WriteLine();

results = Utilities.PerformLeftExcludingJoin(Utilities.Songs, Utilities.Authors);

foreach (var item in results)
{
    Console.WriteLine($"Title: {item.Title}, Author: {item.AuthorName}");
}

Console.WriteLine();
Console.WriteLine();

Console.WriteLine("Right excluding join");
Console.WriteLine();

results = Utilities.PerformRightExcludingJoin(Utilities.Songs, Utilities.Authors);

foreach (var item in results)
{
    Console.WriteLine($"Title: {item.Title}, Author: {item.AuthorName}");
}

Console.WriteLine();
Console.WriteLine();

Console.WriteLine("Full outer excluding join");
Console.WriteLine();

results = Utilities.PerformFullOuterExcludingJoin(Utilities.Songs, Utilities.Authors);

foreach (var item in results)
{
    Console.WriteLine($"Title: {item.Title}, Author: {item.AuthorName}");
}

Console.WriteLine();
Console.WriteLine();