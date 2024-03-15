namespace PassComplexParametersToTheory.Tests;

public class TestData
{
    public static IEnumerable<object[]> AuthorData =>
        new List<object[]>
        {
            new object[]
            {
                new Author
                {
                    Id = 1,
                    Name = "Frank Herbert"

                }
            }
        };
}
