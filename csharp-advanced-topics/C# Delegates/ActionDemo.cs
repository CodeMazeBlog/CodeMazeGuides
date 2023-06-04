using System;
namespace DelegatesDemo.DelegateAppl
{
    public class ActionDemo
    {
        public static void RunAction()
        {
            Action<string> displayName = delegate (string name)
            {
                name = name.ToUpper();
                Console.WriteLine($"Hello, {name}!");
            };

            displayName("Code Maze");
            Console.ReadKey();
        }
    }
}
