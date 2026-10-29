using PriorityQueueInCSharp;

namespace PriorityQueueInCSharpTests;

[TestClass]
public class PriorityQueueTests
{
    private static List<(Patient, int)> CreatePatients() =>
    [
        (new("Sarah", 23), 4),
        (new("Joe", 50), 2),
        (new("Elizabeth", 60), 1),
        (new("Natalie", 16), 5),
        (new("Angie", 25), 3)
    ];

    private static List<Patient> CreatePatientsWithoutPriorities() =>
    [
        new("Sarah", 23),
        new("Joe", 50),
        new("Elizabeth", 60),
        new("Natalie", 16),
        new("Angie", 25),
    ];

    [TestMethod]
    public void WhenUsingParameterlessConstructor_ThenPriorityQueueIsEmpty()
    {
        var hospitalQueue = new PriorityQueue<Patient, int>();
        Assert.AreEqual(0, hospitalQueue.Capacity);
    }

    [TestMethod]
    public void WhenUsingCapacityConstructor_ThenPriorityQueueCapacityIsInitialized()
    {
        var hospitalQueue = new PriorityQueue<Patient, int>(5);
        Assert.AreEqual(5, hospitalQueue.Capacity);
        Assert.AreEqual(0, hospitalQueue.Count);
    }

    [TestMethod]
    public void WhenUsingCollectionConstructor_ThenPriorityQueueCapacityIsInitialized()
    {
        var hospitalQueue = new PriorityQueue<Patient, int>(CreatePatients());
        Assert.AreEqual(5, hospitalQueue.Capacity);
        Assert.AreEqual(5, hospitalQueue.Count);
    }

    [TestMethod]
    public void WhenClearingThePriorityQueue_ThenElementsAreCleared()
    {
        var hospitalQueue = new PriorityQueue<Patient, int>(CreatePatients());

        hospitalQueue.Clear();

        Assert.AreEqual(5, hospitalQueue.Capacity);
        Assert.AreEqual(0, hospitalQueue.Count);
    }

    [TestMethod]
    public void WhenAddingAnElementToAFullQueue_ThenCapacityIsIncreased()
    {
        var hospitalQueue = new PriorityQueue<Patient, int>(CreatePatients());
        Assert.AreEqual(5, hospitalQueue.Capacity);
        Assert.AreEqual(5, hospitalQueue.Count);

        hospitalQueue.Enqueue(new Patient("Roy", 23), 5);
        Assert.AreEqual(10, hospitalQueue.Capacity);

        Assert.AreEqual(20, hospitalQueue.EnsureCapacity(12));

        Assert.AreEqual(42, hospitalQueue.EnsureCapacity(42));

        hospitalQueue.TrimExcess();
        Assert.AreEqual(6, hospitalQueue.Capacity);
    }

    [TestMethod]
    public void WhenAddingAnElementToAFullQueue_ThenCapacityIsIncreasedByFourAtLeast()
    {
        var hospitalQueue = new PriorityQueue<Patient, int>([(new Patient("Sarah", 23), 4)]);

        hospitalQueue.Enqueue(new Patient("Roy", 23), 5);

        Assert.AreEqual(5, hospitalQueue.Capacity);
    }

    [TestMethod]
    public void WhenCallingTrimExcess_ThenUnnecessaryMemoryIsReleased()
    {
        var hospitalQueue = new PriorityQueue<Patient, int>(CreatePatients());
        Assert.AreEqual(12, hospitalQueue.EnsureCapacity(12));

        hospitalQueue.TrimExcess();
        Assert.AreEqual(5, hospitalQueue.Capacity);
    }

    [TestMethod]
    public void WhenDequeueingAnElement_ThenElementWithLowestPriorityReturns()
    {
        var hospitalQueue = new PriorityQueue<Patient, int>(CreatePatients());

        var highestPriorityPatient = hospitalQueue.Dequeue();
        Assert.AreEqual(60, highestPriorityPatient.Age);
        Assert.AreEqual("Elizabeth", highestPriorityPatient.Name);

        var secondHighestPriorityPatient = hospitalQueue.Peek();
        Assert.AreEqual(50, secondHighestPriorityPatient.Age);
        Assert.AreEqual("Joe", secondHighestPriorityPatient.Name);

        hospitalQueue.Enqueue(new("Roy", 23), 1);
        var currentHighestPriorityPatient = hospitalQueue.Peek();
        Assert.AreEqual(23, currentHighestPriorityPatient.Age);
        Assert.AreEqual("Roy", currentHighestPriorityPatient.Name);
    }

    [TestMethod]
    public void WhenEnqueueingAnElementToComparerPriorityQueue_ThenElementIsEnqueued()
    {
        var hospitalQueue = new PriorityQueue<Patient, Patient>(new HospitalQueueComparer());
        CreatePatientsWithoutPriorities().ForEach(p => hospitalQueue.Enqueue(p, p));

        var highestPriorityPatient = hospitalQueue.Dequeue();
        Assert.AreEqual(60, highestPriorityPatient.Age);
        Assert.AreEqual("Elizabeth", highestPriorityPatient.Name);

        var secondHighestPriorityPatient = hospitalQueue.Peek();
        Assert.AreEqual(50, secondHighestPriorityPatient.Age);
        Assert.AreEqual("Joe", secondHighestPriorityPatient.Name);
    }

