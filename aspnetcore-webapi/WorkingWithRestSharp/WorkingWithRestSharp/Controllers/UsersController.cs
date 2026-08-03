using Microsoft.AspNetCore.Mvc;

using RestSharp;

using WorkingWithRestSharp.DataTransferObject;

namespace WorkingWithRestSharp.Controllers
{
    [ApiController]
    [Route("api/users")]
    public class UsersController : ControllerBase
    {
        private readonly RestClient _client;

        public UsersController()
        {
            _client = new RestClient("https://reqres.in/");
        }


        [HttpGet]
        public async Task<IActionResult> GetUserList()
        {
            var request = new RestRequest("api/users");
            var response = await _client.ExecuteGetAsync<UserList>(request);

            if (!response.IsSuccessful)
            {
                //Logic for handling unsuccessful response
            }

            return Ok(response.Data);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUser(string id)
        {
            var request = new RestRequest($"api/users/{id}");
            var response = await _client.ExecuteGetAsync<UserDetails>(request);

            if (!response.IsSuccessful)
            {
                //Logic for handling unsuccessful response
            }

            return Ok(response.Data);
        }

        [HttpPost]
        public async Task<IActionResult> AddUser([FromBody] UserForCreation userForCreation)
        {
            var request = new RestRequest("api/users")
                        .AddJsonBody(userForCreation);
            var response = await _client.ExecutePostAsync<UserCreationResponse>(request);

            if (!response.IsSuccessful)
            {
                //Logic for handling unsuccessful response
            }

            return StatusCode(201, response.Data);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser([FromBody] UserForUpdate userForUpdate, string id)
        {
            var request = new RestRequest($"api/users/{id}")
                .AddJsonBody(userForUpdate);
            var response = await _client.ExecutePutAsync<UserUpdateResponse>(request);

            if (!response.IsSuccessful)
            {
                //Logic for handling unsuccessful response
            }

            return Ok(response.Data);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(string id)
        {
            var request = new RestRequest($"api/users/{id}", Method.Delete);
            var response = await _client.ExecuteAsync(request);

            if (!response.IsSuccessful)
            {
                //Logic for handling unsuccessful response
            }

            return NoContent();
        }
    }
}