namespace action_and_func_delegates.Tests;

public class TaskManagerUnitTest
{
    [Fact]
    public void GivenAddTaskToList_WhenTaskExist_ThenTaskManagerFunctionalityPass()
    {
        List<string> tasks = new List<string>();
        TaskManager taskManager = new TaskManager(tasks);
        string task = "Task A";

        taskManager.AddTask(task);
        int count = taskManager.GetTaskCount();
        bool exist = taskManager.TaskExists(task);

        int expectedCount = 1;
        bool expectValue = true;

        Assert.Equal(count, expectedCount);
        Assert.Equal(exist, expectValue);
    }
}