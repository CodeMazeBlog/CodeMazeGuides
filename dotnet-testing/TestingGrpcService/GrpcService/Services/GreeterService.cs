using Grpc.Core;

namespace TestingGrpcService.Services;

public class GreeterService : Greeter.GreeterBase
{
    private readonly ILogger<GreeterService> _logger;
    public GreeterService(ILogger<GreeterService> logger)
    {
        _logger = logger;
    }

    public override Task<HelloReply> SayHello(HelloRequest request, ServerCallContext context)
    {
        var peer = context.Peer;
        _logger.LogInformation("Request from: {peer}", peer);

        return Task.FromResult(new HelloReply { Message = "Hello " + request.Name });
    }
}
