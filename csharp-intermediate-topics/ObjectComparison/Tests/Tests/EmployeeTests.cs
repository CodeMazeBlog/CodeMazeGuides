using ObjectComparisons;
using Xunit;

namespace Tests
{
    public class EmployeeTests
    {
        [Fact]
        public void EmployeeArray_WhenDefaultSorted_ThenIsOrderedBasedOnId()
        {
            var employees = GetEmployees();

            Array.Sort(employees);

            for (int i = 0; i < 4; i++)
            {
                Assert.True(employees[i].Id < employees[i + 1].Id);
            }
        }

        [Fact]
        public void EmployeeArray_WhenSortedUsingIComparer_ThenIsOrderedBasedOnId()
        {
            var employees = GetEmployees();

            Array.Sort(employees, Employee.SortByIdAscending());

            for (int i = 0; i < 4; i++)
            {
                Assert.True(employees[i].Id < employees[i + 1].Id);
            }
        }

        [Fact]
        public void EmployeeArray_WhenSortedUsingComparisonDelegate_ThenIsOrderedBasedOnId()
        {
            var employees = GetEmployees();

            Array.Sort(employees, Employee.CompareEmployeesByIdAscending);

            for (int i = 0; i < 4; i++)
            {
                Assert.True(employees[i].Id < employees[i + 1].Id);
            }
        }

        private static Employee[] GetEmployees()
        {
            return new Employee[5]
            {
                new Employee(4, "John"),
                new Employee(2, "Tom"),
                new Employee(1, "Eric"),
                new Employee(5, "Dan"),
                new Employee(3, "Alen")
            };
        }
    }
}