namespace AutomaticRegistrationOfMinimalAPIsTests;

public class StudentEndpointTests(WebApplicationFactory<Program> factory)
    : IClassFixture<WebApplicationFactory<Program>>
{
    private readonly JsonSerializerOptions _options = new()
    {
        PropertyNameCaseInsensitive = true
    };

    [Fact]
    public async Task WhenGetStudentsEndpointIsInvoked_ThenAllStudentsAreReturned()
    {
        // Arrange
        var client = factory.CreateClient();

        // Act
        var result = await client.GetAsync("/students");

        // Assert
        result.StatusCode.Should().Be(HttpStatusCode.OK);
    }

    [Fact]
    public async Task WhenGetStudentEndpointIsInvoked_ThenStudentIsReturned()
    {
        // Arrange
        var client = factory.CreateClient();
        var student = new StudentForCreationDto
        {
            Name = "Test",
            Age = 1
        };

        var response = await client.PostAsJsonAsync("/students", student);
        var createdStudent = JsonSerializer.Deserialize<StudentDto>(
            await response.Content.ReadAsStringAsync(),
            _options);

        // Act
        var result = await client.GetAsync($"/students/{createdStudent!.Id}");
        var returnedStudent = JsonSerializer.Deserialize<StudentDto>(
            await result.Content.ReadAsStringAsync(), _options);

        // Assert
        result.StatusCode.Should().Be(HttpStatusCode.OK);
        returnedStudent.Should().NotBeNull();
        returnedStudent!.Name.Should().Be(student.Name);
        returnedStudent.Age.Should().Be(student.Age);
    }

    [Fact]
    public async Task WhenAddStudentEndpointIsInvoked_ThenStudentIsAdded()
    {
        // Arrange
        var client = factory.CreateClient();
        var student = new StudentForCreationDto
        {
            Name = "Test",
            Age = 1
        };

        // Act
        var response = await client.PostAsJsonAsync("/students", student);

        // Assert
        response.StatusCode.Should().Be(HttpStatusCode.Created);
    }

    [Fact]
    public async Task WhenUpdateStudentEndpointIsInvoked_ThenStudentIsUpdated()
    {
        // Arrange
        var client = factory.CreateClient();
        var student = new StudentForCreationDto
        {
            Name = "Foo",
            Age = 1
        };
        var createdStudentResponse = await client.PostAsJsonAsync("/students", student);
        var createdStudent = JsonSerializer.Deserialize<StudentDto>(
            await createdStudentResponse.Content.ReadAsStringAsync(),
            _options);
        var studentForUpdate = new StudentForUpdateDto
        {
            Name = "Bar",
            Age = 2
        };

        // Act
        await client.PutAsJsonAsync($"/students/{createdStudent!.Id}", studentForUpdate);

        // Assert
        var updatedStudentResponse = await client.GetAsync($"/students/{createdStudent!.Id}");
        var updatedStudent = JsonSerializer.Deserialize<StudentDto>(
            await updatedStudentResponse.Content.ReadAsStringAsync(), _options);

        updatedStudentResponse.StatusCode.Should().Be(HttpStatusCode.OK);
        updatedStudent!.Should().NotBeNull();
        updatedStudent!.Name.Should().Be(studentForUpdate.Name);
        updatedStudent!.Age.Should().Be(studentForUpdate.Age);
    }

    [Fact]
    public async Task WhenDeleteCatEndpointIsInvoked_ThenCatIsDeleted()
    {
        // Arrange
        var client = factory.CreateClient();
        var student = new StudentForCreationDto
        {
            Name = "Foo",
            Age = 1
        };
        var response = await client.PostAsJsonAsync("/students", student);
        var studentDto = JsonSerializer.Deserialize<StudentDto>(
            await response.Content.ReadAsStringAsync(),
            _options);

        // Act
        var result = await client.DeleteAsync($"/students/{studentDto!.Id}");

        // Assert
        result.StatusCode.Should().Be(HttpStatusCode.NoContent);
    }
}