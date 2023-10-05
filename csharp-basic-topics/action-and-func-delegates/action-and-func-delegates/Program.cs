delegate void ActionTaskManager(string task);
delegate int FuncTaskManager();

internal class Program
{
    private static void Main(string[] args)
    {
        List<string> tasks = new List<string>();

        TaskManager taskManager = new TaskManager(tasks);

        // Action Delegate
        // Using custom defined delegate
        ActionTaskManager customActionToAddTask = taskManager.AddTask;
        customActionToAddTask("Create template");  // Added task: Create template

        // Instantiating the Action delegate
        Action<string> addTask = taskManager.AddTask;
        addTask("Call John");  // Added task: Call John

        // Func Delegate
        // Using custom defined delegate
        FuncTaskManager getCount = taskManager.GetTaskCount;
        Console.WriteLine($"Task Count: {getCount()}"); // Task Count: 2

        Func<string, bool> taskExist = taskManager.TaskExists;
        Console.WriteLine($"Task Count: {taskExist("Create template")}"); // Task Count: True
    }
}