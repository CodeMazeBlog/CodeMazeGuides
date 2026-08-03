namespace TestcontainersForDotNetAndDocker.Contracts.Requests;

public record UpdateCatRequest(Guid Id, string Name, int Age, double Weight);
