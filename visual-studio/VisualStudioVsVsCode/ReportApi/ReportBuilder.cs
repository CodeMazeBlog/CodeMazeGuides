using System.Text;

namespace ReportApi;

public static class ReportBuilder
{
    public static string BuildWithConcatenation(int orders)
    {
        var report = "";
        for (var i = 1; i <= orders; i++)
        {
            report += $"Order {i}: {i % 7 + 1} items{Environment.NewLine}";
        }

        return report;
    }

    public static string BuildWithStringBuilder(int orders)
    {
        var report = new StringBuilder();
        for (var i = 1; i <= orders; i++)
        {
            report.AppendLine($"Order {i}: {i % 7 + 1} items");
        }

        return report.ToString();
    }
}
