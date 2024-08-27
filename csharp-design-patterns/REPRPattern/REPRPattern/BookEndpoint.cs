using FastEndpoints;

namespace REPRPattern;

public class BookEndpoint : Endpoint<BookEndpointRequest, BookEndpointResponse>
{
    public override void Configure()
    {
        Post("/api/book/create");
        AllowAnonymous();
    }

    public override async Task HandleAsync(BookEndpointRequest request, CancellationToken cancellationToken)
        => await SendAsync(new($"{request.Title} was written by {request.AuthorName}"), cancellation: cancellationToken);
}