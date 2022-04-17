using PriorityQueueInCSharp;

var vaccinationList = new List<Person>()
    {
        new("Sarah", 23),
        new("Joe", 50),
        new("Elizabeth", 60),
        new("Natalie", 16),
        new("Angie", 25),
    };
var vaccinationQueue = new PriorityQueue<Person, Person>(new VaccinationQueueComparer());
vaccinationList.ForEach(p => {
    vaccinationQueue.Enqueue(p, p);
});

Console.WriteLine("Dequeuing");

while (vaccinationQueue.Count > 0)
    Console.WriteLine($"Dequeuing {vaccinationQueue.Dequeue().Name}");
