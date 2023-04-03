using System.Text;
using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using RequestBodyRead;
using RequestBodyRead.Entities.Models;
using RequestBodyRead.Repository;
using RequestBodyRead.Shared.DataTransferObjects;
using Xunit;

namespace Tests
{
    public class UserControllerTests : IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly WebApplicationFactory<Program> _factory;

        public UserControllerTests(WebApplicationFactory<Program> factory)
        {
            _factory = factory;
        }

        [Fact]
        public async void WhenGetAllUsers_ContainsThreeOriginalUsers()
        {
            var client = _factory.CreateClient();

            client.DefaultRequestHeaders
                .Accept
                .Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

            var url = "/api/users/";
            var response = await client.GetAsync(url);
            var content = await response.Content.ReadAsStringAsync();
            List<User>? users = JsonConvert.DeserializeObject<List<User>>(content);

            var guids = users.Select(x => x.Id).ToList();
            var guidsExpected = DataBaseMockup.Users.Select(x => x.Id).ToList();

            foreach (var guid in guidsExpected)
                Assert.True(guids.Contains(guid));
        }

        [Fact]
        public async void WhenGetUserById_ThenExpectedUserReturned()
        {
            var client = _factory.CreateClient();

            client.DefaultRequestHeaders
                .Accept
                .Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

            var url = "/api/users/ddf4f0a8-09c9-4b39-b722-ae15d8449eae";
            var response = await client.GetAsync(url);
            var content = await response.Content.ReadAsStringAsync();
            var user = JsonConvert.DeserializeObject<User>(content);

            Assert.Equal("John", user.FirstName);
            Assert.Equal("Doe", user.LastName);
            Assert.Equal("john.doe@somealias.com", user.Email);
        }

        [Fact]
        public async void WhenCreateUser_ThenUserCreated()
        {
            var client = _factory.CreateClient();

            client.DefaultRequestHeaders
                .Accept
                .Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

            var url = "/api/users/";

            var userToAdd = new UserForCreationAndUpdateDto
            {
                FirstName = "James",
                LastName = "Ryan",
                Email = "james.ryan@somealias.com"
            };

            var data = JsonConvert.SerializeObject(userToAdd);
            var body = new StringContent(data, Encoding.UTF8, "application/json");
            var response = await client.PostAsync(url, body);
            var content = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<User>(content);

            Assert.Equal("James", result.FirstName);
            Assert.Equal("Ryan", result.LastName);
            Assert.Equal("james.ryan@somealias.com", result.Email);
        }

        [Fact]
        public async void WhenCreateUsers_ThenUsersCreated()
        {
            var result = await AddUsers();

            var resEmails = result.Select(x => x.Email).ToList();
            var resFirstNames = result.Select(x => x.FirstName).ToList();
            var resLastNames = result.Select(x => x.LastName).ToList();

            Assert.True(resEmails.Contains("james.ryan@somealias.com") &&
                resEmails.Contains("sophie.brown@somealias.com"));
            Assert.True(resFirstNames.Contains("James") &&
                resFirstNames.Contains("Sophie"));
            Assert.True(resLastNames.Contains("Ryan") &&
                resLastNames.Contains("Brown"));
        }

        private async Task<List<User>> AddUsers()
        {
            var client = _factory.CreateClient();
            var url = $"/api/users/collection";

            var usersToAdd = new List<UserForCreationAndUpdateDto>
            {
                new UserForCreationAndUpdateDto
                {
                    FirstName = "James",
                    LastName = "Ryan",
                    Email = "james.ryan@somealias.com"
                },
                new UserForCreationAndUpdateDto
                {
                    FirstName = "Sophie",
                    LastName = "Brown",
                    Email = "sophie.brown@somealias.com"
                }
            };

            var data = JsonConvert.SerializeObject(usersToAdd);
            var body = new StringContent(data, Encoding.UTF8, "application/json");
            var response = await client.PostAsync(url, body);
            var content = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<List<User>>(content);

            return result;
        }
    }   
}


