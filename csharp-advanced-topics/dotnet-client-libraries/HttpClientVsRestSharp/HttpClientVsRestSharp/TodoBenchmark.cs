using BenchmarkDotNet.Attributes;
using RestSharp;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;

namespace HttpClientVsRestSharp
{
    [MemoryDiagnoser]
    public class TodoBenchmark
    {
        private static readonly HttpClient httpClient = new HttpClient();
        private static readonly RestClient restClient = new RestClient("https://jsonplaceholder.typicode.com/");

        public TodoBenchmark()
        {
            httpClient.BaseAddress = new Uri("https://jsonplaceholder.typicode.com/");
        }

        [Benchmark]
        public async Task<List<Todo>?> GetAllTodos_HttpClient()
        {
            var response = await httpClient.GetAsync("todos");
            var todos = await response.Content.ReadFromJsonAsync<List<Todo>>();

            return todos;
        }

        [Benchmark]
        public async Task<List<Todo>?> GetAllTodos_RestSharp()
        {
            var request = new RestRequest("todos");
            var todos = await restClient.GetAsync<List<Todo>>(request);

            return todos;
        }

        [Benchmark]
        public async Task<Todo?> CreateTodo_HttpClient()
        {
            var todoForCreation = GetTodoForCreation();

            var response = await httpClient.PostAsJsonAsync("todos", todoForCreation);
            var createdTodo = await response.Content.ReadFromJsonAsync<Todo>();

            return createdTodo;
        }

        [Benchmark]
        public async Task<Todo?> CreateTodo_RestSharp()
        {
            var todoForCreation = GetTodoForCreation();

            var request = new RestRequest("todos").AddJsonBody(todoForCreation);
            var createdTodo = await restClient.PostAsync<Todo>(request);

            return createdTodo;
        }

        [Benchmark]
        public async Task<Todo?> UpdateTodo_HttpClient()
        {
            var todoForUpdate = GetTodoForUpdate();

            var serializedTodo = JsonSerializer.Serialize(todoForUpdate);
            var requestContent = new StringContent(serializedTodo, Encoding.UTF8, "application/json");

            var response = await httpClient.PutAsync($"todos/{todoForUpdate.Id}", requestContent);
            var updatedTodo = await response.Content.ReadFromJsonAsync<Todo>();

            return updatedTodo;
        }

        [Benchmark]
        public async Task<Todo?> UpdateTodo_RestSharp()
        {
            var todoForUpdate = GetTodoForUpdate();

            var request = new RestRequest($"todos/{todoForUpdate.Id}").AddJsonBody(todoForUpdate);
            var updatedTodo = await restClient.PutAsync<Todo>(request);

            return updatedTodo;
        }

        [Benchmark]
        public async Task DeleteTodo_HttpClient()
        {
            await httpClient.DeleteAsync("todos/1");
        }

        [Benchmark]
        public async Task DeleteTodo_RestSharp()
        {
            var request = new RestRequest("todos/1");
            await restClient.DeleteAsync(request);
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
