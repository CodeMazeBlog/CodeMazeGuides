using System;
using System.Collections.Generic;
using System.Linq;

namespace GenericDelegates
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public char Gender { get; set; }
        public string City { get; set; }
        public string Designation { get; set; }

        public Employee(int id, string name, char gender, string city, string designation)
        {
            Id = id;
            Name = name;
            Gender = gender;
            City = city;
            Designation = designation;
        }

        public static List<Employee> GetEmployeeByCity(List<Employee> employees, string city)
        {
            return employees.Where(e => e.City == city).ToList();
        }

        public static void PrintEmployeeDetailById(List<Employee> employees, int Id)
        {
            var employee = employees.Where(e => e.Id == Id).FirstOrDefault();
            if (employee != null)
            {
                Console.WriteLine($"Employee with EmployeeId {Id}");
                Console.WriteLine($"Name: {employee.Name}, Role: {employee.Designation}, City: {employee.City}");
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var employees = GetEmployeeList();

            Func<List<Employee>, string, List<Employee>> funcGetEmployeeByCity = Employee.GetEmployeeByCity;

            var city = "NYC";

            var listEmployee = funcGetEmployeeByCity(employees, city);

            foreach (var emp in listEmployee)
            {
                Console.WriteLine($"Employee who lives in {city}");
                Console.WriteLine($"Name: {emp.Name}, Role: {emp.Designation}");
            }

            Action<List<Employee>, int> actionPrintEmployeeDetailById = Employee.PrintEmployeeDetailById;

            var empId = 1;

            actionPrintEmployeeDetailById(employees, empId);
        }

        private static List<Employee> GetEmployeeList()
        {
            return new List<Employee>
            {
                new Employee(1, "John Doe", 'M', "BLR", "Software Engineer"),
                new Employee(2, "Jane Smith", 'M', "Texas", "Project Manager"),
                new Employee(3, "Alice Brown",'M' ,"HYD","QA Engineer"),
                new Employee(4, "Bob White", 'M',"NYC", "DevOps Engineer"),
                new Employee(5, "Meloni", 'F',"NYC", "HR")
            };
        }
    }
}
