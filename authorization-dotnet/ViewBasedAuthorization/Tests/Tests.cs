using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Security.Claims;
using ViewBasedAuthorization.Data;
using ViewBasedAuthorization.Pages;

namespace Tests;

public class Tests
{
    [Fact]
    public async Task GivenIndexPage_WhenRoleAdmin_ThenDisplayDocuments()
    {
        var serviceProvider = new ServiceCollection()
            .AddAuthorization()
            .AddLogging()
            .BuildServiceProvider();

        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.Role, "Admin")
        };

        var identity = new ClaimsIdentity(claims, "TestAuthType");
        var claimsPrincipal = new ClaimsPrincipal(identity);

        var context = new DefaultHttpContext
        {
            User = claimsPrincipal
        };

        var pageContext = new PageContext
        {
            HttpContext = context
        };

        var connection = new SqliteConnection("DataSource=:memory:");
        connection.Open();

        try
        {
            var options = new DbContextOptionsBuilder<DocumentContext>()
                        .UseSqlite(connection)
                        .Options;

            using var documentContext = new DocumentContext(options);
            documentContext.Database.EnsureCreated();

            var mockDocs = new List<ViewBasedAuthorization.Models.Document>
            {
                new ViewBasedAuthorization.Models.Document {  Id = 45, Title = "Doc 1", Content = "Details of Doc 1" },
                new ViewBasedAuthorization.Models.Document {  Id = 46, Title = "Doc 2", Content = "Details of Doc 2" },
            };

            documentContext.Documents.AddRange(mockDocs);
            documentContext.SaveChanges();

            var model = new IndexModel(documentContext,
                                       serviceProvider.GetRequiredService<IAuthorizationService>())
            {
                PageContext = pageContext
            };

            model.OnGet();

            Assert.NotNull(model.Documents);

            Assert.Equal(2, model.Documents.Count);

            Assert.True(model.HttpContext.User.IsInRole("Admin"));

        }
        finally
        {
            connection.Close();
        }

    }
}