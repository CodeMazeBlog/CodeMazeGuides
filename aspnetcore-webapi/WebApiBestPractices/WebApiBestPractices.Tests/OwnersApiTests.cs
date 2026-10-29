using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using WebApiBestPractices.Application.Dtos;
using WebApiBestPractices.Domain.Contracts;
using WebApiBestPractices.Domain.Entities;
using WebApiBestPractices.Infrastructure.Repositories;

namespace WebApiBestPractices.Tests;

public class OwnersApiTests
{
    private static CancellationToken Ct => TestContext.Current.CancellationToken;

    [Fact]
    public async Task GetOwners_ReturnsSeededOwners_AndReportsApiVersions()
    {
        await using var factory = new WebApplicationFactory<Program>();
        var client = factory.CreateClient();

        var response = await client.GetAsync("/api/owners", Ct);
        var owners = await response.Content.ReadFromJsonAsync<List<OwnerDto>>(Ct);

        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        Assert.Equal(2, owners!.Count);
        Assert.Contains("1.0", response.Headers.GetValues("api-supported-versions").Single());
    }

    [Fact]
    public async Task GetOwners_WithApiVersion2_ReturnsNamesOnly()
    {
        await using var factory = new WebApplicationFactory<Program>();
        var client = factory.CreateClient();

        var names = await client.GetFromJsonAsync<List<string>>("/api/owners?api-version=2.0", Ct);

        Assert.Equal(["Anna Bosh", "John Keen"], names);
    }

    [Fact]
    public async Task GetOwnerById_UnknownId_Returns404ProblemDetails()
    {
        await using var factory = new WebApplicationFactory<Program>();
        var client = factory.CreateClient();

        var response = await client.GetAsync($"/api/owners/{Guid.NewGuid()}", Ct);

        Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
        Assert.Equal("application/problem+json", response.Content.Headers.ContentType?.MediaType);
    }

    [Fact]
    public async Task CreateOwner_InvalidBody_Returns400ValidationProblem()
    {
        await using var factory = new WebApplicationFactory<Program>();
        var client = factory.CreateClient();

        var response = await client.PostAsJsonAsync("/api/owners", new { Name = "", Email = "not-an-email" }, Ct);
        var problem = await response.Content.ReadFromJsonAsync<ValidationProblemDetails>(Ct);

        Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        Assert.Contains("Email", problem!.Errors.Keys);
    }

    [Fact]
    public async Task CreateOwner_DuplicateEmail_Returns409FromExceptionHandler()
    {
        await using var factory = new WebApplicationFactory<Program>();
        var client = factory.CreateClient();

        var response = await client.PostAsJsonAsync("/api/owners",
            new OwnerForCreationDto { Name = "John Again", Email = "john@example.com" }, Ct);
        var problem = await response.Content.ReadFromJsonAsync<ProblemDetails>(Ct);

        Assert.Equal(HttpStatusCode.Conflict, response.StatusCode);
        Assert.Equal("The owner already exists.", problem!.Title);
    }

    [Fact]
    public async Task UnhandledException_Returns500ProblemDetails_WithoutExceptionMessage()
    {
        await using var factory = new WebApplicationFactory<Program>().WithWebHostBuilder(builder =>
        {
            builder.UseEnvironment("Production");
            builder.UseSetting("JwtSettings:SecretKey", "test-only-key-0123456789abcdef0123456789");
            builder.ConfigureTestServices(services =>
                services.AddSingleton<IOwnerRepository, ThrowingOwnerRepository>());
        });
        var client = factory.CreateClient();

        var response = await client.GetAsync("/api/owners", Ct);
        var body = await response.Content.ReadAsStringAsync(Ct);

        Assert.Equal(HttpStatusCode.InternalServerError, response.StatusCode);
        Assert.Equal("application/problem+json", response.Content.Headers.ContentType?.MediaType);
        Assert.DoesNotContain("database is on fire", body);
    }

    [Fact]
    public async Task DeleteOwner_RequiresAValidJwt()
    {
        await using var factory = new WebApplicationFactory<Program>();
        var client = factory.CreateClient();
        var url = $"/api/owners/{InMemoryOwnerRepository.AnnaId}";

        var anonymous = await client.DeleteAsync(url, Ct);

        client.DefaultRequestHeaders.Authorization =
            new AuthenticationHeaderValue("Bearer", CreateToken(factory.Services.GetRequiredService<IConfiguration>()));
        var authenticated = await client.DeleteAsync(url, Ct);

        Assert.Equal(HttpStatusCode.Unauthorized, anonymous.StatusCode);
        Assert.Equal(HttpStatusCode.NoContent, authenticated.StatusCode);
    }

    [Fact]
    public async Task UpdateOwner_UnknownId_Returns404FromActionFilter()
    {
        await using var factory = new WebApplicationFactory<Program>();
        var client = factory.CreateClient();

        var response = await client.PutAsJsonAsync($"/api/owners/{Guid.NewGuid()}",
            new OwnerForUpdateDto { Name = "Nobody" }, Ct);

        Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
    }

    [Fact]
    public async Task ContentNegotiation_ReturnsXml_AndRejectsUnknownFormats()
    {
        await using var factory = new WebApplicationFactory<Program>();
        var client = factory.CreateClient();

        var xmlRequest = new HttpRequestMessage(HttpMethod.Get, "/api/owners");
        xmlRequest.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/xml"));
        var xml = await client.SendAsync(xmlRequest, Ct);

        var csvRequest = new HttpRequestMessage(HttpMethod.Get, $"/api/owners/{InMemoryOwnerRepository.JohnId}");
        csvRequest.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("text/csv"));
        var csv = await client.SendAsync(csvRequest, Ct);

