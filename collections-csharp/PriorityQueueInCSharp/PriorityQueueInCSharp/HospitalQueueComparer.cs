namespace PriorityQueueInCSharp;

public class HospitalQueueComparer : IComparer<Patient>
{
    public int Compare(Patient? x, Patient? y)
    {
        ArgumentNullException.ThrowIfNull(x);
        ArgumentNullException.ThrowIfNull(y);

        Console.WriteLine($"Comparing {x.Name} and {y.Name}");
        Console.WriteLine();

        if (x.Age == y.Age)
            return 0;
        else if (x.Age > y.Age)
            return -1;
        else
            return 1;
    }
}
