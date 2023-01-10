namespace CodeMaze.Integration.Messages;

public class LineItem
{
    public int Quantity { get; set; }

    public int Price { get; set; }

    public Guid ProductId { get; set; }
}
