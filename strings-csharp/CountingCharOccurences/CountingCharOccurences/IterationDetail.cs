namespace CountingCharOccurences
{
    public class IterationDetail
    {
        public IterationDetail(string name, long time)
        {
            Name = name;
            Time = time;
        }

        public string Name { get; }
        public long Time { get; }
    }
}
