using System;
using System.Linq;
using System.Collections.Generic;

namespace ActionAndFuncDelegatesInCsharp
{
    public static class Program
    {
        enum Reports { Adults = 1, BMI = 2 }
        enum Sorting { FirstName = 1, LastName = 2 }
        enum Printing { Serial = 1, Tabular = 2 }

        static List<Person> people = new List<Person> {
            new Person { firstName = "Arlene", lastName = "Underfoot", age = 19, height = 130, weight = 60 },
            new Person { firstName = "Bob", lastName = "Vercetti", age = 24, height = 160, weight = 80 },
            new Person { firstName = "Charles", lastName = "Zane", age = 13, height = 130, weight = 40 },
            new Person { firstName = "Darcy", lastName = "Yankovich", age = 18, height = 150.8, weight = 75.5 },
            new Person { firstName = "Eugene", lastName = "Xavier", age = 30, height = 180, weight = 60 },
            new Person { firstName = "Fiona", lastName = "Tancredi", age = 40, height = 165, weight = 75 },
            new Person { firstName = "George", lastName = "Wanderer", age = 10, height = 90.8, weight = 50.5 }
        };

        static void Main(string[] args)
        {
            Console.WriteLine("Please select your desired Report:");
            Console.WriteLine($"Adults ({(int) Reports.Adults})");
            Console.WriteLine($"BMI ({(int) Reports.BMI})");
            var input = Console.ReadLine();
            Reports report;
            Sorting sorting;
            Printing printing;
            if(Enum.TryParse(input, out report)) {
                Console.WriteLine("Please select your desired Order:");
                Console.WriteLine($"First Name ({(int) Sorting.FirstName})");
                Console.WriteLine($"Last Name ({(int) Sorting.LastName}) ");
                input = Console.ReadLine();
                if(Enum.TryParse(input, out sorting)) {
                    Console.WriteLine("How would you like your report?:");
                    Console.WriteLine($"Serial ({(int) Printing.Serial})");
                    Console.WriteLine($"Tabular ({(int) Printing.Tabular}) ");
                    input = Console.ReadLine();
                    if(Enum.TryParse(input, out printing)) {
                        ExecuteReport(report, sorting, printing);
                    }
                }
            } else {
                Console.WriteLine("You did not enter a valid report. \nEnding...");
            }
        }

        static void ExecuteReport(Reports subject, Sorting order, Printing printStyle)
        {
            Func<Person, bool> Subject;
            Func<Person, string> Order;
            Action<List<Person>> Print;

            switch(subject)
            {
                case Reports.BMI:
                    Subject = isHighBMI;
                    break;
                default:
                    Subject = is18Plus;
                    break;
            }

            switch(order)
            {
                case Sorting.LastName:
                    Order = orderLastName;
                    break;
                default:
                    Order = orderFirstName;
                    break;
            }

            switch(printStyle)
            {
                case Printing.Tabular:
                    Print = printTabular;
                    break;
                default:
                    Print = printSerial;
                    break;
            }

            // Use all the selected delegates
            Print(people.Where(Subject).OrderBy(Order).ToList());
        }

        // Return true for ages over 17
        public static bool is18Plus(Person p) => p.age >= 18;
        
        // Return true for BMI over 25
        public static bool isHighBMI(Person p) => p.weight/(p.height * p.height/10000) > 25;

        // Return lastName Property
        public static string orderLastName(Person p) => p.lastName;

        // Return firstName Property
        public static string orderFirstName(Person p) => p.firstName;

        // Print formatting each separate Person object
        public static void printSerial(List<Person> people)
        {
            foreach(var (person, index) in people.Select((item, index) => (item, index + 1)))
            {
                Console.WriteLine($"Person {index}");
                Console.WriteLine("========================");
                Console.WriteLine($"Name   | {person.firstName} {person.lastName}");
                Console.WriteLine($"Age    | {person.age}");
                Console.WriteLine($"Height | {person.height}");
                Console.WriteLine($"Weight | {person.weight}");
                Console.WriteLine("");
            }
        }

        // Print formatting all Persons as a table
        public static void printTabular(List<Person> people)
        {
            Console.WriteLine("-------------------------------------------------------------------");
            Console.WriteLine("SN |    Full Name             |   Age   |   Height   |   Weight   |");
            Console.WriteLine("-------------------------------------------------------------------");
            foreach(var (person, index) in people.Select((item, index) => (item, index + 1)))
            {
                
                Console.WriteLine($"{index}  | {person.firstName} {person.lastName}       " + 
                $"  |   {person.age}    |    {person.height}     |    {person.weight}     |");
                Console.WriteLine("-------------------------------------------------------------------");
            }
            Console.WriteLine("");
        }

    }
}
