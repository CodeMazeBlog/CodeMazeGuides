using System.Collections.Concurrent;

namespace ConcurrentQueueInCSharpTests
{
    public class ConcurrentQueueMemberTests
    {
        [Test]
        public void WhenEnqueueingItems_ThenTheyComeBackInOrder()
        {
            ConcurrentQueue<int> queue = new();

            queue.Enqueue(1);
            queue.Enqueue(2);

            Assert.That(queue.TryDequeue(out var first), Is.True);
            Assert.That(first, Is.EqualTo(1));
            Assert.That(queue.TryDequeue(out var second), Is.True);
            Assert.That(second, Is.EqualTo(2));
        }

        [Test]
        public void WhenSeedingFromEnumerable_ThenItemsKeepTheirOrder()
        {
            ConcurrentQueue<int> queue = new([1, 2, 3]);

            Assert.That(queue.ToArray(), Is.EqualTo(new[] { 1, 2, 3 }));
        }

        [Test]
        public void WhenDequeueingFromEmptyQueue_ThenItReturnsFalseInsteadOfThrowing()
        {
            ConcurrentQueue<int> queue = new();

            Assert.That(queue.TryDequeue(out var item), Is.False);
            Assert.That(item, Is.EqualTo(0));
        }

        [Test]
        public void WhenPeeking_ThenTheItemStaysInTheQueue()
        {
            ConcurrentQueue<int> queue = new();
            queue.Enqueue(42);

            Assert.That(queue.TryPeek(out var peeked), Is.True);
            Assert.That(peeked, Is.EqualTo(42));
            Assert.That(queue.Count, Is.EqualTo(1));
        }

        [Test]
        public void WhenPeekingAnEmptyQueue_ThenItReturnsFalseInsteadOfThrowing()
        {
            ConcurrentQueue<int> queue = new();

            Assert.That(queue.TryPeek(out _), Is.False);
        }

        [Test]
        public void WhenQueueHoldsNoItems_ThenIsEmptyIsTrue()
        {
            ConcurrentQueue<int> queue = new();

            Assert.That(queue.IsEmpty, Is.True);

            queue.Enqueue(1);

            Assert.That(queue.IsEmpty, Is.False);
        }

        [Test]
        public void WhenClearing_ThenTheQueueIsEmpty()
        {
            ConcurrentQueue<int> queue = new([1, 2, 3]);

            queue.Clear();

            Assert.That(queue.IsEmpty, Is.True);
            Assert.That(queue.Count, Is.EqualTo(0));
        }

        [Test]
        public void WhenCopyingTo_ThenTheTargetArrayHoldsASnapshot()
        {
            ConcurrentQueue<int> queue = new([1, 2, 3]);
            var target = new int[3];

            queue.CopyTo(target, 0);
            queue.Enqueue(4);

            Assert.That(target, Is.EqualTo(new[] { 1, 2, 3 }));
        }

        [Test]
        public void WhenEnumerating_ThenLaterEnqueuesAreInvisibleToTheLoop()
        {
            ConcurrentQueue<int> queue = new([1, 2]);
            var seen = new List<int>();

            var enumerator = queue.GetEnumerator();
            queue.Enqueue(3);

            while (enumerator.MoveNext())
            {
                seen.Add(enumerator.Current);
            }

            Assert.That(seen, Is.EqualTo(new List<int> { 1, 2 }));
        }

        [Test]
        public void WhenLookingForContains_ThenTheTypeDoesNotDeclareIt()
        {
            var contains = typeof(ConcurrentQueue<int>).GetMethod("Contains");

            Assert.That(contains, Is.Null);
            Assert.That(new ConcurrentQueue<int>([1, 2, 3]).Any(item => item == 2), Is.True);
        }
    }
}
