namespace ActionPredikateandFuncExample
{
  internal class ActionDelegate
  {
    public static void Execute()
    {
      var actionDelegate = new ActionDelegate();
      actionDelegate.show();
    }

    protected void show()
    {
      worker(oddNumbers, (num) => Console.WriteLine($"{num} IS devisible by 2!"));
    }

    protected void worker(Action<int> onOddNumber, Action<int> onEvenNumber)
    {
      for (int i = 1; i < 5; i++)
      {
        if (i % 2 == 0)
          onEvenNumber(i);
        else
          onOddNumber(i);
      }
    }

    protected void oddNumbers(int number)
    {
      Console.WriteLine($"{number} IS NOT devisible by 2!");
    }
  }
}
