using SerializationDemo.Client.Serialization;
using SerializationDemo.Client.Serialization.Xml;
using SerializationDemo.Common.Models;
using System.Net.Http.Headers;
using System.Text;

namespace SerializationDemo.Client.Clients
{
    internal class XmlClient : ClientBase, IClient
    {        
        private readonly IStringSerializer _serializer = new XmlSerializer();
        private readonly HttpClient _client = new HttpClient();

        public async Task<Employee> CreateEmployee(Employee employee)
        {
            var url = $"{BaseUrl}/api/employees";
            var request = new HttpRequestMessage(HttpMethod.Post, url);
            request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/xml"));            
            request.Content = new StringContent(_serializer.Serialize(employee), Encoding.UTF8, "application/xml");
            
            var response = await _client.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                var newEmployee = _serializer.Deserialize<Employee>(await response.Content.ReadAsStringAsync());
                return newEmployee;
            }

            return null;
        }

        public async Task<List<Employee>> GetAllEmployees()
        {
            var url = $"{BaseUrl}/api/employees";
            var request = new HttpRequestMessage(HttpMethod.Get, url);
            request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/xml"));
            
            var response = await _client.SendAsync(request);
            var content = await response.Content.ReadAsStringAsync();
            
            return _serializer.Deserialize<List<Employee>>(content);
        }
    }
}
