using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActionAndFuncDelegate
{
    public class Employee
    {
        public int EmployeeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Employee(int employeeId, string firstName, string lastName)
        {
            this.EmployeeId = employeeId;
            this.FirstName = firstName;
            this.LastName = lastName;
        }

        public void Print(Action<string> printerMethod)
        {
            printerMethod.Invoke($"{this.EmployeeId},{this.FirstName},{this.LastName}");
        }
    }
}
