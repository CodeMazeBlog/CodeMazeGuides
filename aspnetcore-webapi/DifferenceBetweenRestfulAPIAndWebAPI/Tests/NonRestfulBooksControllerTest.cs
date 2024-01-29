namespace Tests
{
    public class NonRestfulBooksControllerTest
    {
        private readonly Mock<IBookService> _mockService;
        private readonly NonRestfulBooksController _controller;

        public NonRestfulBooksControllerTest()
        {
            _mockService = new Mock<IBookService>();
            _controller = new NonRestfulBooksController(_mockService.Object);
        }

        [Fact]
        public void WhenDeleteBookExecutes_ThenReturnsNoContent()
        {
            _mockService.Setup(service => service.Delete(1));

            var result = _controller.DeleteBook(1);

            Assert.IsType<NoContentResult>(result);
        }
    }
}