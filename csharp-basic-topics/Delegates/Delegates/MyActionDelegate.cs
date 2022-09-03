public class MyActionDelegate
{

    private void ApplyRegularBonus(Employee employee)
    {
        employee.Bonus = employee.Salary + 20;
    }

    private void ApplyContractBasedBonus(Employee employee)
    {
        employee.Bonus = employee.Salary + 10;
    }
    public void PerformAction(Employee employee)
    {
        Action<Employee> applyBonus;
        switch (employee.Type)
        {
            case EmployeeType.Regular:
                applyBonus = new Action<Employee>(ApplyRegularBonus);
                break;
            default:
                applyBonus = new Action<Employee>(ApplyContractBasedBonus);
                break;
        }
        applyBonus(employee);
    }

}

public class Employee
{
    public string Name { get; set; }
    public decimal Salary { get; set; }
    public decimal Bonus { get; set; }
    public EmployeeType Type { get; set; }
}

public enum EmployeeType { Regular , ContractBased }