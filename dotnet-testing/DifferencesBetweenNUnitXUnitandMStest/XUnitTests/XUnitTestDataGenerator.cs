using System.Collections;

namespace XUnitTests
{
    public class XUnitTestDataGenerator : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] { 3, 2, 1 };
            yield return new object[] { 0, 0, 0 };
            yield return new object[] { -2, 3, -5 };
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
