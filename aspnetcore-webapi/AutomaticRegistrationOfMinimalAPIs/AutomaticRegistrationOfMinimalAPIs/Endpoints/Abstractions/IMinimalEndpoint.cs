namespace AutomaticRegistrationOfMinimalAPIs.Endpoints.Abstractions;

public interface IMinimalEndpoint
{
    void MapRoutes(IEndpointRouteBuilder routeBuilder);
}
