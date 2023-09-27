using System.Globalization;
using System.Text;
using MultipleTasksDemo.Client.Contracts;

namespace MultipleTasksDemo.Client;

public class EmployeeProfile
{
    public EmployeeDetails EmployeeDetails { get; }

    public decimal Salary { get; }

    public int Rating { get; }

    public EmployeeProfile(EmployeeDetails employeeDetails, decimal salary, int rating)
    {
        EmployeeDetails = employeeDetails;
        Salary = salary;
        Rating = rating;
    }

    public override string ToString()
    {
        var sb = new StringBuilder();
        sb.AppendLine($"Name: {EmployeeDetails.Name}");
        sb.AppendLine($"DOB: {EmployeeDetails.DateOfBirth.ToShortDateString()}");
        sb.AppendLine($"Address: {EmployeeDetails.Address}");
        sb.AppendLine($"Salary: {Salary}{HexToChar("20AC")}");
        sb.AppendLine($"Appraisal Rating: {Rating}");

        return sb.ToString();

        char HexToChar(string hex)
            => (char)ushort.Parse(hex, NumberStyles.HexNumber);
    }
}