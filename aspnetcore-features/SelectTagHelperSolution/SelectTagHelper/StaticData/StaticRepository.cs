using Microsoft.AspNetCore.Mvc.Rendering;
using SelectTagHelper.Models;

namespace SelectTagHelper.StaticData
{
    public class StaticRepository
    {
        public static List<SelectListItem> GetGenders() =>
        [
            new() { Text = "Male", Value = "Male" },
            new() { Text = "Female", Value = "Female" },
            new() { Text = "Others", Value = "Others" }
        ];

        public static List<SelectListItem> GetGendersWithPlaceholder() =>
        [
            new() { Text = "Please select a gender", Value = "", Disabled = true, Selected = true },
            .. GetGenders()
        ];

        public static List<EmployeeViewModel> GetEmployees() =>
        [
            new() { Id = 101, EmployeeName = "Mark" },
            new() { Id = 102, EmployeeName = "Dave" },
            new() { Id = 103, EmployeeName = "Rosy" }
        ];

        public static List<string> GetCountries() =>
        [
            "India", "USA", "UK", "France", "Germany"
        ];

        public static List<SelectListItem> GetCourses(SelectListGroup science, SelectListGroup humanities) =>
        [
            new() { Text = "Physics", Value = "PH101", Group = science },
            new() { Text = "Chemistry", Value = "CH101", Group = science },
            new() { Text = "Mathematics", Value = "MT101", Group = science },
            new() { Text = "English", Value = "EN101", Group = humanities },
            new() { Text = "Environmental Studies", Value = "EN101", Group = humanities },
            new() { Text = "Economics", Value = "EC101", Group = humanities }
        ];
    }
}
