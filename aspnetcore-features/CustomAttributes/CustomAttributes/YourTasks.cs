namespace CustomAttributes;

public class YourTasks : MyTasks
{
    [DeveloperTask(Priorities.Mid, Description = "Mid level description")]
    public override void ScheduleInterview()
    {
    }
}
