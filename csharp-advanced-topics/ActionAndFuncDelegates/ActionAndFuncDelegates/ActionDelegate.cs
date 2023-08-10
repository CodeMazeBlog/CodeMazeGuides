namespace ActionAndFuncDelegates;

public static class ActionDelegate
{
    public static void ActionDelegateExample()
    {
        Action<string, string> printNameAndSurname = (name, surname) =>
        {
            var nameAndSurname = $"Name: {name} Surname: {surname}";
            Console.WriteLine(nameAndSurname);
        };

        printNameAndSurname("Code", "Maze");
    }

    public static void ActionIterationOverCollections()
    {
        var numbers = new List<int>() { 1, 2, 3, 4 }; 
        Action<int> processNumber = n => Console.WriteLine(n * n);
        numbers.ForEach(processNumber);
    }

    public static void ActionEventHandling()
    {
        Action<string> someEvent = firstMessage => Console.WriteLine(firstMessage); 
        someEvent += secondMessage => Console.WriteLine($"Another: {secondMessage}"); 

        someEvent("Code Maze");
    }

    public static void ActionInvoke()
    {
        Action action1 = () => Console.WriteLine("Action 1"); 
        Action action2 = () => Console.WriteLine("Action 2");

        Parallel.Invoke(action1, action2);
    }
}