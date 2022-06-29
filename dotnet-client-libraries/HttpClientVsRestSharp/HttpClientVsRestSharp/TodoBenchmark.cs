using BenchmarkDotNet.Attributes;
using RestSharp;
using System.Text;
using System.Text.Json;

namespace HttpClientVsRestSharp
{
    [MemoryDiagnoser]
    public class TodoBenchmark
    {
        private static readonly HttpClient _httpClient = new HttpClient();
        private static readonly RestClient _restClient = new RestClient("https://jsonplaceholder.typicode.com/");

        public TodoBenchmark()
        {
            _httpClient.BaseAddress = new Uri("https://jsonplaceholder.typicode.com/");
        }

        [Benchmark]
        public async Task<List<Todo>?> GetAllTodos_HttpClient()
        {
            var response = await _httpClient.GetAsync("todos");
            var content = await response.Content.ReadAsStringAsync();
            var todos = JsonSerializer.Deserialize<List<Todo>>(content);

            return todos;
        }

        [Benchmark]
        public async Task<List<Todo>?> GetAllTodos_RestSharp()
        {
            var request = new RestRequest("todos");
            var todos = await _restClient.GetAsync<List<Todo>>(request);

            return todos;
        }

        [Benchmark]
        public async Task<Todo?> GetSingleTodo_HttpClient()
        {
            var response = await _httpClient.GetAsync("todos/1");
            var content = await response.Content.ReadAsStringAsync();
            var todo = JsonSerializer.Deserialize<Todo>(content);

            return todo;
        }

        [Benchmark]
        public async Task<Todo?> GetSingleTodo_RestSharp()
        {
            var request = new RestRequest("todos/1");
            var todo = await _restClient.GetAsync<Todo>(request);

            return todo;
        }

        [Benchmark]
        public async Task<Todo?> CreateTodo_HttpClient()
        {
            var todoForCreation = GetTodoForCreation();

            var serializedTodo = JsonSerializer.Serialize(todoForCreation);
            var requestContent = new StringContent(serializedTodo, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync("todos", requestContent);
            var responseContent = await response.Content.ReadAsStringAsync();
            var createdTodo = JsonSerializer.Deserialize<Todo>(responseContent);

            return createdTodo;
        }

        [Benchmark]
        public async Task<Todo?> CreateTodo_RestSharp()
        {
            var todoForCreation = GetTodoForCreation();

            var request = new RestRequest("todos").AddJsonBody(todoForCreation);
            var createdTodo = await _restClient.PostAsync<Todo>(request);

            return createdTodo;
        }

        [Benchmark]
        public async Task<Todo?> UpdateTodo_HttpClient()
        {
            var todoForUpdate = GetTodoForUpdate();

            var serializedTodo = JsonSerializer.Serialize(todoForUpdate);
            var requestContent = new StringContent(serializedTodo, Encoding.UTF8, "application/json");

            var response = await _httpClient.PutAsync("todos", requestContent);
            var responseContent = await response.Content.ReadAsStringAsync();
            var updatedTodo = JsonSerializer.Deserialize<Todo>(responseContent);

            return updatedTodo;
        }

        [Benchmark]
        public async Task<Todo?> UpdateTodo_RestSharp()
        {
            var todoForUpdate = GetTodoForUpdate();

            var request = new RestRequest("todos").AddJsonBody(todoForUpdate);
            var updatedTodo = await _restClient.PutAsync<Todo>(request);

            return updatedTodo;
        }

        [Benchmark]
        public async Task DeleteTodo_HttpClient()
        {
            await _httpClient.DeleteAsync("todos/1");
        }

        [Benchmark]
        public async Task DeleteTodo_RestSharp()
        {
            var request = new RestRequest("todos/1");
            await _restClient.DeleteAsync(request);
        }

        private static Todo GetTodoForCreation()
        {
            return new Todo
            {
                Id = 1,
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
