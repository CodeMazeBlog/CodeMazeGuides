namespace TestcontainersForDotNetAndDocker.Contracts.Responses;

public record GetAllCatsResponse(IEnumerable<CatResponse> Cats);
