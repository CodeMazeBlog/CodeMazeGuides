namespace ExpressionBodiedMembersInCsharp
{
    public class Employee
    {
        private string _name;

        public string Name
        {
            get => _name;
            set => _name = value;
        }

        public Employee(string name) => _name = name;

        ~Employee() => Console.WriteLine("Employee object has been finalized");
    }
}