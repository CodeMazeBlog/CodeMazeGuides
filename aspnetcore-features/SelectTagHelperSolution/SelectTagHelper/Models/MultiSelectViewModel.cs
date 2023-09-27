namespace SelectTagHelper.Models
{
    public class MultiSelectViewModel
    {
        public List<EmployeeViewModel> Employees { get; set; }
        public int[] SelectedEmployeeIds { get; set; }
    }
}