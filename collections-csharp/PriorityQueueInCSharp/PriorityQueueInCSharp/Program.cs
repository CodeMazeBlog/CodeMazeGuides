using PriorityQueueInCSharp;

static void ExploreEqualPriorities()
{
    var hospitalQueue = new PriorityQueue<Patient, int>(5); 
    hospitalQueue.Enqueue(new("Sarah", 23), 1); 
    hospitalQueue.Enqueue(new("Joe", 50), 1); 
    hospitalQueue.Enqueue(new("Elizabeth", 60), 1); 
    hospitalQueue.Enqueue(new("Natalie", 16), 1); 
    hospitalQueue.Enqueue(new("Angie", 25), 1); 
    while (hospitalQueue.Count > 0) 
        Console.WriteLine(hospitalQueue.Dequeue().Name);
}

static void ExploreSortingMechanism()
{
    var patients = new List<Patient>()
    {
        new("Sarah", 23),
        new("Joe", 50),
        new("Elizabeth", 60),
        new("Natalie", 16),
        new("Angie", 25),
    };
    var hospitalQueue = new PriorityQueue<Patient, Patient>(new HospitalQueueComparer());
    patients.ForEach(p => {
        Console.WriteLine($"Enqueueing {p.Name}");
        hospitalQueue.Enqueue(p, p);
    });

    Console.WriteLine("Dequeuing");

    while (hospitalQueue.Count > 0)
        Console.WriteLine($"Dequeuing {hospitalQueue.Dequeue().Name}");
}