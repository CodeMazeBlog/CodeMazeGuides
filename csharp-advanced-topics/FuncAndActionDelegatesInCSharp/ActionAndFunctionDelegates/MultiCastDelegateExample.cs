using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Action_and_Function_Delegates
{
    public class MultiCastDelegateExample
    {
            
        public static List<Employees> Employees { get; set; } = new()
        {
            new Employees { Name = "Harry Styles", Age = 24, Dept = Departments.Bard, OrcKills = Random.Shared.Next(100000) },
            new Employees { Name = "Legolas Mirkwood", Age = 118, Dept = Departments.Archer, OrcKills = Random.Shared.Next(100000) },
            new Employees { Name = "Jaina Proudmore", Age = 32, Dept = Departments.Archmage, OrcKills = Random.Shared.Next(100000) },
            new Employees { Name = "Harry Styles", Age = 24, Dept = Departments.Bard, OrcKills = Random.Shared.Next(100000) },
            new Employees { Name = "Harry Potter", Age = 118, Dept = Departments.Wizard, OrcKills = Random.Shared.Next(100000) },
            new Employees { Name = "Greenwich Hollow", Age = 32, Dept = Departments.Abyss, OrcKills = Random.Shared.Next(100000) },
            new Employees { Name = "Abyssal Grounds", Age = 24, Dept = Departments.Abyss, OrcKills = Random.Shared.Next(100000) },
            new Employees { Name = "Teethering Heavens", Age = 118, Dept = Departments.Abyss, OrcKills = Random.Shared.Next(100000) },
            new Employees { Name = "Cloudburst Inferno", Age = 32, Dept = Departments.Elemental, OrcKills = Random.Shared.Next(100000) },
            new Employees { Name = "Diablo Nevermore", Age = 24, Dept = Departments.Elemental, OrcKills = Random.Shared.Next(100000) },
            new Employees { Name = "Frodo Baggins", Age = 118, Dept = Departments.BraveFool, OrcKills = Random.Shared.Next(100000) },
            new Employees { Name = "Samwise Gamgee", Age = 32, Dept = Departments.BraveFool, OrcKills = Random.Shared.Next(100000) }
        };

        public static void OrderByDept()
        {
            Employees = Employees.OrderBy(emp => (int)emp.Dept).ToList(); 
        }

        public static IEnumerable<IGrouping<Departments, Employees>> GroupByDepts()
        {
            var EmployeesByDepts = Employees.GroupBy(dept => dept.Dept);

            return EmployeesByDepts; 
        }

        public static Dictionary<Departments, int> KillsByDeptsUsingDelegate(IEnumerable<IGrouping<Departments, Employees>> employeesByDepts)
        {
            Dictionary<Departments, int> killsByDepts = new();
            foreach (var dept in employeesByDepts)
            {
                var kills = dept.Sum(orcKills => orcKills.OrcKills);
                AddToDictionary(killsByDepts, dept.Key, kills);
            }
            return killsByDepts;
        }

        public static Dictionary<Departments, int> PersonnelByDeptsUsingDelegate(IEnumerable<IGrouping<Departments, Employees>> employeesByDepts)
        {
            Dictionary<Departments, int> empByDepts = new();
            foreach (var dept in employeesByDepts)
            {
                var empCount = dept.Count();
                AddToDictionary(empByDepts, dept.Key, empCount);
            }
            return empByDepts;
        }

        public static void PrintItem(Delegate listItem)
        {
            Console.WriteLine($"   {listItem}");
        }

        public static Dictionary<Departments, int> KillsByDepts(IEnumerable<IGrouping<Departments, Employees>> employeesByDepts)
        {
            Dictionary<Departments, int> killsByDepts = new(); 
            foreach(var dept in  employeesByDepts) 
            {
                var kills = dept.Sum(orcKills => orcKills.OrcKills);
                AddToDictionary(killsByDepts, dept.Key, kills);
            }
            return killsByDepts;
        }

        public static void AddToDictionary(Dictionary<Departments, int> killsByDepts, Departments department, int kills)
        {
            if(killsByDepts.ContainsKey(department))
            {
                killsByDepts[department] = kills;
            }
            else
            {
                killsByDepts.Add(department, kills);
            }
        }
            
    }

    public class Employees
    {
        public string? Name { get; set; }
        public int Age { get; set; }
        public int OrcKills { get; set; }
        public Departments Dept { get; set; }
    }

    public enum Departments
    {
        Archmage,
        Elemental,
        Wizard,
        Abyss,
        Bard,
        Archer,
        BraveFool
    }
}
