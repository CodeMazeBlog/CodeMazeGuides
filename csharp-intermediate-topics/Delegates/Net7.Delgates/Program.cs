using System.ComponentModel;

namespace Net7.Delgates
{

    public class Program
    {
        // declaration
        public delegate void DisplayMessage(string message);

        public static void Print(string value)
        {
            Console.WriteLine(value);
        }

        public static string GetFullName(string firstName, string lastName)
        {
            return $"{firstName} {lastName}";
        }

        static void Main(string[] args)
        {

            // Delegate
            // create instance 
            var displayMessageDelegate = new DisplayMessage(Print);

            // calling delegate
            displayMessageDelegate.Invoke("Hello delegates!");


            // Func
            // create instance 
            Func<string, string, string> getFullNameDelegate = GetFullName;

            // invocation
            var result = getFullNameDelegate.Invoke("Kanhaya", "Tyagi");

            Console.WriteLine(result);

            // Action
            // create instance 
            Action<string> actionDelegate = Print;

            // calling delegate
            actionDelegate.Invoke("Hello delegates!");

        }
    }

}