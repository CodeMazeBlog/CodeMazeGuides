using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc.Testing;
using MultiTenantApplication.Api.Controllers;
using MultiTenantApplication.Core;
using MultiTenantApplication.Core.Entities;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace MultiTenantApplication.Tests;

public class InventoryApiClient
{
    private readonly WebApplicationFactory<Program> _api = new();
    private readonly JsonSerializerOptions _options = new(JsonSerializerDefaults.Web);

    private string _token = string.Empty;

    public async Task LoginAsync(User user)
    {
        var client = CreateClient(true);

        var response = await client.PostAsync("auth/login", new JsonContent(user));

        var result = await Json<LoginToken>(response);

        _token = result!.Token;
    }

    public async ValueTask<Goods?> AddAsync(GoodsDto goods)
    {
        var client = CreateClient();

        var response = await client.PostAsync("goods", new JsonContent(goods));

        return await Json<Goods>(response);
    }

    public async ValueTask<Goods?> GetAsync(string goodsName)
    {
        var client = CreateClient();

        var response = await client.GetStreamAsync($"goods/{goodsName}");

        return await Json<Goods>(response);
    }

    public async ValueTask<List<Goods>?> GetListAsync()
    {
        var client = CreateClient();

        var response = await client.GetStreamAsync("goods/list");

        return await Json<List<Goods>>(response);
    }

    HttpClient CreateClient(bool anonymous = false)
    {
        var client = _api.CreateClient();

        if (!anonymous)
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(JwtBearerDefaults.AuthenticationScheme, _token);

        return client;
    }

    async ValueTask<T?> Json<T>(HttpResponseMessage message)
    {
        var stream = await message.Content.ReadAsStreamAsync();

        return await Json<T>(stream);
    }

    async ValueTask<T?> Json<T>(Stream stream)
    {
        return await JsonSerializer.DeserializeAsync<T>(stream, _options);
    }

    public class JsonContent : StringContent
    {
        public JsonContent(object? obj) :
            base(obj is null ? string.Empty : JsonSerializer.Serialize(obj), Encoding.UTF8, "application/json")
        { }
    }

    public record class LoginToken(string Token);
}