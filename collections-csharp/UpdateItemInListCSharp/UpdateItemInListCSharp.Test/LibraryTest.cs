using UpdateItemInListCSharp.Models;

namespace UpdateItemInListCSharp.Test
{
    public class LibraryTest
    {
        private readonly Library _library = new Library();

        [Fact]
        public void WhenCheckoutBookFind_ThenBookIsCheckedOut()
        {
            // Arrange
            var book = new Book("Dolor sit amet Sadipscing", "Lorem Ipsum", "123-0123456789", false);
            _library.Books.Add(book);

            // Act
            _library.CheckoutBookUsingFind("123-0123456789");
            var checkoutBook = _library.Books.Find(b => b.ISBN == "123-0123456789");

            // Assert
            Assert.True(checkoutBook!.IsCheckedOut);
        }

        [Fact]
        public void WhenCheckoutBookFindIndex_ThenBookIsCheckedOut()
        {
            // Arrange
            var book = new Book("Dolor sit amet Sadipscing", "Lorem Ipsum", "123-0123456788", false);
            _library.Books.Add(book);

            // Act
            _library.CheckoutBookUsingFindIndex("123-0123456788");
            var checkoutBook = _library.Books.Find(b => b.ISBN == "123-0123456788");

            // Assert
            Assert.True(checkoutBook!.IsCheckedOut);
        }

        [Fact]
        public void WhenCheckoutBookFirstOrDefault_ThenBookIsCheckedOut()
        {
            // Arrange
            var book = new Book("Dolor sit amet Sadipscing", "Lorem Ipsum", "123-0123456787", false);
            _library.Books.Add(book);

            // Act
            _library.CheckoutBookUsingFirstOrDefault("123-0123456787");
            var checkoutBook = _library.Books.Find(b => b.ISBN == "123-0123456787");

            // Assert
            Assert.True(checkoutBook!.IsCheckedOut);
        }

        [Fact]
        public void WhenCheckoutBookForeach_ThenBookIsCheckedOut()
        {
            // Arrange
            var book = new Book("Dolor sit amet Sadipscing", "Lorem Ipsum", "123-0123456786", false);
            _library.Books.Add(book);

            // Act
            _library.CheckoutBookUsingForeach("123-0123456786");
            var checkoutBook = _library.Books.Find(b => b.ISBN == "123-0123456786");

            // Assert
            Assert.True(checkoutBook!.IsCheckedOut);
        }

        [Fact]
        public void WhenCheckoutBookIndexOf_ThenBookIsCheckedOut()
        {
            // Arrange
            var book = new Book("Dolor sit amet Sadipscing", "Lorem Ipsum", "123-0123456785", false);
            _library.Books.Add(book);
            var indexOfBook = _library.Books.IndexOf(book);

            // Act
            _library.CheckoutBookUsingIndexOf(book);
            var checkoutBook = _library.Books.Find(b => b.ISBN == "123-0123456785");

            // Assert
            Assert.True(checkoutBook!.IsCheckedOut);
        }

        [Fact]
        public void WhenCheckoutBookSingleOrDefault_ThenBookIsCheckedOut()
        {
            // Arrange
            var book = new Book("Dolor sit amet Sadipscing", "Lorem Ipsum", "123-0123456784", false);
            _library.Books.Add(book);

            // Act
            _library.CheckoutBookUsingSingleOrDefault("123-0123456784");
            var checkoutBook = _library.Books.Find(b => b.ISBN == "123-0123456784");

            // Assert
            Assert.True(checkoutBook!.IsCheckedOut);
        }
    }
}
