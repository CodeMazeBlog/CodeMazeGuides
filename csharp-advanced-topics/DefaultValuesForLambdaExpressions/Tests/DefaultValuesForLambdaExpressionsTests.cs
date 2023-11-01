namespace Tests;

public class DefaultValuesForLambdaExpressionsTests
{
    private readonly WebApplicationFactory<Program> _application;
    private readonly HttpClient _client;

    public DefaultValuesForLambdaExpressionsTests()
    {
        _application = new WebApplicationFactory<Program>();
        _client = _application.CreateClient();
    }

    [Fact]
    public async void GivenANewTodoItem_WhenTheDescriptionIsNotProvided_ThenUseTheDefault()
    {
        var content = new StringContent("",
            System.Text.Encoding.UTF8,
            MediaTypeHeaderValue.Parse("application/json; charset=utf-8 ").MediaType!);

        using var response = await _client.PostAsync("/item?title=Title", content);

        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    }

    [Fact]
    public async void GivenANewTodoItem_WhenTheDescriptionIsProvided_ThenUseItOnCreatingTodoItem()
    {
        var content = new StringContent("",
            System.Text.Encoding.UTF8,
            MediaTypeHeaderValue.Parse("application/json; charset=utf-8 ").MediaType!);

        using var response = await _client.PostAsync("/item?title=Title&description=My%20description", content);

        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    }

    [Fact]
    public async void GivenATodoItem_WhenPutNewTags_ThenUpdateAndSaveItem()
    {
        var options = new DbContextOptionsBuilder<ApiDbContext>()
            .UseInMemoryDatabase(databaseName: "items")
            .Options;
        
        using (var context = new ApiDbContext(options))
        {
            context.TodoItems.Add(new TodoItem()
            {
                Title = "Title",
                Description = "Description",
                Id = 5
            });
            context.SaveChanges();
        }

        var data = new string(""" ["science", "human body"] """);

        var content = new StringContent(data,
            System.Text.Encoding.UTF8,
            MediaTypeHeaderValue.Parse("application/json; charset=utf-8 ").MediaType!);

        using var response = await _client.PutAsync("/updateTags?id=5", content);

        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    }
}