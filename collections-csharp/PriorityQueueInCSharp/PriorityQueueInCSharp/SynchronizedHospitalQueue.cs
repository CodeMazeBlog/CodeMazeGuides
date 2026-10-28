namespace PriorityQueueInCSharp;

public class SynchronizedHospitalQueue
{
    private readonly PriorityQueue<Patient, int> _queue = new();
    private readonly Lock _lock = new();

    public void Enqueue(Patient patient, int priority)
    {
        lock (_lock)
        {
            _queue.Enqueue(patient, priority);
        }
    }

    public bool TryDequeue(out Patient? patient)
    {
        lock (_lock)
        {
            return _queue.TryDequeue(out patient, out _);
        }
    }
}
