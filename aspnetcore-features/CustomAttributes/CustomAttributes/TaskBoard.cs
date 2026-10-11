namespace CustomAttributes;

public class TaskBoard
{
    [Reviewed]
    public virtual int OpenTasks { get; set; }

    [Reviewed]
    public virtual void Archive()
    {
    }
}
