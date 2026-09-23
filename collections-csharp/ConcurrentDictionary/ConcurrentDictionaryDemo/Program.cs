
try
{
    new NaiveExampleUnsized().Run();
}
catch (AggregateException ex)
{
    Console.WriteLine(ex);
}

Console.WriteLine(new string('=', 20));

new NaiveExample().Run();

Console.WriteLine(new string('=', 20));

new SecondExample().Run();

Console.WriteLine(new string('=', 20));

new BetterApproach().Run();

Console.WriteLine(new string('=', 20));

new AntipatternExample().Run();

Console.WriteLine(new string('=', 20));

Console.WriteLine("Running ContentionExample, this takes a few seconds...");
new ContentionExample().Run();

Console.WriteLine(new string('=', 20));

Console.WriteLine("Running MemoryLeakExample, this takes a few seconds...");
new MemoryLeakExample().Run();

