namespace ActionPredikateandFuncExample
{
  internal class DisplayCorrectTypes
  {
    public void Test()
    {
      var variable = 5;
      var variable1 = TestFunction1;
      var variable2 = TestFunction2;
      var variable3 = TestFunction3;

      variable1();
      variable2(variable);
      variable3(1, "test");
    }

    private void TestFunction1()
    {
      Console.WriteLine("Test function1");
    }

    private void TestFunction2(int number)
    {
      Console.WriteLine($"Test function2 with paramer {number}");
    }

    private void TestFunction3(int number, string text)
    {
      Console.WriteLine($"Test function2 with paramers {number} and {text}");
    }
  }
}
