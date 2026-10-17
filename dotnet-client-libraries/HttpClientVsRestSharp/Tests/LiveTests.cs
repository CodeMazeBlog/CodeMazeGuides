using HttpClientVsRestSharp;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Xunit;

namespace Tests
{
    public class LiveTests
    {

        [Fact]
        public async Task GivenHttpClient_WhenGettingTodos_ThenReturnsListOfTodos()
        {
            //Arrange
            var httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri("https://jsonplaceholder.typicode.com/");

            //Act
            var response = await httpClient.GetAsync("todos");
            var todos = await response.Content.ReadFromJsonAsync<List<Todo>>();

            //Assert
            Assert.NotNull(todos);
            Assert.NotEmpty(todos);
        }

        [Fact]
        public async Task GivenRestSharp_WhenGettingTodos_ThenReturnsListOfTodos()
        {
            //Arrange
            var restClient = new RestClient("https://jsonplaceholder.typicode.com/");

            //Act
            var request = new RestRequest("todos");
            var todos = await restClient.GetAsync<List<Todo>>(request);

            //Assert
            Assert.NotNull(todos);
            Assert.NotEmpty(todos);
        }

        [Fact]
        public async Task GivenHttpClient_WhenCreatingTodo_ThenReturnsCreatedTodoWithId()
        {
            //Arrange
            var httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri("https://jsonplaceholder.typicode.com/");
            var todoForCreation = GetTodoForCreation();

            var serializedTodo = JsonSerializer.Serialize(todoForCreation);
            var requestContent = new StringContent(serializedTodo, Encoding.UTF8, "application/json");

            //Act
            var response = await httpClient.PostAsync("todos", requestContent);
            var createdTodo = await response.Content.ReadFromJsonAsync<Todo>();

            //Assert
            Assert.NotNull(createdTodo);
            Assert.NotEqual(createdTodo!.Id, todoForCreation.Id);
        }

        [Fact]
        public async Task GivenRestSharp_WhenCreatingTodo_ThenReturnsCreatedTodoWithId()
        {
            //Arrange
            var restClient = new RestClient("https://jsonplaceholder.typicode.com/");
            var todoForCreation = GetTodoForCreation();
            var request = new RestRequest("todos").AddJsonBody(todoForCreation);

            //Act
            var createdTodo = await restClient.PostAsync<Todo>(request);

            //Assert
            Assert.NotNull(createdTodo);
            Assert.NotEqual(createdTodo!.Id, todoForCreation.Id);
        }

        [Fact]
        public async Task GivenHttpClient_WhenUpdatingTodo_ThenReturnsUpdatedTodoWithCorrectTitle()
        {
            //Arrange
            var httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri("https://jsonplaceholder.typicode.com/");
            var todoForUpdate = GetTodoForUpdate();

            var serializedTodo = JsonSerializer.Serialize(todoForUpdate);
            var requestContent = new StringContent(serializedTodo, Encoding.UTF8, "application/json");

            //Act
            var response = await httpClient.PutAsync($"todos/{todoForUpdate.Id}", requestContent);
            var updatedTodo = await response.Content.ReadFromJsonAsync<Todo>();

            //Assert
            Assert.NotNull(updatedTodo);
            Assert.NotSame(updatedTodo!.Title, todoForUpdate.Title);
        }

        [Fact]
        public async Task GivenRestSharp_WhenUpdatingTodo_ThenReturnsUpdatedTodoWithCorrectTitle()
        {
            //Arrange
            var restClient = new RestClient("https://jsonplaceholder.typicode.com/");
            var todoForUpdate = GetTodoForUpdate();
            var request = new RestRequest($"todos/{todoForUpdate.Id}").AddJsonBody(todoForUpdate);

            //Act
            var updatedTodo = await restClient.PutAsync<Todo>(request);

            //Assert
            Assert.NotNull(updatedTodo);
            Assert.NotSame(updatedTodo!.Title, todoForUpdate.Title);
        }

