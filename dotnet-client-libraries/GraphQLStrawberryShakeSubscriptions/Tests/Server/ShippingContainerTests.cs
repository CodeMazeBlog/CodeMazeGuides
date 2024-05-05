using FluentAssertions;
using Snapshooter.Xunit;

namespace Tests.Server;
public class ShippingContainerTests
{
    [Fact]
    public async Task ShippingContainer_Schema_Changed()
    {
        // Arrange
        // Act
        var schema = await TestServices.Executor.GetSchemaAsync(default);

        // Assert
        schema.ToString().Should().MatchSnapshot();
    }

    [Fact]
    public async Task ShippingContainer_AddAvaliableShippingContainerAsync()
    {
        // Arrange
        // Act
        var result = await TestServices.ExecuteRequestAsync(
            b => b.SetQuery(@"
                mutation AddAvaliableShippingContainer {
                    addAvaliableShippingContainer(input: {
                        name: ""Container 1"",
                        length: 10,
                        width: 10,
                        height: 10
                    }) 
                    {
                        shippingContainer {
                            id
                            name
                            space {
                                length
                                width
                                height
                            }
                        }
                    }
                }"));

        // Assert
        result.Should().MatchSnapshot();
    }

    [Fact]
    public async Task ShippingContainer_UpdateShippingContainerAsync()
    {
        // Arrange
        await TestServices.ExecuteRequestAsync(
            b => b.SetQuery(@"
                mutation AddAvaliableShippingContainer {
                    addAvaliableShippingContainer(input: {
                        name: ""Container 2"",
                        length: 10,
                        width: 10,
                        height: 10
                    }) 
                    {
                        shippingContainer {
                            id
                            name
                            space {
                                length
                                width
                                height
                            }
                        }
                    }
                }"));

        // Act
        var result = await TestServices.ExecuteRequestAsync(
            b => b.SetQuery(@"
                mutation UpdateShippingContainer {
                    updateShippingContainer(input: {
                        name: ""Container 2"",
                        length: 20,
                        width: 20,
                        height: 20
                    }) 
                    {
                        shippingContainer {
                            id
                            name
                            space {
                                length
                                width
                                height
                            }
                        }
                    }
                }"));

        // Assert
        result.Should().MatchSnapshot();
    }

    [Fact]
    public async Task ShippingContainer_GetShippingContainersAsync()
    {
        // Arrange
        await TestServices.ExecuteRequestAsync(
            b => b.SetQuery(@"
                mutation AddAvaliableShippingContainer {
                    addAvaliableShippingContainer(input: {
                        name: ""Container 3"",
                        length: 10,
                        width: 10,
                        height: 10
                    }) 
                    {
                        shippingContainer {
                            id
                            name
                            space {
                                length
                                width
                                height
                            }
                        }
                    }
                }"));

        // Act
        var result = await TestServices.ExecuteRequestAsync(
            b => b.SetQuery(@"
                query GetShippingContainers {
                    shippingContainers {
                        id
                        name
                        space {
                            length
                            width
                            height
                        }
                    }
                }"));

        // Assert
        result.Should().MatchSnapshot();
    }
}