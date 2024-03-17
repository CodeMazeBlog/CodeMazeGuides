using System.Net;

namespace Test
{
    [TestClass]
    public class DirectoryBrowsingTest
    {
        [TestMethod]
        public async void Index_ShouldReturnViewResult()
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Get, "http://localhost:5291/wwwroot");
            var response = await client.SendAsync(request);
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        }
    }
}