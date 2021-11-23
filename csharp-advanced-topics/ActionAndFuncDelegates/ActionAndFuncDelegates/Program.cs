using System;

namespace ActionAndFuncDelegates
{
    class Program
    {
        static void Main(string[] args)
        {
            // Working with non-generic Action delegates
            Action sayFirstName = PrintFirstName;                        
            sayFirstName(); 
           
            Action sayLastName = new Action(PrintLastName);          
            sayLastName(); 



            //Working with generic Action<T> delegates
            Action<string,int> action = PrintNameAndAge;
            action("Tobby Umoh", 23); 

            Action<string, int> action2 = new Action<string, int>(PrintNameAndAge);
            action2("Tobby Umoh", 23); 



            // Normal syntax
            Func<int, int> func1 = PrintAge;
            var printAge = func1(23);

            Console.WriteLine(printAge);


            // Anonymous type
            Func<int, int> func2 = delegate (int age)
             {
                 int getAge = age;
                 return getAge;
             };

            var printAge2 = func2(23);
            Console.WriteLine(printAge2);


            // Lambda Expression
            Func<int, int> func3 = (a) => a;

            var print = func3(23);
            Console.WriteLine(print); 
        }

        private static int PrintAge(int age)
        {
            return age;   
        }

        private static void PrintFirstName()
        {
            var name = "Tobby";
            Console.WriteLine($"My first name is {name}");
        }
        private static void PrintLastName()
        {
            var name = "Umoh";
            Console.WriteLine($"My last name is {name}");
        }

        private static void PrintNameAndAge(string fullName, int age)
        {
            Console.WriteLine($"My name is {fullName} and i am {age} years old");
        }

    }
}
