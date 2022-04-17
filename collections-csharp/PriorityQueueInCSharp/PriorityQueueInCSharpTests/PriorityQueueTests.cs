using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using PriorityQueueInCSharp;
using System;

namespace PriorityQueueInCSharpTests
{
    [TestClass]
    public class PriorityQueueTests
    {
        [TestMethod]
        public void WhenUsingParameterlessConstructor_ThenPriorityQueueIsEmpty()
        {
            var vaccinationQueue = new PriorityQueue<Person, int>();
            Assert.AreEqual(0, vaccinationQueue.EnsureCapacity(0));
        }

        [TestMethod]
        public void WhenUsingCapactiyConstructor_ThenPriorityQueueCapactityIsInitialized()
        {
            var vaccinationQueue = new PriorityQueue<Person, int>(5);
            Assert.AreEqual(5, vaccinationQueue.EnsureCapacity(0));
            Assert.AreEqual(0, vaccinationQueue.Count);
        }

        [TestMethod]
        public void WhenUsingCollectionConstructor_ThenPriorityQueueCapactityIsInitialized()
        {
            var vaccinationList = new List<(Person, int)>()
            {
                (new("Sarah", 23), 4),
                (new("Joe", 50), 2),
                (new("Elizabeth", 60), 1),
                (new("Natalie", 16), 5),
                (new("Angie", 25), 3)
            };
            var vaccinationQueue = new PriorityQueue<Person, int>(vaccinationList);
            Assert.AreEqual(5, vaccinationQueue.EnsureCapacity(0));
            Assert.AreEqual(5, vaccinationQueue.Count);
        }

        [TestMethod]
        public void WhenEnqueueingAnElement_ThenElementIsEnqueued()
        {
            var vaccinationList = new List<(Person, int)>()
            {
                (new("Sarah", 23), 4),
                (new("Joe", 50), 2),
                (new("Elizabeth", 60), 1),
                (new("Natalie", 16), 5),
                (new("Angie", 25), 3)
            };            
            var vaccinationQueue = new PriorityQueue<Person, int>(vaccinationList);
            vaccinationQueue.Enqueue(new("Roy", 23), 4);
            Assert.AreEqual(10, vaccinationQueue.EnsureCapacity(0));
            Assert.AreEqual(6, vaccinationQueue.Count);
        }

        [TestMethod]
        public void WhenDequeueingAnElement_ThenElementWithLowestPriorityReturns()
        {
            var vaccinationList = new List<(Person, int)>()
            {
                (new("Sarah", 23), 4),
                (new("Joe", 50), 2),
                (new("Elizabeth", 60), 1),
                (new("Natalie", 16), 5),
                (new("Angie", 25), 3)
            };
            var vaccinationQueue = new PriorityQueue<Person, int>(vaccinationList);
            var highestPriorityPerson = vaccinationQueue.Dequeue();
            Assert.AreEqual(highestPriorityPerson.Age, 60);
            Assert.AreEqual(highestPriorityPerson.Name, "Elizabeth");

            var secondHighestPriorityPerson = vaccinationQueue.Peek();
            Assert.AreEqual(secondHighestPriorityPerson.Age, 50);
            Assert.AreEqual(secondHighestPriorityPerson.Name, "Joe");

        }

        [TestMethod]
        public void WhenEnqueueingAnElementToComparerPriorityQueue_ThenElementIsEnqueued()
        {
            var vaccinationList = new List<Person>()
            {
                new("Sarah", 23),
                new("Joe", 50),
                new("Elizabeth", 60),
                new("Natalie", 16),
                new("Angie", 25),
            };
            var vaccinationQueue = new PriorityQueue<Person, Person>(new VaccinationQueueComparer());
            vaccinationList.ForEach(p => vaccinationQueue.Enqueue(p, p));
            
            var highestPriorityPerson = vaccinationQueue.Dequeue();
            Assert.AreEqual(highestPriorityPerson.Age, 60);
            Assert.AreEqual(highestPriorityPerson.Name, "Elizabeth");

            var secondHighestPriorityPerson = vaccinationQueue.Peek();
            Assert.AreEqual(secondHighestPriorityPerson.Age, 50);
            Assert.AreEqual(secondHighestPriorityPerson.Name, "Joe");
        }


    }
}