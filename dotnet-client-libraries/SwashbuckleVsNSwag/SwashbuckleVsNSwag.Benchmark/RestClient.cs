using SwashbuckleVsNSwag.Models.Customers;
using System.Net.Http.Headers;
using System.Net.Http.Json;

namespace SwashbuckleVsNSwag.Benchmark
{
    public class RestClient
    {
        private static readonly HttpClient client = new HttpClient();

        public async Task<Customer> GetCustomerAsync(string host)
        {
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var id = "8e282cc4-71bd-4ffd-b63c-05e91ba79ad1";
            return await client.GetFromJsonAsync<Customer>($"{host}/customer/{id}");
        }

        public async Task PostCustomerAsync(string host)
        {
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var customer = new Customer
            {
                CustomerId = Guid.NewGuid(),
                Name = "John Smith",
                Address = new Address
                {
                    AddressLine1 = "Address Line 1",
                    City = "Nice City",
                    Country = "Nice Country",
                    PostalCode = "PostalCode"
                }
            };

            await client.PostAsJsonAsync($"{host}/customer", customer);
        }
    }
}
