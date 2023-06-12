using GoogleSheetsAPI;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Xunit;

namespace GoogleSheetsAPITest.Controllers
{
    public class ItemsControllerLiveTest : IClassFixture<CustomWebApplicationFactory<Startup>>
    {
        private readonly HttpClient _client;

        public ItemsControllerLiveTest(CustomWebApplicationFactory<Startup> factory)
        {
            _client = factory.CreateClient();
        }

        [Fact]
        public async Task WhenInvokingActions_ThenSheetUpdated()
        {
            // Get Items
            var httpResponse = await GetItems();
            httpResponse.EnsureSuccessStatusCode();
            var items = await GetItemsFromResponse(httpResponse);
            var rowCount = items.Count();

            // Insert an Item
            httpResponse = await InsertItem();
            httpResponse.EnsureSuccessStatusCode();
            Assert.Equal(System.Net.HttpStatusCode.Created, httpResponse.StatusCode);

            // Get Items once again and verify the row count
            httpResponse = await GetItems();
            httpResponse.EnsureSuccessStatusCode();
            items = await GetItemsFromResponse(httpResponse);
            Assert.NotEmpty(items);
            var rowCountAfterInsert = items.Count();
            Assert.Equal(rowCount + 1, rowCountAfterInsert);

            // Update Item
            var rowNo = rowCountAfterInsert;
            httpResponse = await UpdateItem(rowNo);
            httpResponse.EnsureSuccessStatusCode();
            Assert.Equal(System.Net.HttpStatusCode.NoContent, httpResponse.StatusCode);

            // Get the updated Item and verify its price
            httpResponse = await ReturnSingleItem(rowNo);
            httpResponse.EnsureSuccessStatusCode();
            var item = await GetSingleItemFromResponse(httpResponse);
            Assert.NotNull(item);
            Assert.Equal("10", item.Price);

            // Delete the Item
            httpResponse = await DeleteItem(rowNo);
            httpResponse.EnsureSuccessStatusCode();
            Assert.Equal(System.Net.HttpStatusCode.NoContent, httpResponse.StatusCode);

            // Get Items once again and verify row count
            httpResponse = await GetItems();
            httpResponse.EnsureSuccessStatusCode();
            items = await GetItemsFromResponse(httpResponse);
            var rowCountAfterDelete = items.Count();
            Assert.Equal(rowCount, rowCountAfterDelete);
        }

        #region Private Methods

        private async Task<HttpResponseMessage> InsertItem()
        {
            return await _client.PostAsJsonAsync("/api/items", new Item
            {
                Id = "104",
                Category = "Seafood",
                Name = "Salmon",
                Price = "9"
            });
        }

        private async Task<HttpResponseMessage> GetItems()
        {
            return await _client.GetAsync("/api/items");
        }

        private async Task<HttpResponseMessage> UpdateItem(int rowNo)
        {
            return await _client.PutAsJsonAsync($"/api/items/{rowNo}", new Item
            {
                Id = "104",
                Category = "Seafood",
                Name = "Salmon",
                Price = "10"
            });
        }

        private async Task<HttpResponseMessage> ReturnSingleItem(int rowNo)
        {
            return await _client.GetAsync($"/api/items/{rowNo}");
        }

        private async Task<HttpResponseMessage> DeleteItem(int rowNo)
        {
            return await _client.DeleteAsync($"/api/items/{rowNo}");
        }

        private static async Task<IEnumerable<Item>> GetItemsFromResponse(HttpResponseMessage httpResponse)
        {
            var stringResponse = await httpResponse.Content.ReadAsStringAsync();
            var items = JsonConvert.DeserializeObject<IEnumerable<Item>>(stringResponse);
            return items;
        }

        private static async Task<Item> GetSingleItemFromResponse(HttpResponseMessage httpResponse)
        {
            var stringResponse = await httpResponse.Content.ReadAsStringAsync();
            var item = JsonConvert.DeserializeObject<Item>(stringResponse);
            return item;
        }

        #endregion
    }
}
