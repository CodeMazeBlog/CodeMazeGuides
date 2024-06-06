using AutoMapperIgnoreProperty;

namespace AutoMapperIgnorePropertyTests;

[TestClass]
public class MappersTests
{
    [TestMethod]
    public void GivenSensitiveProperties_WhenExecutingMap_ThenPasswordAndIsAdminShouldBeIgnored()
    {
        // Arrange
        var user = new User
        {
            Id = 1,
            Email = "user01@codemaze.com",
            CreatedAt = DateTime.Now,
            Password = "Password123!",
            IsAdmin = true
        };

        var mapper = MapperHelper.GetMapperIgnoringSensitiveProperties();

        // Act
        var userDto = mapper.Map<UserDto>(user);

        // Assert
        Assert.AreEqual(user.Id, userDto.Id);
        Assert.IsNull(userDto.Password);
        Assert.IsFalse(userDto.IsAdmin);
        Assert.AreEqual(user.CreatedAt, userDto.CreatedAt);
    }

    [TestMethod]
    public void GivenSensitivePropertiesMarkedWithAttribute_WhenExecutingMap_ThenPasswordAndIsAdminShouldBeIgnored()
    {
        // Arrange
        var user = new User
        {
            Id = 1,
            Email = "user01@codemaze.com",
            CreatedAt = DateTime.Now,
            Password = "Password123!",
            IsAdmin = true
        };

        var mapper = MapperHelper.GetMapperIgnoringSensitivePropertiesWithAttribute();

        // Act
        var userDetailsDto = mapper.Map<UserDetailsDto>(user);

        // Assert
        Assert.AreEqual(user.Id, userDetailsDto.Id);
        Assert.AreEqual(user.Email, userDetailsDto.Email);
        Assert.IsNull(userDetailsDto.Password);
        Assert.IsFalse(userDetailsDto.IsAdmin);
        Assert.AreEqual(user.CreatedAt, userDetailsDto.CreatedAt);
    }

    [TestMethod]
    public void GivenMapperIgnoringSourceMembers_WhenExecutingMap_ThenEmailValidationShouldBeIgnored()
    {
        // Arrange
        var user = new User
        {
            Id = 1,
            Email = "user01@codemaze.com",
            CreatedAt = DateTime.Now,
            Password = "Password123!",
            IsAdmin = true
        };

        var mapper = MapperHelper.GetMapperIgnoringSourceMembers();

        // Act
        var userDto = mapper.Map<UserDto>(user);

        // Assert
        Assert.AreEqual(user.Id, userDto.Id);
        Assert.AreEqual(user.CreatedAt, userDto.CreatedAt);
    }
}