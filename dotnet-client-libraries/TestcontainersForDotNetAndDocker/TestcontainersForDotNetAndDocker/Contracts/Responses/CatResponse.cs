namespace TestcontainersForDotNetAndDocker.Contracts.Responses;

public record CatResponse(Guid Id, string Name, int Age, double Weight);
