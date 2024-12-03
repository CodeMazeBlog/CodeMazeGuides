namespace ChainOfResponsibilityPattern.Solution.Handlers;

public abstract class HandlerBase : IHandler
{
    protected IHandler? _nextHandler;

    public IHandler SetNext(IHandler nextHandler)
    {
        _nextHandler = nextHandler;

        return _nextHandler;
    }

    public abstract RentalResponse Handle(RentalRequest request);
}