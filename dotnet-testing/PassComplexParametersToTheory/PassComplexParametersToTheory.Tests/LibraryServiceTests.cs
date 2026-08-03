namespace PassComplexParametersToTheory.Tests;

public class LibraryServiceTests
{
    [Theory, ClassData(typeof(LibraryTestData))]
    public void GivenThatBooksIsCheckedOut_WhenCheckOutBookIsInvoked_ThenFalseIsReturned(Library library)
    {
        // Arrange
        var sut = new LibraryService(library);
        var checkedOutBook = library.Books.First(x => x.IsCheckedOut);

        // Act
        var result = sut.CheckOutBook(checkedOutBook.Id);

        // Assert
        result.Should().BeFalse();
    }

    [Theory, ClassData(typeof(LibraryTestData))]
    public void GivenThatBooksIsNotCheckedOut_WhenCheckOutBookIsInvoked_ThenTrueIsReturned(Library library)
    {
        // Arrange
        var sut = new LibraryService(library);
        var checkedOutBook = library.Books.First(x => !x.IsCheckedOut);

        // Act
        var result = sut.CheckOutBook(checkedOutBook.Id);

        // Assert
        result.Should().BeTrue();
    }

    [Theory, ClassData(typeof(LibraryTestData))]
    public void GivenThatBooksIsCheckedOut_WhenReturnBookIsInvoked_ThenFalseIsReturned(Library library)
    {
        // Arrange
        var sut = new LibraryService(library);
        var checkedOutBook = library.Books.First(x => x.IsCheckedOut);

        // Act
        var result = sut.ReturnBook(checkedOutBook.Id);

        // Assert
        result.Should().BeTrue();
    }

    [Theory, ClassData(typeof(LibraryTestData))]
    public void GivenThatBooksIsNotCheckedOut_WhenReturnBookIsInvoked_ThenTrueIsReturned(Library library)
    {
        // Arrange
        var sut = new LibraryService(library);
        var checkedOutBook = library.Books.First(x => !x.IsCheckedOut);

        // Act
        var result = sut.ReturnBook(checkedOutBook.Id);

        // Assert
        result.Should().BeFalse();
    }
}
