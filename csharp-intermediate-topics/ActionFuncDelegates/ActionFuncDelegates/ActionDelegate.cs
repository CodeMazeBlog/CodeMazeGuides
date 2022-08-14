namespace ActionFuncDelegates;

public partial class Delegate
{
  public delegate void Price(double price);

  void ConsolePrice(double price)
  {
    Console.WriteLine($"[Delegate -> ConsolePrice]: {price}");
  }

  public void ActionRun()
  {
    Price del = ConsolePrice;
    del(5.99);
  }
}

public class ActionDelegate
{
  void ConsolePrice(double price)
  {
    Console.WriteLine($"[Action -> ConsolePrice]: {price}");
  }

  public void Run()
  {
    Action<double> actionDel = ConsolePrice;
    actionDel(5.99);
  }
}