    [TestMethod]
    public void WhenEnqueueingDequeueingAnElement_ThenElementIsEnqueuedAndAnotherIsDequeued()
    {
        var hospitalQueue = new PriorityQueue<Patient, Patient>(new HospitalQueueComparer());
        CreatePatientsWithoutPriorities().ForEach(p => hospitalQueue.Enqueue(p, p));

        var patientToAdd = new Patient("Roy", 59);
        var highestPriorityPatient = hospitalQueue.EnqueueDequeue(patientToAdd, patientToAdd);

        Assert.AreEqual(60, highestPriorityPatient.Age);
        Assert.AreEqual("Elizabeth", highestPriorityPatient.Name);

        var secondHighestPriorityPatient = hospitalQueue.Peek();

        Assert.AreEqual(59, secondHighestPriorityPatient.Age);
        Assert.AreEqual("Roy", secondHighestPriorityPatient.Name);
    }

    [TestMethod]
    public void WhenNewElementOutranksTheRoot_ThenEnqueueDequeueReturnsItAndDequeueEnqueueKeepsIt()
    {
        var patientToAdd = new Patient("Roy", 80);

        var firstQueue = new PriorityQueue<Patient, int>(CreatePatients());
        var returnedByEnqueueDequeue = firstQueue.EnqueueDequeue(patientToAdd, 0);
        Assert.AreEqual("Roy", returnedByEnqueueDequeue.Name);
        Assert.AreEqual("Elizabeth", firstQueue.Peek().Name);

        var secondQueue = new PriorityQueue<Patient, int>(CreatePatients());
        var returnedByDequeueEnqueue = secondQueue.DequeueEnqueue(patientToAdd, 0);
        Assert.AreEqual("Elizabeth", returnedByDequeueEnqueue.Name);
        Assert.AreEqual("Roy", secondQueue.Peek().Name);
    }

    [TestMethod]
    public void WhenRemovingAnElement_ThenItIsGoneAndCanBeEnqueuedWithANewPriority()
    {
        var patients = new List<(Patient, int)>()
        {
            (new("Sarah", 23), 4),
            (new("Joe", 50), 2),
            (new("Elizabeth", 60), 1),
            (new("Natalie", 16), 5),
            (new("Angie", 25), 3)
        };
        var joe = patients[1].Item1;
        var hospitalQueue = new PriorityQueue<Patient, int>(patients);

        var removed = hospitalQueue.Remove(joe, out var removedPatient, out var oldPriority);

        Assert.IsTrue(removed);
        Assert.AreEqual("Joe", removedPatient?.Name);
        Assert.AreEqual(2, oldPriority);
        Assert.AreEqual(4, hospitalQueue.Count);

        hospitalQueue.Enqueue(joe, 0);
        Assert.AreEqual("Joe", hospitalQueue.Peek().Name);
    }

    [TestMethod]
    public void WhenEnumeratingUnorderedItems_ThenOrderIsHeapOrderNotPriorityOrder()
    {
        var hospitalQueue = new PriorityQueue<Patient, int>(CreatePatients());

        var names = hospitalQueue.UnorderedItems.Select(item => item.Element.Name).ToArray();

        CollectionAssert.AreEqual(new[] { "Elizabeth", "Joe", "Sarah", "Natalie", "Angie" }, names);
    }

    [TestMethod]
    public void WhenEnqueuingElementsWithSamePriorities_ThenTheyDoNotFollowFIFO()
    {
        var hospitalQueue = new PriorityQueue<Patient, int>(5);
        hospitalQueue.Enqueue(new("Sarah", 23), 1);
        hospitalQueue.Enqueue(new("Joe", 50), 1);
        hospitalQueue.Enqueue(new("Elizabeth", 60), 1);
        hospitalQueue.Enqueue(new("Natalie", 16), 1);
        hospitalQueue.Enqueue(new("Angie", 25), 1);

        var elementsFollowFIFO = hospitalQueue.Dequeue().Name == "Sarah"
            && hospitalQueue.Dequeue().Name == "Joe"
            && hospitalQueue.Dequeue().Name == "Elizabeth"
            && hospitalQueue.Dequeue().Name == "Natalie"
            && hospitalQueue.Dequeue().Name == "Angie";

        Assert.IsFalse(elementsFollowFIFO);
    }

    [TestMethod]
    public void WhenUsingSynchronizedQueue_ThenItDequeuesByPriority()
    {
        var hospitalQueue = new SynchronizedHospitalQueue();
        hospitalQueue.Enqueue(new("Sarah", 23), 4);
        hospitalQueue.Enqueue(new("Elizabeth", 60), 1);

        Assert.IsTrue(hospitalQueue.TryDequeue(out var patient));
        Assert.AreEqual("Elizabeth", patient?.Name);
    }

    [TestMethod]
    public void WhenUsingAReversedComparer_ThenHighestNumberIsDequeuedFirst()
    {
        var hospitalQueue = new PriorityQueue<Patient, int>(Comparer<int>.Create((x, y) => y.CompareTo(x)));
        hospitalQueue.Enqueue(new("Sarah", 23), 23);
        hospitalQueue.Enqueue(new("Elizabeth", 60), 60);
        hospitalQueue.Enqueue(new("Natalie", 16), 16);

        Assert.AreEqual("Elizabeth", hospitalQueue.Dequeue().Name);
    }
}
