namespace PassComplexParametersToTheory.Tests;

public class LibraryTestData : IEnumerable<object[]>
{
    public IEnumerator<object[]> GetEnumerator()
    {
        yield return new object[]
        {
            new Library
            {
                Books = new List<Book>
                {
                    new()
                    {
                       Id = 1,
                       AuthorId = 1,
                       Title = "Dune",
                       IsCheckedOut = false
                    },
                    new()
                    {
                       Id = 2,
                       AuthorId = 2,
                       Title = "Hyperion",
                       IsCheckedOut = true
                    }
                },
                Authors = new List<Author>
                {
                    new()
                    {
                       Id = 1,
                       Name = "Frank Herbert",
                    },
                    new()
                    {
                       Id = 2,
                       Name = "Dan Simmons",
                    }
                }
            }
        };
    }

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}
