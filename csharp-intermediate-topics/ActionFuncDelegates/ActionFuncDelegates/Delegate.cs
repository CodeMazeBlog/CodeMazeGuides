namespace ActionFuncDelegates;

public partial class Delegate
{
  // Declaration
  public delegate void MyDelegate(string msg);

  public void Run()
  {
    // Initialization
    var del = Sample.Method;
    // Invocation
    del("Hello");

    // Initialization
    del = (string msg) => Console.WriteLine("[Lambda expression]: " + msg);
    // Invocation
    del("Hello");
  }

  class Sample
  {
    public static void Method(string message)
    {
      Console.WriteLine($"[Sample -> Method]: {message}");
    }
  }
}