namespace ActionFuncDelegates;

public partial class Delegate
{
  public delegate double GetTotal(int count);

  private double FetchTotal(int freq)
  {
    return freq * 5.5;
  }

  public void FuncRun()
  {
    GetTotal funcDel = FetchTotal;
    var result = funcDel(3);
    Console.WriteLine($"[Delegate -> FetchTotal]: {result}");
  }
}

public class FuncDelegate
{
  private double FetchTotal(int freq)
  {
    return freq * 5.5;
  }

  public void Run()
  {
    var funcDel = FetchTotal;
    var result = funcDel(3);
    Console.WriteLine($"[Func -> FetchTotal]: {result}");
  }
}