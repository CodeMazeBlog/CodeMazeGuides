using System;

namespace ActionFuncDelegates
{
    class Program
    {
        static void Main(string[] args)
        {
            Action learningAction = new Action(Learning);
            learningAction();

            Func<string, string, string> concateFunc = ConcateString;
            string concatedText = concateFunc("Hi, I'm learning c#", "from code-maze.com");
            Console.WriteLine(concatedText);
        }
        public static void Learning()
        {
            Console.WriteLine("Hi, I am learning Action Delegates");
        }
        public static string ConcateString(string input1, string input2)
        {
            return input1 + " " + input2;
        }
    }
}
