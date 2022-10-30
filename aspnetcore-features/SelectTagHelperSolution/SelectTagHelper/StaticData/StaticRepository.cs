using Microsoft.AspNetCore.Mvc.Rendering;
using SelectTagHelper.Models;

namespace SelectTagHelper.StaticData
{
    public class StaticRepository
    {
        public static List<SelectListItem> GetGenders()
        {
            return new List<SelectListItem>
            {
                new SelectListItem
                {
                    Text = "Male",
                    Value = "Male"
                },
                new SelectListItem
                {
                    Text = "Female",
                    Value = "Female"
                },
                new SelectListItem
                {
                    Text = "Others",
                    Value = "Others"
                }
            };
        }

        public static List<EmployeeViewModel> GetEmployees()
        {
            return new List<EmployeeViewModel>
            {
                new EmployeeViewModel
                {
                    Id = 101,
                    EmployeeName = "Mark"
                },
                new EmployeeViewModel
                {
                    Id = 102,
                    EmployeeName = "Dave"
                },
                new EmployeeViewModel
                {
                    Id = 103,
                    EmployeeName = "Rosy"
                }
            };
        }

        public static List<string> GetCountries()
        {
            return new List<string>
            {
                "India","USA","UK","France","Germany"
            };
        }

        public static List<SelectListItem> GetCourses(SelectListGroup science, SelectListGroup humanities)
        {
            return new List<SelectListItem>
            {
                new SelectListItem
                {
                    Text  = "Physics",
                    Value = "PH101",
                    Group = science
                },
                new SelectListItem
                {
                    Text = "Chemistry",
                    Value = "CH101",
                    Group = science
                },
                new SelectListItem
                {
                    Text = "Mathematics",
                    Value = "MT101",
                    Group = science
                },
                new SelectListItem
                {
                    Text = "English",
                    Value = "EN101",
                    Group = humanities
                },
                new SelectListItem
                {
                    Text = "Environmental Studies",
                    Value = "EN101",
                    Group = humanities
                },
                new SelectListItem
                {
                    Text = "Economics",
                    Value = "EC101",
                    Group = humanities
                }
            };
        }
    }
}