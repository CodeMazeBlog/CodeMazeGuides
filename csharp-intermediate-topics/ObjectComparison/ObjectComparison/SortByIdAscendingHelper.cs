namespace ObjectComparisons
{
    public class SortByIdAscendingHelper : IComparer<Employee>
    {
        public int Compare(Employee? firstEmployee, Employee? secondEmployee)
        {
            return ((firstEmployee is null) || (secondEmployee is null)) ?
                0 :
                firstEmployee.Id.CompareTo(secondEmployee.Id);
        }
    }
}
