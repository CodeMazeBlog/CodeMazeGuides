using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQAdvancedTests.Models
{
    public class TestData
    {
        public static List<Director> Directors = new List<Director>()
        {
            new()
            {
                AbleToHire = true, 
                Permissions = "READ_WRITE_CREATE_DELETE", 
                EmployeeId = 100,
                Name = "Nikola Jokic", 
                Department = "Leadership", 
                Salary = 175000.00, 
                DepartmentResponsibleFor = "Engineering"
            },
            new()
            {
                AbleToHire = true, 
                Permissions = "READ_WRITE_CREATE_DELETE", 
                EmployeeId = 101,
                Name = "Petr Cech", 
                Department = "Leadership", 
                Salary = 175000.00, 
                DepartmentResponsibleFor = "IT"
            },
            new()
            {
                AbleToHire = true, 
                Permissions = "READ_WRITE_CREATE_DELETE", 
                EmployeeId = 102,
                Name = "Carl Friedrich Gauss", 
                Department = "Leadership", 
                Salary = 175000.00, 
                DepartmentResponsibleFor = "R&D"
            },
        };

        public static List<Employee> Employees = new List<Employee>()
        {
            new() 
            { 
                EmployeeId = 1, 
                Name = "Alvin Johnston", 
                Department = "Sales", 
                Salary = 55000.00 
            },
            new() 
            { 
                EmployeeId = 2, 
                Name = "Jessica Cuevas",
                Department = "Engineering", 
                Salary = 65000.00 
            },
            new() 
            { 
                EmployeeId = 3, 
                Name = "Grace Silver", 
                Department = "Sales", 
                Salary = 75000.00 
            },
            new() 
            { 
                EmployeeId = 4, 
                Name = "Justin Vilches", 
                Department = "Engineering", 
                Salary = 85000.00 
            },
            new() 
            { 
                EmployeeId = 5, 
                Name = "Joey Delgado", 
                Department = "IT", 
                Salary = 85000.00 
            },
            new() 
            {
                EmployeeId = 6, 
                Name = "Ashley Montoya", 
                Department = "Engineering", 
                Salary = 85000.00 
            },
            new() 
            { 
                EmployeeId = 7, 
                Name = "Silvio Mora", 
                Department = "IT", 
                Salary = 85000.00 
            },
            new() 
            { 
                EmployeeId = 8, 
                Name = "Arjen Robben", 
                Department = "Administration", 
                Salary = 105000.00 
            },
            new() 
            { 
                EmployeeId = 9, 
                Name = "Mohammad Salah", 
                Department = "Administration", 
                Salary = 115000.00 
            },
            new() 
            { 
                EmployeeId = 10, 
                Name = "Nasir Jones", 
                Department = "Customer Service", 
                Salary = 45000.00 
            },
        };

        public static List<Employee> MixedEmployees = new List<Employee>()
        {
            new Director() 
            {
                AbleToHire = true, 
                Permissions = "READ_WRITE_CREATE_DELETE", 
                EmployeeId = 1,
                Name = "Rodrigo Suarez", 
                Department = "Leadership", 
                Salary = 175000.00
            },
            new() 
            { 
                EmployeeId = 2, 
                Name = "Jessica Cuevas", 
                Department = "Engineering", 
                Salary = 65000.00 
            },
            new() 
            { 
                EmployeeId = 7, 
                Name = "Silvio Mora", 
                Department = "IT", 
                Salary = 85000.00 
            },
            new Administrator() 
            { 
                AbleToFire = false, 
                EmployeeId = 8, 
                Name = "Arjen Robben", 
                Department = "Administration", 
                Salary = 105000.00 
            },
            new Administrator() 
            { 
                AbleToFire = true, 
                EmployeeId = 9, 
                Name = "Mohammad Salah", 
                Department = "Administration",
                Salary = 115000.00 },
            new() 
            { 
                EmployeeId = 10, 
                Name = "Nasir Jones", 
                Department = "Customer Service", 
                Salary = 45000.00 
            },
        };

        public static List<int> ints = new List<int>() { 2, 7, 2, 4, 5, 8, 9, 6, 1, 8, 9, 7 };
    }
}
