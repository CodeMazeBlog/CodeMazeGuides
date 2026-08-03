using SerializationDemo.Client.Serialization;
using SerializationDemo.Client.Serialization.Protobuf;
using SerializationDemo.Common.Models;
using System.Net.Http.Headers;

namespace SerializationDemo.Client.Clients
{
    internal class ProtobufClient : ClientBase, IClient
    { 
        private readonly IByteSerializer _serializer = new ProtobufSerializer();
        private readonly HttpClient _client = new HttpClient();

        public async Task<Employee> CreateEmployee(Employee employee)
        {
            var url = $"{BaseUrl}/api/employees";
            var request = new HttpRequestMessage(HttpMethod.Post, url);
            request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/x-protobuf"));            
            request.Content = new ByteArrayContent(_serializer.Serialize(employee));
            request.Content.Headers.Add("Content-Type", "application/x-protobuf");

            var response = await _client.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                var newEmployee = _serializer.Deserialize<Employee>(await response.Content.ReadAsByteArrayAsync());
                return newEmployee;
            }

            return null;
        }

        public async Task<List<Employee>> GetAllEmployees()
        {
            var url = $"{BaseUrl}/api/employees";
            var request = new HttpRequestMessage(HttpMethod.Get, url);
            request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/x-protobuf"));
            
            var response = await _client.SendAsync(request);
            var content = await response.Content.ReadAsByteArrayAsync();
            
            return _serializer.Deserialize<List<Employee>>(content);
        }
    }
}
