namespace SmartEnum
{
public class Developer
{
    public Developer(string name, DeveloperLevel level)
    {
        Name = name;
        Level = level;
    }

    public string Name { get; }
    public DeveloperLevel Level { get; }

    public double WriteCode(int linesOfCode)
    {
        return linesOfCode / Level.Productivity;
    }
}
}
