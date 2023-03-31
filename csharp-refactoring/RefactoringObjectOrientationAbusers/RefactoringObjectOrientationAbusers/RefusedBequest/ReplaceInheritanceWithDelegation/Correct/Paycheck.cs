namespace RefactoringObjectOrientationAbusers.RefusedBequest.ReplaceInheritanceWithDelegation.Correct
{
    public class Paycheck
    {
        private readonly decimal _hourlyRate;
        private readonly int _hoursWorked;
        private readonly decimal _overtimeRate;

        public Paycheck(decimal hourlyRate, int hoursWorked)
        {
            _hourlyRate = hourlyRate;
            _hoursWorked = hoursWorked;
            _overtimeRate = 1.5M * hourlyRate;
        }

        public decimal CalculatePay()
        {
            return _hourlyRate * _hoursWorked;
        }

        public decimal GetOvertimeRate() 
        {
            return _overtimeRate;
        }
    }
}
