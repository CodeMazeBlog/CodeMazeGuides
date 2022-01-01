using System;

namespace CodeMaz
{
    class Program
    {
        static string Text = "hello world";
        static void Capitalize()
        {
            Text = Text.ToUpper();
        }

        static void Main(string[] args)
        {
            var capitalizeAction = new Action(Capitalize);
            var anonymousCapitalizeAction = new Action(() => Text = Text.ToUpper());
            capitalizeAction();
            Text = Text.ToLower();
            anonymousCapitalizeAction();
        }

    }
}
