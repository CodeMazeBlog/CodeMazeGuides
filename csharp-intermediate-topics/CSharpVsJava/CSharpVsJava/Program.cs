using CSharpVsJava;

switch (args.FirstOrDefault())
{
    case "generics": GenericsDemo.Run(); break;
    case "memory": MemoryDemo.Run(); break;
    case "concurrency": await ConcurrencyDemo.RunAsync(); break;
    case "linq": LinqDemo.Run(); break;
    case "shapes": ShapesDemo.Run(); break;
    case "nulls": NullDemo.Run(); break;
    case "nulls-unchecked": NullDemo.RunUnchecked(); break;
    case "everyday": EverydayDemo.Run(); break;
    default:
        Console.WriteLine("Pass one of: generics, memory, concurrency, linq, shapes, nulls, nulls-unchecked, everyday");
        break;
}
