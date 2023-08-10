namespace ActionAndFuncDelegates;

public static class FuncDelegate
{
    public static void FuncDelegateExample()
    {
        Func<string, string, string> mergeNameAndSurname = (name, surname) =>
        {
            return $"Name: {name} Surname: {surname}";
        };

        var nameAndSurname = mergeNameAndSurname("Code", "Maze");
        Console.WriteLine(nameAndSurname);
    }

    public static IEnumerable<int> FuncQueryingWithLinq()
    {
        List<int> numbers = new() { 1, 2, 3, 4, 5 };
        Func<int, bool> isEven = n => n % 2 == 0;

        return numbers.Where(isEven);
    }
}
