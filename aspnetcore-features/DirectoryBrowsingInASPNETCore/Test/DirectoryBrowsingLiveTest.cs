namespace Test
{
    [TestClass]
    public class DirectoryBrowsingLiveTest
    {
        [TestMethod]
        public async Task WhenAccessingTheDirectoryBrowsingPage_ThenCorrectStatusCode()
        {
            //Arrange
            var webApplication = new WebApplicationFactory<Program>();
            var client = webApplication.CreateClient();

            //Act
            var response = await client.GetAsync($"{client.BaseAddress}wwwroot");

            //Assert
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        }
    }
}