        [Fact]
        public async Task GivenHttpClient_WhenDeletingTodo_ThenResponseIsSuccessStatusCode()
        {
            //Arrange
            var httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri("https://jsonplaceholder.typicode.com/");

            //Act
            var response = await httpClient.DeleteAsync("todos/1");

            //Assert
            Assert.True(response.IsSuccessStatusCode);
        }

        [Fact]
        public async Task GivenRestSharp_WhenDeletingTodo_ThenResponseIsSuccessful()
        {
            //Arrange
            var restClient = new RestClient("https://jsonplaceholder.typicode.com/");
            var request = new RestRequest("todos/1");

            //Act
            var response = await restClient.DeleteAsync(request);

            //Assert
            Assert.True(response.IsSuccessful);
        }

        [Fact]
        public async Task GivenHttpClient_WhenGettingTodosWithGetFromJsonAsync_ThenReturnsListOfTodos()
        {
            //Arrange
            var httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri("https://jsonplaceholder.typicode.com/");

            //Act
            var todos = await httpClient.GetFromJsonAsync<List<Todo>>("todos");

            //Assert
            Assert.NotNull(todos);
            Assert.NotEmpty(todos);
        }

        [Fact]
        public async Task GivenRestSharp_WhenExecutingGetForTodos_ThenResponseIsSuccessful()
        {
            //Arrange
            var restClient = new RestClient("https://jsonplaceholder.typicode.com/");
            var request = new RestRequest("todos");

            //Act
            var response = await restClient.ExecuteGetAsync<List<Todo>>(request);

            //Assert
            Assert.True(response.IsSuccessful);
            Assert.NotNull(response.Data);
            Assert.NotEmpty(response.Data);
        }

        [Fact]
        public async Task GivenHttpClient_WhenPathDoesNotExist_ThenEnsureSuccessStatusCodeThrows()
        {
            //Arrange
            var httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri("https://jsonplaceholder.typicode.com/");

            //Act
            var response = await httpClient.GetAsync("no-such-path");

            //Assert
            Assert.False(response.IsSuccessStatusCode);
            Assert.Throws<HttpRequestException>(() => response.EnsureSuccessStatusCode());
        }

        [Fact]
        public async Task GivenRestSharp_WhenPathDoesNotExist_ThenResponseIsNotSuccessfulAndNothingThrows()
        {
            //Arrange
            var restClient = new RestClient("https://jsonplaceholder.typicode.com/");
            var request = new RestRequest("no-such-path");

            //Act
            var response = await restClient.ExecuteGetAsync<Todo>(request);

            //Assert
            Assert.False(response.IsSuccessful);
            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
        }

        [Fact]
        public void GivenHttpClient_WhenSendingSynchronously_ThenResponseIsSuccessStatusCode()
        {
            //Arrange
            var httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri("https://jsonplaceholder.typicode.com/");
            var request = new HttpRequestMessage(HttpMethod.Get, "todos");

            //Act
            var response = httpClient.Send(request);

            //Assert
            Assert.True(response.IsSuccessStatusCode);
        }

        [Fact]
        public void GivenRestSharp_WhenGettingTodosSynchronously_ThenReturnsListOfTodos()
        {
            //Arrange
            var restClient = new RestClient("https://jsonplaceholder.typicode.com/");
            var request = new RestRequest("todos");

            //Act
            var todos = restClient.Get<List<Todo>>(request);

            //Assert
            Assert.NotNull(todos);
            Assert.NotEmpty(todos);
        }

        private static Todo GetTodoForCreation()
        {
            return new Todo
            {
                Id = 0,
                UserId = 1,
                Completed = false,
                Title = "Wake Up!"
            };
        }

        private static Todo GetTodoForUpdate()
        {
            return new Todo
            {
                Id = 2,
                UserId = 2,
                Completed = false,
                Title = "Have Lunch!"
            };
        }
    }
}
