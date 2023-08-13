using System;

class Program
{
    //static void Main()
    //{
    //    Console.WriteLine("Enter a key (A, B, or C):");
    //    char key = Console.ReadKey().KeyChar;

    //    Console.WriteLine("\n");

    //    switch (char.ToUpper(key))
    //    {
    //        case 'A':
    //            Console.WriteLine("Action A performed.");
    //            break;
    //        case 'B':
    //            Console.WriteLine("Action B performed.");
    //            break;
    //        case 'C':
    //            Console.WriteLine("Action C performed.");
    //            break;
    //        default:
    //            Console.WriteLine("Invalid key! No action performed.");
    //            break;
    //    }
    //}

    static void PressA()
    {
        Console.WriteLine("Action A performed.");
    }

    static void Main()
    {
        Console.WriteLine("Enter a key (A, B, or C):");

        Dictionary<char, Action> actions = new Dictionary<char, Action>();
        actions.Add('A', PressA);
        actions.Add('B', () => { Console.WriteLine("Action B performed"); });

        char key = Console.ReadKey().KeyChar;

        Console.WriteLine("\n");

        if (actions.ContainsKey(char.ToUpper(key)))
        {
            actions[char.ToUpper(key)].Invoke();
        }
        else
        {
            Console.WriteLine("Invalid key! No action performed.");
        }
    }
}