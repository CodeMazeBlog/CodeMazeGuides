using Microsoft.AspNetCore.Mvc.Rendering;

namespace SelectTagHelper.Models
{
    public class SelectViewModel
    {
        public List<SelectListItem> Genders { get; set; }
        public string SelectedGender { get; set; }
        public List<EmployeeViewModel> Employees { get; set; }
        public int? SelectedEmployeeId { get; set; }
        public SelectList Countries { get; set; }
        public string SelectedCountry { get; set; }
        public Department Department { get; set; }
        public int? SelectedDepartment { get; set; }
    }

    public class EmployeeViewModel
    {
        public int Id { get; set; }
        public string EmployeeName { get; set; }
    }

    public enum Department
    {
        IT,
        HR,
        Finance,
        Admin
    }
}