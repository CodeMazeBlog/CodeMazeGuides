using ConvertListOfStringToCommaSeparatedString.Model;

namespace ConvertListOfStringToCommaSeparatedString
{
    public class ComplexList
    {
        public string ConvertListOfStringsToCommaSeparatedString()
        {
            var employeeList = new List<Employee> {
            new Employee {
               Id = 1,
               Name = "Sarah"
            },
            new Employee {
               Id = 2,
               Name = "Eric"
            }
         };
            string employeeNames = string.Join(",", employeeList.Select(employee => employee.Name));
            return employeeNames; 
        }
    }
}
