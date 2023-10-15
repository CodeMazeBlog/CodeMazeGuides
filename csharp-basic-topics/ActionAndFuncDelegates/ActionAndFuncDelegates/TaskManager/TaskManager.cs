namespace ActionAndFuncDelegate;

public class TaskManager
{
    private List<string> _tasks = new();

    public TaskManager(List<string> tasks) => _tasks = tasks;

    // Method implementations that return no values
    public void AddTask(string task)
    {
        _tasks.Add(task);
        Console.WriteLine($"Added task: {task}");
    }

    // Method implementations that return values
    public int GetTaskCount()
    {
        return _tasks.Count;
    }

    public bool TaskExists(string task)
    {
        return _tasks.Contains(task);
    }
}