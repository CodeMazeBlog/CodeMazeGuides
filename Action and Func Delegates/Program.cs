using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Action_and_Func_Delegates
{
    class MovieDirector
    {
        static void Main()
        {
            Action<string> actionScene = (action) => Console.WriteLine($"Action: {action}");
            // Let's direct our actors!
            actionScene("Explosion"); // Action: Explosion
            actionScene("Car Chase"); // Action: Car Chase
            Console.ReadKey();


            //implementing Func

            Func<string, string> performScene = (emotion) => $"Actor performs: {emotion}";
            // Cue the actors!
            string performance = performScene("Romantic Monologue");
            Console.WriteLine(performance); // Actor performs: Romantic Monologue
            Console.ReadKey();

        }
    }
}
