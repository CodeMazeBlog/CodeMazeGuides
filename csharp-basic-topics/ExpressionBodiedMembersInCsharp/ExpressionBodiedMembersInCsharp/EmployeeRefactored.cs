namespace ExpressionBodiedMembersInCsharp
{
    public class EmployeeRefactored
    {
        private string _position;
        private string _employer;

        public EmployeeRefactored(string position, string employer)
        {
            _position = position;
            _employer = employer;
        }

        public string Position => _employer != null ? $"{_position} at {_employer}" : "Unemployed";
    }
}