using Microsoft.AspNetCore.Mvc;

using RestSharp;

using System.Net;
using System.Text.Json;

namespace WorkingWithRestSharp.Controllers
{
    [ApiController]
    [Route("user")]
    public class UserController : ControllerBase
    {
        private const string BaseUrl = "https://reqres.in/";

        [Route("getUserList")]
        [HttpGet]
        public async Task<UserDetails> GetUserList()
        {
            UserDetails userList = new UserDetails();
            RestClient client = new RestClient(BaseUrl);
            RestRequest request = new RestRequest("api/users");
            var response = await client.ExecuteGetAsync(request);
            if (response.Content != null)
            {
                userList = JsonSerializer.Deserialize<UserDetails>(response.Content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
            }
            return userList;
        }

        [Route("getUserById/{id}")]
        [HttpGet]
        public async Task<SingleUserDetails> GetUserDetailsById(string id)
        {
            SingleUserDetails singleUserDetails = new SingleUserDetails();
            RestClient client = new RestClient(BaseUrl);
            RestRequest request = new RestRequest($"api/users/{id}");
            var response = await client.ExecuteGetAsync(request);
            if (response.Content != null)
            {
                singleUserDetails = JsonSerializer.Deserialize<SingleUserDetails>(response.Content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
            }
            return singleUserDetails;
        }

        [Route("addNewUserAndJob")]
        [HttpPost]
        public async Task<UserJobDetails> AddNewUserAndJob(UserJobDetailsRequest userJobDetailsRequest)
        {
            UserJobDetails userDetails = new UserJobDetails();
            RestClient client = new RestClient(BaseUrl);
            RestRequest request = new RestRequest("api/users", Method.Post);
            request.AddJsonBody(userJobDetailsRequest);
            var response = await client.ExecutePostAsync(request);
            if (response.Content != null)
            {
                userDetails = JsonSerializer.Deserialize<UserJobDetails>(response.Content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
            }
            return userDetails;
        }

        [Route("updateUserAndJob")]
        [HttpPut]
        public async Task<UpdateUserJobDetails> UpdateUserAndJob(UpdateUserJobDetailsRequest updateUserJobDetailsRequest)
        {
            UpdateUserJobDetails userDetails = new UpdateUserJobDetails();
            RestClient client = new RestClient(BaseUrl);
            RestRequest request = new RestRequest($"api/users/{updateUserJobDetailsRequest.Id}", Method.Put);
            request.AddJsonBody(updateUserJobDetailsRequest);
            var response = await client.ExecuteAsync(request);
            if (response.Content != null)
            {
                userDetails = JsonSerializer.Deserialize<UpdateUserJobDetails>(response.Content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
            }
            return userDetails;
        }

        [Route("deleteUser/{id}")]
        [HttpDelete]
        public async Task<DeleteResponse> DeleteUser(string id)
        {
            DeleteResponse deleteResponse = new DeleteResponse();
            RestClient client = new RestClient(BaseUrl);
            RestRequest request = new RestRequest($"api/users/{id}", Method.Delete);
            var response = await client.ExecuteAsync(request);
            var responseStatusCode = response.StatusCode;
            if (responseStatusCode == HttpStatusCode.NoContent)
            {
                deleteResponse.Message = "Deleted Successfully";
                return deleteResponse;
            }
            deleteResponse.Message = "Failed";
            return deleteResponse;
        }
    }
}