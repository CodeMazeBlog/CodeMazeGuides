namespace DefaultValuesForLambdaExpressions.Models;

public class TodoItem
{
    public TodoItem() { }

    public int Id { get; set; }
    public string? Title { get; set;  }
    public string? Description { get; set; }
    public string? Tags { get; set; }
}
