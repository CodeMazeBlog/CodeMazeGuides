namespace AutomaticRegistrationOfMinimalAPIsTests;

public class TeacherEndpointTests(WebApplicationFactory<Program> factory)
    : IClassFixture<WebApplicationFactory<Program>>
{
    private readonly JsonSerializerOptions _options = new()
    {
        PropertyNameCaseInsensitive = true
    };

    [Fact]
    public async Task WhenGetTeachersEndpointIsInvoked_ThenAllTeachersAreReturned()
    {
        // Arrange
        var client = factory.CreateClient();

        // Act
        var result = await client.GetAsync("/teachers");

        // Assert
        result.StatusCode.Should().Be(HttpStatusCode.OK);
    }

    [Fact]
    public async Task WhenGetTeacherEndpointIsInvoked_ThenTeacherIsReturned()
    {
        // Arrange
        var client = factory.CreateClient();
        var teacher = new TeacherForCreationDto
        {
            Name = "Foo",
            Subject = "Bar",
        };

        var response = await client.PostAsJsonAsync("/teachers", teacher);
        var createdTeacher = JsonSerializer.Deserialize<TeacherDto>(
            await response.Content.ReadAsStringAsync(),
            _options);

        // Act
        var result = await client.GetAsync($"/teachers/{createdTeacher!.Id}");
        var returnedTeacher = JsonSerializer.Deserialize<TeacherDto>(
            await result.Content.ReadAsStringAsync(), _options);

        // Assert
        result.StatusCode.Should().Be(HttpStatusCode.OK);
        returnedTeacher.Should().NotBeNull();
        returnedTeacher!.Name.Should().Be(teacher.Name);
        returnedTeacher.Subject.Should().Be(teacher.Subject);
    }

    [Fact]
    public async Task WhenAddTeacherEndpointIsInvoked_ThenTeacherIsAdded()
    {
        // Arrange
        var client = factory.CreateClient();
        var teacher = new TeacherForCreationDto
        {
            Name = "Foo",
            Subject = "Bar",
        };

        // Act
        var response = await client.PostAsJsonAsync("/teachers", teacher);

        // Assert
        response.StatusCode.Should().Be(HttpStatusCode.Created);
    }

    [Fact]
    public async Task WhenUpdateTeacherEndpointIsInvoked_ThenTeacherIsUpdated()
    {
        // Arrange
        var client = factory.CreateClient();
        var teacher = new TeacherForCreationDto
        {
            Name = "Foo",
            Subject = "Bar",
        };
        var createdTeacherResponse = await client.PostAsJsonAsync("/teachers", teacher);
        var createdTeacher = JsonSerializer.Deserialize<TeacherDto>(
            await createdTeacherResponse.Content.ReadAsStringAsync(),
            _options);
        var teacherForUpdate = new TeacherForUpdateDto
        {
            Name = "Bar",
            Subject = "Foo",
        };

        // Act
        await client.PutAsJsonAsync($"/teachers/{createdTeacher!.Id}", teacherForUpdate);

        // Assert
        var updatedTeacherResponse = await client.GetAsync($"/teachers/{createdTeacher!.Id}");
        var updatedTeacher = JsonSerializer.Deserialize<TeacherDto>(
            await updatedTeacherResponse.Content.ReadAsStringAsync(), _options);

        updatedTeacherResponse.StatusCode.Should().Be(HttpStatusCode.OK);
        updatedTeacher!.Should().NotBeNull();
        updatedTeacher!.Name.Should().Be(teacherForUpdate.Name);
        updatedTeacher!.Subject.Should().Be(teacherForUpdate.Subject);
    }

    [Fact]
    public async Task WhenDeleteTeacherEndpointIsInvoked_ThenTeachersIsDeleted()
    {
        // Arrange
        var client = factory.CreateClient();
        var teacher = new TeacherForCreationDto
        {
            Name = "Foo",
            Subject = "Bar",
        };
        var response = await client.PostAsJsonAsync("/teachers", teacher);
        var teacherDto = JsonSerializer.Deserialize<TeacherDto>(
            await response.Content.ReadAsStringAsync(),
            _options);

        // Act
        var result = await client.DeleteAsync($"/teachers/{teacherDto!.Id}");

        // Assert
        result.StatusCode.Should().Be(HttpStatusCode.NoContent);
    }
}
