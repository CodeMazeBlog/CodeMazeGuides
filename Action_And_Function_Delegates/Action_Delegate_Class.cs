using System;

namespace Action_Delegates.Pages.Shared
{
    
    public class Action_Delegate_Class
    {

        // Method
        public static void GetCompleteName(string FName, string LName)
        {
            string CompleteName = FName + " " + LName;

            Console.WriteLine($"{CompleteName }");
        }


        static public void Main()
        {
            Action<string, string> Concate = GetCompleteName;

            Concate("Ricky", "Martin ");
        }

    }
}


