using UpdateItemInListCSharp.Models;

namespace UpdateItemInListCSharp.Test
{
    public class LibraryTest
    {
        [Fact]
        public void WhenCheckoutBookFind_ThenBookIsCheckedOut()
        {
            // Arrange
            var library = new Library();

            // Act
            library.CheckoutBookFind("978-0439708180");

            // Assert
            Assert.True(library.Books[0].IsCheckedOut);
        }

        [Fact]
        public void WhenCheckoutBookFindIndex_ThenBookIsCheckedOut()
        {
            // Arrange
            var library = new Library();

            // Act
            library.CheckoutBookFindIndex("978-0439708180");

            // Assert
            Assert.True(library.Books[0].IsCheckedOut);
        }

        [Fact]
        public void WhenCheckoutBookFirstOrDefault_ThenBookIsCheckedOut()
        {
            // Arrange
            var library = new Library();

            // Act
            library.CheckoutBookFirstOrDefault("978-0439708180");

            // Assert
            Assert.True(library.Books[0].IsCheckedOut);
        }

        [Fact]
        public void WhenCheckoutBookForeach_ThenBookIsCheckedOut()
        {
            // Arrange
            var library = new Library();

            // Act
            library.CheckoutBookForeach("978-0439708180");

            // Assert
            Assert.True(library.Books[0].IsCheckedOut);
        }

        [Fact]
        public void WhenCheckoutBookIndexOf_ThenBookIsCheckedOut()
        {
            // Arrange
            var library = new Library();
            var book = library.AddBook("J.K. Rowling", "978-0545010221", false, "Harry Potter and the Deathly Hallows");
            var indexOfBook = library.Books.IndexOf(book);

            // Act
            library.CheckoutBookIndexOf(book);

            // Assert
            Assert.True(library.Books[indexOfBook].IsCheckedOut);
        }

        [Fact]
        public void WhenCheckoutBookSingleOrDefault_ThenBookIsCheckedOut()
        {
            // Arrange
            var library = new Library();

            // Act
            library.CheckoutBookSingleOrDefault("978-0439708180");

            // Assert
            Assert.True(library.Books[0].IsCheckedOut);
        }
    }
}
