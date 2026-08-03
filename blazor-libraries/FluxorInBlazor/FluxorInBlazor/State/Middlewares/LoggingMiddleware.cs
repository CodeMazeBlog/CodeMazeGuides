using Fluxor;

namespace FluxorInBlazor.State.Middlewares;

public class LoggingMiddleware : Middleware
{
    public override void BeforeDispatch(object action)
    {
        Console.WriteLine($"Before dispatching action {action.GetType().Name}");
    }
}