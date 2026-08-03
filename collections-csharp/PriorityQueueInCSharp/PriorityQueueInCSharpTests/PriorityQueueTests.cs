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
            var hospitalQueue = new PriorityQueue<Patient, int>();
            Assert.AreEqual(0, hospitalQueue.EnsureCapacity(0));
        }

        [TestMethod]
        public void WhenUsingCapactiyConstructor_ThenPriorityQueueCapactityIsInitialized()
        {
            var hospitalQueue = new PriorityQueue<Patient, int>(5);
            Assert.AreEqual(5, hospitalQueue.EnsureCapacity(0));
            Assert.AreEqual(0, hospitalQueue.Count);
        }

        [TestMethod]
        public void WhenUsingCollectionConstructor_ThenPriorityQueueCapactityIsInitialized()
        {
            var patients = new List<(Patient, int)>()
            {
                (new("Sarah", 23), 4),
                (new("Joe", 50), 2),
                (new("Elizabeth", 60), 1),
                (new("Natalie", 16), 5),
                (new("Angie", 25), 3)
            };
            var hospitalQueue = new PriorityQueue<Patient, int>(patients);
            Assert.AreEqual(5, hospitalQueue.EnsureCapacity(0));
            Assert.AreEqual(5, hospitalQueue.Count);
        }

        [TestMethod]
        public void WhenClearingThePriorityQueue_ThenElementsAreCleared()
        {
            var patients = new List<(Patient, int)>()
            {
                (new("Sarah", 23), 4),
                (new("Joe", 50), 2),
                (new("Elizabeth", 60), 1),
                (new("Natalie", 16), 5),
                (new("Angie", 25), 3)
            };
            var hospitalQueue = new PriorityQueue<Patient, int>(patients);

            hospitalQueue.Clear();

            Assert.AreEqual(5, hospitalQueue.EnsureCapacity(0));
            Assert.AreEqual(0, hospitalQueue.Count);
        }

        [TestMethod]
        public void WhenAddingAnElementToAFullQueue_ThenCapactityIsIncreased()
        {
            var patients = new List<(Patient, int)>()
            {
                (new("Sarah", 23), 4),
                (new("Joe", 50), 2),
                (new("Elizabeth", 60), 1),
                (new("Natalie", 16), 5),
                (new("Angie", 25), 3)
            };
            var hospitalQueue = new PriorityQueue<Patient, int>(patients);
            Assert.AreEqual(5, hospitalQueue.EnsureCapacity(0));
            Assert.AreEqual(5, hospitalQueue.Count);

            hospitalQueue.Enqueue(new Patient("Roy", 23), 5);
            Assert.AreEqual(10, hospitalQueue.EnsureCapacity(0));

            Assert.AreEqual(20, hospitalQueue.EnsureCapacity(12));

            Assert.AreEqual(42, hospitalQueue.EnsureCapacity(42));

            hospitalQueue.TrimExcess();
            Assert.AreEqual(6, hospitalQueue.EnsureCapacity(0));
        }

        [TestMethod]
        public void WhenAddingAnElementToAFullQueue_ThenCapactityIsIncreasedByFourAtLeast()
        {
            var patients = new List<(Patient, int)>()
            {
                (new("Sarah", 23), 4)
            };
            var hospitalQueue = new PriorityQueue<Patient, int>(patients);
            
            hospitalQueue.Enqueue(new Patient("Roy", 23), 5);

            Assert.AreEqual(5, hospitalQueue.EnsureCapacity(0));
        }

        [TestMethod]
        public void WhenCallinfTrimExcess_ThenUnnecessaryMemoryIsReleased()
        {
            var patients = new List<(Patient, int)>()
            {
                (new("Sarah", 23), 4),
                (new("Joe", 50), 2),
                (new("Elizabeth", 60), 1),
                (new("Natalie", 16), 5),
                (new("Angie", 25), 3)
            };
            var hospitalQueue = new PriorityQueue<Patient, int>(patients);
            Assert.AreEqual(12, hospitalQueue.EnsureCapacity(12));
            
            hospitalQueue.TrimExcess();
            Assert.AreEqual(5, hospitalQueue.EnsureCapacity(0));

        }

        [TestMethod]
        public void WhenDequeueingAnElement_ThenElementWithLowestPriorityReturns()
        {
            var patients = new List<(Patient, int)>()
            {
                (new("Sarah", 23), 4),
                (new("Joe", 50), 2),
                (new("Elizabeth", 60), 1),
                (new("Natalie", 16), 5),
                (new("Angie", 25), 3)
            };
            var hospitalQueue = new PriorityQueue<Patient, int>(patients);
            
            var highestPriorityPatient = hospitalQueue.Dequeue();
            Assert.AreEqual(highestPriorityPatient.Age, 60);
            Assert.AreEqual(highestPriorityPatient.Name, "Elizabeth");

            var secondHighestPriorityPerson = hospitalQueue.Peek();
            Assert.AreEqual(secondHighestPriorityPerson.Age, 50);
            Assert.AreEqual(secondHighestPriorityPerson.Name, "Joe");

            hospitalQueue.Enqueue(new("Roy", 23), 1);
            var currentHighestPriorityPatient = hospitalQueue.Peek();
            Assert.AreEqual(currentHighestPriorityPatient.Age, 23);
            Assert.AreEqual(currentHighestPriorityPatient.Name, "Roy");
        }

        [TestMethod]
        public void WhenEnqueueingAnElementToComparerPriorityQueue_ThenElementIsEnqueued()
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
            patients.ForEach(p => hospitalQueue.Enqueue(p, p));

            var highestPriorityPatient = hospitalQueue.Dequeue();
            Assert.AreEqual(highestPriorityPatient.Age, 60);
            Assert.AreEqual(highestPriorityPatient.Name, "Elizabeth");

            var secondHighestPriorityPatient = hospitalQueue.Peek();
            Assert.AreEqual(secondHighestPriorityPatient.Age, 50);
            Assert.AreEqual(secondHighestPriorityPatient.Name, "Joe");
        }

        [TestMethod]
        public void WhenEnqueueingDequeueingAnElement_ThenElementIsEnqueuedAndAnotherIsDequeued()
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
            patients.ForEach(p => hospitalQueue.Enqueue(p, p));

            var patientToAdd = new Patient("Roy", 59);
            var highestPriorityPatient = hospitalQueue.EnqueueDequeue(patientToAdd, patientToAdd);

            Assert.AreEqual(highestPriorityPatient.Age, 60);
            Assert.AreEqual(highestPriorityPatient.Name, "Elizabeth");

            var secondHighestPriorityPatient = hospitalQueue.Peek();

            Assert.AreEqual(secondHighestPriorityPatient.Age, 59);
            Assert.AreEqual(secondHighestPriorityPatient.Name, "Roy");
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

            var elemetsFollowFIFO = hospitalQueue.Dequeue().Name == "Sarah" 
                && hospitalQueue.Dequeue().Name == "Joe"
                && hospitalQueue.Dequeue().Name == "Elizabeth"
                && hospitalQueue.Dequeue().Name == "Natalie"
                && hospitalQueue.Dequeue().Name == "Angie";

            Assert.IsFalse(elemetsFollowFIFO);
        }
    }
}