namespace ObjectInitializersInCSharp
{
    public class LogisticsPartner
    {
        public int Id { get; }
        public string Name { get; }

        public LogisticsPartner(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
