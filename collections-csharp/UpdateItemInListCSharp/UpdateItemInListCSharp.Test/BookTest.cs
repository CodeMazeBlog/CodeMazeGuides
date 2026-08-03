using UpdateItemInListCSharp.Models;

namespace UpdateItemInListCSharp.Test;

public class BookTest
{
    [Fact]
    public void WhenBookEquals_ThenReturnTrue()
    {
        // Arrange
        var book1 = new Book("Harry Potter and the Philosopher's Stone", "J.K. Rowling", "978-0439708180", false);
        var book2 = new Book("Harry Potter and the Philosopher's Stone", "J.K. Rowling", "978-0439708180", false);

        // Act
        var result = book1.Equals(book2);

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void WhenBookIsCheckedOut_ThenReturnTrue()
    {
        // Arrange
        var book = new Book("Harry Potter and the Philosopher's Stone", "J.K. Rowling", "978-0439708180", false);

        // Act
        book.IsCheckedOut = true;

        // Assert
        Assert.True(book.IsCheckedOut);
    }

    [Fact]
    public void WhenBookIsNotCheckedOut_ThenReturnFalse()
    {
        // Arrange
        var book = new Book("Harry Potter and the Philosopher's Stone", "J.K. Rowling", "978-0439708180", true);

        // Act
        book.IsCheckedOut = false;

        // Assert
        Assert.False(book.IsCheckedOut);
    }

    [Fact]
    public void WhenBookNotEquals_ThenReturnFalse()
    {
        // Arrange
        var book1 = new Book("Harry Potter and the Philosopher's Stone", "J.K. Rowling", "978-0439708180", false);
        var book2 = new Book("Harry Potter and the Chamber of Secrets", "J.K. Rowling", "978-0439064873", false);

        // Act
        var result = book1.Equals(book2);

        // Assert
        Assert.False(result);
    }
}

