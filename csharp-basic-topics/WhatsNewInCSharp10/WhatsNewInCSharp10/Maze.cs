namespace WhatsNewInCSharp10;

public struct Maze
{
    // Parameterless constructor with property initialization 
    public Maze()
    {
        Size = 10; 
    }

    // Initialization of the property at its declaration
    public int Size { get; set; } = 10;
}
