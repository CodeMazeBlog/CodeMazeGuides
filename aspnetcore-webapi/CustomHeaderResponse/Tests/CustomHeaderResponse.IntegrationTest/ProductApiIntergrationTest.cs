using CustomHeaderResponse.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace CustomHeaderResponse.IntegrationTest
{
    public class ProductApiIntergrationTest
    {
        
       [Fact]
       public async Task Test_Get_All_Products_Should_Return_Header()
        {
            using (var client = new TestClientProvider().Client)
            {
                var response = await client.GetAsync("/api/products");
                response.EnsureSuccessStatusCode();
                var responseString = await response.Content.ReadAsStringAsync();
                var products =  JsonConvert.DeserializeObject<List<Product>>(responseString);
                Assert.True(response.Headers.Contains("Total-Products"));
            }
        }


        [Fact]
        public async Task Test_Get_Product_Should_Return_Header_Filter_Scope_Controller()
        {
            using (var client = new TestClientProvider().Client)
            {
                var response = await client.GetAsync("/api/products/1");
                response.EnsureSuccessStatusCode();
                Assert.True(response.Headers.Contains("Filter-Attribute-Header"));
            }
        }


        [Fact]
        public async Task Test_Get_All_Products_Should_Return_Header_Filter_Scope_Action()
        {
            using (var client = new TestClientProvider().Client)
            {
                var response = await client.GetAsync("/api/products");
                response.EnsureSuccessStatusCode();
                var responseString = await response.Content.ReadAsStringAsync();
                var products = JsonConvert.DeserializeObject<List<Product>>(responseString);
                Assert.True(response.Headers.Contains("Filter-Other-Attribute-Header"));
            }
        }

        [Fact]
        public async Task Test_Get_All_Products_Should_Return_Header_Middleware()
        {
            using (var client = new TestClientProvider().Client)
            {
                var response = await client.GetAsync("/api/products/1");
                response.EnsureSuccessStatusCode();
                Assert.True(response.Headers.Contains("Middleware-Response-Header"));
            }
        }


    }
}
