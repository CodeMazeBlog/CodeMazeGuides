using EnumerateAnEnumInCSharp;

namespace Tests
{
    [TestClass]
    public class EnumerateAnEnumInCSharpUnitTests
    {
        [TestMethod]
        public void GivenDaysOfWeek_ThenArrayOfValuesIsReturned()
        {
            var result = EnumHelper.GetValues(typeof(DayOfWeek));

            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(Array));
            TestAllDaysInResult(result);
        }

        [TestMethod]
        public void GivenDaysOfWeek_ThenIEnumerableOfValuesIsReturned()
        {
            var result = EnumHelper.GetValues<DayOfWeek>();

            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(IEnumerable<DayOfWeek>));
            TestAllDaysInResult(result.ToList());
        }

        [TestMethod]
        public void GivenDaysOfWeek_WhenEnumValuessFromReflection_ThenValuesArrayIsReturned()
        {
            var result = EnumHelper.GetValuesWithReflection<DayOfWeek>();

            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(DayOfWeek[]));
            TestAllDaysInResult(result.ToList());
        }

        private void TestAllDaysInResult(System.Collections.ICollection result)
        {
            Assert.AreEqual(7, result.Count);

            CollectionAssert.Contains(result, DayOfWeek.Monday);
            CollectionAssert.Contains(result, DayOfWeek.Tuesday);
            CollectionAssert.Contains(result, DayOfWeek.Wednesday);
            CollectionAssert.Contains(result, DayOfWeek.Thursday);
            CollectionAssert.Contains(result, DayOfWeek.Friday);
            CollectionAssert.Contains(result, DayOfWeek.Saturday);
            CollectionAssert.Contains(result, DayOfWeek.Sunday);
        }
    }
}