namespace Tests
{
    public class BooksControllerTest
    {
        private readonly Mock<IBookService> _mockService;
        private readonly BooksController _controller;

        public BooksControllerTest()
        {
            _mockService = new Mock<IBookService>();
            _controller = new BooksController(_mockService.Object);
        }

        [Fact]
        public void WhenGetAllBooksExecutes_ThenReturnsExactNumberOfBooks()
        {
            _mockService.Setup(service => service.GetAllBooks())
                .Returns([new Book(), new Book()]);

            var result = _controller.GetAllBooks();

            var actionResult = Assert.IsType<OkObjectResult>(result);
            var books = Assert.IsType<List<Book>>(actionResult.Value);

            Assert.Equal(2, books.Count);
        }
    }
}