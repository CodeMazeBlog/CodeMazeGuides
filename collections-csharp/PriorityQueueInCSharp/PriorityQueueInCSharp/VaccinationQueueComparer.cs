using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriorityQueueInCSharp
{
    public class VaccinationQueueComparer : IComparer<Person>
    {
        public int Compare(Person x, Person y)
        {
            Console.WriteLine($"Comparing {x.Name} and {y.Name}");
            Console.WriteLine();    

            if (x.Age == y.Age)
                return 0;
            else if(x.Age > y.Age)
                return -1;
            else
                return 1;  
        }
    }
}
