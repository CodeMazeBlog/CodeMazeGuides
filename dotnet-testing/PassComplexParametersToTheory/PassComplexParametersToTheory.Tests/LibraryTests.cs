namespace PassComplexParametersToTheory.Tests;

public class LibraryTests
{
    private readonly Library _library = new();

    [Theory, MemberData(nameof(GetBookData), parameters: 2)]
    public void GivenThatBooksIsPresent_WhenAddBookIsInvoked_ThenFalseIsReturned(Book book)
    {
        // Arrange
        _library.AddBook(book);

        // Act
        var result = _library.AddBook(book);

        // Assert
        result.Should().BeFalse();
    }

    [Theory, MemberData(nameof(BookData))]
    public void GivenThatBooksIsNotPresent_WhenAddBookIsInvoked_ThenTrueIsReturned(Book book)
    {
        // Act
        var result = _library.AddBook(book);

        // Assert
        result.Should().BeTrue();
    }

    [Theory, MemberData(nameof(TestData.AuthorData), MemberType = typeof(TestData))]
    public void GivenThatAuthorIsPresent_WhenAddBookIsInvoked_ThenFalseIsReturned(Author author)
    {
        // Arrange
        _library.AddAuthor(author);

        // Act
        var result = _library.AddAuthor(author);

        // Assert
        result.Should().BeFalse();
    }

    [Theory, MemberData(nameof(TestData.AuthorData), MemberType = typeof(TestData))]
    public void GivenThatAuthorIsNotPresent_WhenAddBookIsInvoked_ThenTrueIsReturned(Author author)
    {
        // Act
        var result = _library.AddAuthor(author);

        // Assert
        result.Should().BeTrue();
    }

    public static IEnumerable<object[]> BookData =>
        new List<object[]>
        {
            new object[]
            {
                new Book
                {
                   Id = 1,
                   AuthorId = 1,
                   Title = "Dune"
                }
            }
        };

    public static IEnumerable<object[]> GetBookData(int numberOfBooks)
    {
        var books = new List<object[]>
        {
            new object[]
            {
                new Book
                {
                   Id = 1,
                   AuthorId = 1,
                   Title = "Dune"
                }
            },
            new object[]
            {
                new Book
                {
                   Id = 2,
                   AuthorId = 2,
                   Title = "Hyperion"
                }
            }
        };

        return books.Take(numberOfBooks);
    }
}
