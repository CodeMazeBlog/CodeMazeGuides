using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace FixUnableToResolveServiceIssue.Tests.Controllers
{
    internal class UserControllerIntegrationTest : BaseIntegrationTest
    {
        [Test]
        public async Task WhenInvokingGet_ReturnsStatusCode500()
        {
            var response = await httpClient.GetAsync("/api/User");
            Assert.That(response, Is.Not.Null);
            Assert.Throws<HttpRequestException>(() => response.EnsureSuccessStatusCode());
            Assert.That(response.IsSuccessStatusCode, Is.False);
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.InternalServerError));
        }
    }
}
