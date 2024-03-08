using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegateApp
{
    public enum EmployeeType
    {
        FullTime,
        PartTime,
        Contractual
    }

    public class Employee
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public EmployeeType EmployeeType { get; set; }
    }
}
