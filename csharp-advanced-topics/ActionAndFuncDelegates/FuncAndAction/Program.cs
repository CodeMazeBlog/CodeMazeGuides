using FuncAndAction;

partial class Program
{
    static void Main(string[] args)
    {
        new DelegateExample().Run();
        new MulticastDelegateExample().Run();
        new ActionExample().Run();
        new FuncExample().Run();
        new ListWithActionExample().Run();
    }
}


