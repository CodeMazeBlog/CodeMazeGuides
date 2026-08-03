namespace IndexersInCSharp
{
    public interface IIndexerInterface
    { 
        string this[int index] { get; }

        string this [string name] 
        {
            get => "Hello from interface.";
        }
    }

    public class IndexerClass : IIndexerInterface
    {
        public string this[int index] 
        { 
            get => "Hello from class."; 
        }
    }
}
