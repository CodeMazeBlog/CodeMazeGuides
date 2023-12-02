using ActionInCsharp;

var foo = new Foo();
foo.SetStatus(Status.InProgress, LogChangeStatus);

void LogChangeStatus(Status status)
{
    Console.WriteLine($"Current status: {status}");
}
