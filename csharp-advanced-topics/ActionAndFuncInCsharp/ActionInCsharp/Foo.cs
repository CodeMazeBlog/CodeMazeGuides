namespace ActionInCsharp;

public class Foo
{
    public Status Status { get; private set; } = Status.Unknown;

    public void SetStatus(Status status, Action<Status> onStatusChanged)
    {
        if (this.Status != status)
        {
            this.Status = status;

            onStatusChanged(status);
        }

        this.Status = status;
    }
}
