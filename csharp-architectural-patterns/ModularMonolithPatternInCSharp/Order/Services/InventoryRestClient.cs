using Inventory.Models;
using Microsoft.Extensions.Configuration;
using Order.Interfaces;
using System.Net.Http.Json;

namespace Order.Services;

internal class InventoryRestClient(IHttpClientFactory clientFactory, IConfiguration configuration) : IInventoryRestClient
{
    public async Task<ItemDto?> GetItem(Guid id)
    {
        var httpClient = clientFactory.CreateClient();
        httpClient.BaseAddress = new Uri(configuration["BaseAddress"]!);
        var result = await httpClient.GetAsync($"/api/Item/{id}");

        result.EnsureSuccessStatusCode();

        return await result.Content.ReadFromJsonAsync<ItemDto?>();
    }
}