        Assert.Equal("application/xml", xml.Content.Headers.ContentType?.MediaType);
        Assert.Contains("<OwnerDto>", await xml.Content.ReadAsStringAsync(Ct));
        Assert.Equal(HttpStatusCode.NotAcceptable, csv.StatusCode);
    }

    [Fact]
    public async Task RateLimiter_Returns429_WhenThePermitLimitIsUsedUp()
    {
        await using var factory = new WebApplicationFactory<Program>()
            .WithWebHostBuilder(builder => builder.UseSetting("RateLimiting:PermitLimit", "2"));
        var client = factory.CreateClient();
        var url = $"/api/owners/{InMemoryOwnerRepository.JohnId}";

        var first = await client.GetAsync(url, Ct);
        var second = await client.GetAsync(url, Ct);
        var third = await client.GetAsync(url, Ct);

        Assert.Equal(HttpStatusCode.OK, first.StatusCode);
        Assert.Equal(HttpStatusCode.OK, second.StatusCode);
        Assert.Equal(HttpStatusCode.TooManyRequests, third.StatusCode);
    }

    [Fact]
    public async Task OutputCache_IsEvicted_WhenAnOwnerIsCreated()
    {
        await using var factory = new WebApplicationFactory<Program>();
        var client = factory.CreateClient();

        var before = await client.GetFromJsonAsync<List<OwnerDto>>("/api/owners", Ct);
        await client.PostAsJsonAsync("/api/owners",
            new OwnerForCreationDto { Name = "Mia Stone", Email = "mia@example.com" }, Ct);
        var after = await client.GetFromJsonAsync<List<OwnerDto>>("/api/owners", Ct);

        Assert.Equal(2, before!.Count);
        Assert.Equal(3, after!.Count);
    }

    [Fact]
    public async Task OutputCache_KeepsJsonAndXmlApart()
    {
        await using var factory = new WebApplicationFactory<Program>();
        var client = factory.CreateClient();

        var xmlRequest = new HttpRequestMessage(HttpMethod.Get, "/api/owners");
        xmlRequest.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/xml"));
        var xml = await client.SendAsync(xmlRequest, Ct);
        var json = await client.GetAsync("/api/owners", Ct);

        Assert.Equal("application/xml", xml.Content.Headers.ContentType?.MediaType);
        Assert.Equal("application/json", json.Content.Headers.ContentType?.MediaType);
    }

    [Fact]
    public async Task OpenApiDocument_IsServedInDevelopment_AsOpenApi31()
    {
        await using var factory = new WebApplicationFactory<Program>();
        var client = factory.CreateClient();

        var response = await client.GetAsync("/openapi/v1.json", Ct);
        var document = await response.Content.ReadAsStringAsync(Ct);

        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        Assert.Contains("\"openapi\": \"3.1", document);
        Assert.Contains("/api/owners", document);
    }

    [Fact]
    public async Task MinimalApiEndpoint_ReturnsTheSameOwners()
    {
        await using var factory = new WebApplicationFactory<Program>();
        var client = factory.CreateClient();

        var owners = await client.GetFromJsonAsync<List<OwnerDto>>("/api/minimal/owners", Ct);

        Assert.Equal(2, owners!.Count);
    }

    [Fact]
    public async Task Upload_ReadsTheFormAsynchronously_AndStoresTheFile()
    {
        var uploadFolder = Path.Combine(AppContext.BaseDirectory, "uploads-test");
        await using var factory = new WebApplicationFactory<Program>()
            .WithWebHostBuilder(builder => builder.UseSetting("Uploads:Path", uploadFolder));
        var client = factory.CreateClient();

        using var content = new MultipartFormDataContent();
        content.Add(new ByteArrayContent(Encoding.UTF8.GetBytes("hello")), "file", "hello.txt");
        var response = await client.PostAsync("/api/files", content, Ct);

        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        Assert.Single(Directory.GetFiles(uploadFolder));
        Directory.Delete(uploadFolder, recursive: true);
    }

    private static string CreateToken(IConfiguration configuration)
    {
        var settings = configuration.GetSection("JwtSettings");
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(settings["SecretKey"]!));
        var token = new JwtSecurityToken(
            issuer: settings["ValidIssuer"],
            audience: settings["ValidAudience"],
            claims: [new System.Security.Claims.Claim("name", "test-user")],
            expires: DateTime.UtcNow.AddMinutes(5),
            signingCredentials: new SigningCredentials(key, SecurityAlgorithms.HmacSha256));

        return new JwtSecurityTokenHandler().WriteToken(token);
    }

    private sealed class ThrowingOwnerRepository : IOwnerRepository
    {
        public Task<IReadOnlyList<Owner>> GetAllAsync(CancellationToken cancellationToken) =>
            throw new InvalidOperationException("The database is on fire.");
        public Task<Owner?> GetByIdAsync(Guid id, CancellationToken cancellationToken) => throw new NotImplementedException();
        public Task<bool> EmailExistsAsync(string email, CancellationToken cancellationToken) => throw new NotImplementedException();
        public Task AddAsync(Owner owner, CancellationToken cancellationToken) => throw new NotImplementedException();
        public Task UpdateAsync(Owner owner, CancellationToken cancellationToken) => throw new NotImplementedException();
        public Task DeleteAsync(Guid id, CancellationToken cancellationToken) => throw new NotImplementedException();
    }
}
