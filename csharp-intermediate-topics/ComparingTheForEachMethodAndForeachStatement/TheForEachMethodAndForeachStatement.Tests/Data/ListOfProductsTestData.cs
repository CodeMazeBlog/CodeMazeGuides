using System.Collections;

namespace TheForEachMethodAndForeachStatement.Tests.Data;

public class ListOfProductsTestData : IEnumerable<object[]>
{
    public IEnumerator<object[]> GetEnumerator()
    {
        yield return new object[] { new List<Product> { new Product(1) }, 1 };
        yield return new object[] { new List<Product> { new Product(-100), new Product(0) }, -100 };
        yield return new object[] { new List<Product> { new Product(1), new Product(2), new Product(3), new Product(4), new Product(5) }, 15 };
        yield return new object[] { new List<Product> { new Product(1), new Product(2), new Product(3), new Product(4), new Product(-5) }, 5 };
    }

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}
