using System;

namespace Action_Delegates
{
    
    public class Action_Delegate_Class
    {
         
        // Method
        public static void GetCompleteName(string FName, string LName)
        {
            string CompleteName = FName + " " + LName;

            Console.WriteLine($"{CompleteName }");
        }



    }
}


