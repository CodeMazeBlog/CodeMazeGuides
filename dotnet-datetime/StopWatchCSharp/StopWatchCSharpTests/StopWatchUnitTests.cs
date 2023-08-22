using System.Diagnostics;

namespace StopWatchCSharpTests
{
    [TestClass]
    public class StopWatchUnitTests
    {
        private readonly int[] _numArray;
        private readonly StopWatchMethods _stopWatchMethods = new();

        public StopWatchUnitTests() 
        {
            _numArray = _stopWatchMethods.CreateRandomArray(20000);
        }

        [TestMethod]
        public void GivenBubbleSortAlgorithm_WhenInvoked_VerifyStopwatchSuccess()
        {
            var stopWatch = _stopWatchMethods.BubbleSort(_numArray, _numArray.Length);

            Assert.IsInstanceOfType(stopWatch, typeof(Stopwatch));
            Assert.IsInstanceOfType(stopWatch.Elapsed, typeof(TimeSpan));
            Assert.IsFalse(stopWatch.IsRunning);

            stopWatch.Reset();

            Assert.AreEqual(stopWatch.Elapsed, TimeSpan.Zero);
        }

        [TestMethod]
        public void GivenHeapSortAlgorithm_WhenInvoked_VerifyStopwatchSuccess()
        {
            var stopWatch = _stopWatchMethods.HeapSort(_numArray, _numArray.Length);
            
            Assert.IsInstanceOfType(stopWatch, typeof(Stopwatch));
            Assert.IsInstanceOfType(stopWatch.Elapsed, typeof(TimeSpan));
            Assert.IsFalse(stopWatch.IsRunning);

            stopWatch.Restart();

            Assert.AreEqual(stopWatch.Elapsed.CompareTo(TimeSpan.Zero), 1);
            Assert.IsTrue(stopWatch.IsRunning);

            stopWatch.Stop();

            Assert.IsFalse(stopWatch.IsRunning);
        }

        [TestMethod]
        public void GivenTwoSortingAlgorithm_WhenInvoked_VerifyStopwatchSuccess()
        {
            var heapSort = _stopWatchMethods.HeapSort(_numArray, _numArray.Length);
            var bubbleSort = _stopWatchMethods.BubbleSort(_numArray, _numArray.Length);

            Assert.IsFalse(heapSort.Equals(bubbleSort));
            Assert.IsInstanceOfType(heapSort.ElapsedMilliseconds, typeof(long));
            Assert.IsInstanceOfType(bubbleSort.ElapsedTicks, typeof(long));
            Assert.AreEqual(heapSort.Elapsed.CompareTo(bubbleSort.Elapsed), -1);
        }

        [TestMethod]
        public void GivenArraySize_WhenCreateRandomArrayInvoked_VerifyReturnedResults()
        {
            var arraySize = 10;
            var arrayResult = _stopWatchMethods.CreateRandomArray(arraySize);

            Assert.IsInstanceOfType(arrayResult, typeof(int[]));
            Assert.IsNotNull(arrayResult);
            Assert.AreEqual(arrayResult.Length, arraySize);
        }
    }
}