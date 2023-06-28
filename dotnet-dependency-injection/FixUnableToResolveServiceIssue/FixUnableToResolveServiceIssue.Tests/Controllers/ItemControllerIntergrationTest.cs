using FixUnableToResolveServiceIssue.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace FixUnableToResolveServiceIssue.Tests.Controllers
{
    internal class ItemControllerIntergrationTest : BaseIntegrationTest
    {
        [Test]
        public async Task WhenInvokingGet_ReturnsStatusCode200()
        {
            var response = await httpClient.GetAsync("/api/Item");
            Assert.That(response, Is.Not.Null);
            Assert.That(response.IsSuccessStatusCode, Is.True);
            Assert.DoesNotThrow(() => response.EnsureSuccessStatusCode());
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            var conent = await response.Content.ReadFromJsonAsync<Item>();
            Assert.That(conent, Is.Not.Null);
            Assert.That(conent.Id, Is.EqualTo(1));
            Assert.That(conent.Name, Is.EqualTo("Code Maze"));
            Assert.That(conent.Description, Is.EqualTo("Code Maze Item!"));
        }
    }
}
