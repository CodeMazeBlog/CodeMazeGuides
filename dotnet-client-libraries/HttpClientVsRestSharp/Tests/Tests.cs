using HttpClientVsRestSharp;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Xunit;

namespace Tests
{
    public class Tests
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
