namespace ObjectComparisons
{
    public class SortByIdDescendingHelper : IComparer<Employee>
    {
        public int Compare(Employee? firstEmployee, Employee? secondEmployee)
        {
            return ((firstEmployee is null) || (secondEmployee is null)) ?
                0 :
                secondEmployee.Id.CompareTo(firstEmployee.Id);
        }
    }
}
