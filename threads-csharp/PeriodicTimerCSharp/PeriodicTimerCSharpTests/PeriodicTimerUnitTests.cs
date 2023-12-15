namespace PeriodicTimerCSharpTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void GivenAnArrayWithSpecificElements_ThenValidateItsCreation()
        {
            var array = PeriodicTimerMethods.CreateRandomArray(20);

            Assert.IsNotNull(array);
            Assert.IsInstanceOfType(array, typeof(int[]));
            Assert.AreEqual(20, array.Length);
        }

        [TestMethod]
        public void GivenATimerInstance_ThenValidateItsProperties()
        {
            var timer = PeriodicTimerMethods.RandomArrayTimerAsync();

            Assert.IsNotNull(timer);
            Assert.IsInstanceOfType(timer, typeof(Task<PeriodicTimer>));
            Assert.IsFalse(timer.IsCanceled);
        }
    }
}