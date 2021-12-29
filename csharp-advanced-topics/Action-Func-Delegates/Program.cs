using System;

namespace GenericDelegates
{
    public class Program
    {
        //Method - It returns sum of x and y values      
        public static int AddingTwoNumbers_Func(int x, int y)      
        {
            return x + y;      
        }

        //It calculates sum of x an y values
        public static void AddingTwoNumbers_Action(int x, int y)
        {
            int sum = x + y;
            Console.WriteLine(sum);
        }

        //Main method - Program starts here      
        public static void Main(string[] args)      
        {
            //Calling the method using Func Delegate
            Func<int,int, int> delegate_func = AddingTwoNumbers_Func;           
            int sum = delegate_func(10, 10);           
            Console.WriteLine(sum);

            //Calling the method using Action Delegate
            Action<int, int> delegate_action = AddingTwoNumbers_Action;
            delegate_action(10, 10);
        }
        
    }
}
