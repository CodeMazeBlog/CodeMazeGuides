using Microsoft.AspNetCore.Mvc;

using RestSharp;

using System.Text.Json;

using WorkingWithRestSharp.DataTransferObject;

namespace WorkingWithRestSharp.Controllers
{
    [ApiController]
    [Route("api/users")]
    public class UsersController : ControllerBase
    {
        private readonly RestClient _client;
        private readonly JsonSerializerOptions _jsonSerializerOptions;

        public UsersController()
        {
            _client = new RestClient("https://reqres.in/");
            _jsonSerializerOptions = new JsonSerializerOptions(new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        }


        [HttpGet]
        public async Task<IActionResult> GetUserList()
        {
            RestRequest request = new RestRequest("api/users");
            var response = await _client.ExecuteGetAsync(request);
            if (!response.IsSuccessful)
            {
                return NotFound();
            }
            var userList = JsonSerializer.Deserialize<UserList>(response.Content, _jsonSerializerOptions);
            return Ok(userList);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUser(string id)
        {
            RestRequest request = new RestRequest($"api/users/{id}");
            var response = await _client.ExecuteGetAsync(request);
            if (!response.IsSuccessful)
            {
                return NotFound();
            }
            var userDetails = JsonSerializer.Deserialize<UserDetails>(response.Content, _jsonSerializerOptions);
            return Ok(userDetails);
        }

        [HttpPost]
        public async Task<IActionResult> AddUser([FromBody] UserForCreation userForCreation)
        {
            RestRequest request = new RestRequest("api/users")
                        .AddJsonBody(userForCreation);
            var response = await _client.ExecutePostAsync(request);
            if (!response.IsSuccessful)
            {
                return NotFound();
            }
            var userCreationResponse = JsonSerializer.Deserialize<UserCreationResponse>(response.Content, _jsonSerializerOptions);
            return Ok(userCreationResponse);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser([FromBody] UserForUpdate userForUpdate, string id)
        {
            RestRequest request = new RestRequest($"api/users/{id}", Method.Put)
                .AddJsonBody(userForUpdate);
            var response = await _client.ExecuteAsync<UserUpdateResponse>(request);
            if (!response.IsSuccessful)
            {
                return NotFound();
            }
            var userUpdateResponse = JsonSerializer.Deserialize<UserUpdateResponse>(response.Content, _jsonSerializerOptions);
            return Ok(userUpdateResponse);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(string id)
        {
            UserDeleteResponse userDeleteResponse = new UserDeleteResponse();
            RestRequest request = new RestRequest($"api/users/{id}", Method.Delete);
            var response = await _client.ExecuteAsync(request);
            if (!response.IsSuccessful)
            {
                userDeleteResponse.Message = "Failed";
            }
            userDeleteResponse.Message = "Deleted Successfully";
            return Ok(userDeleteResponse);
        }
    }
}