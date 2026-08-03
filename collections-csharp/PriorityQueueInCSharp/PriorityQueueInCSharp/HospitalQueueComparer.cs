using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriorityQueueInCSharp
{
    public class HospitalQueueComparer : IComparer<Patient>
    {
        public int Compare(Patient x, Patient y)
        {
            Console.WriteLine($"Comparing {x.Name} and {y.Name}\n\r"); 

            if (x.Age == y.Age)
                return 0;
            else if(x.Age > y.Age)
                return -1;
            else
                return 1;  
        }
    }
}
