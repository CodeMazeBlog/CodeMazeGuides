namespace ActionAndFuncDelegatesInCSharp;

public static class FuncDelegate
{
   public static double FindRootUsingFuncReferringANamedMethod(double d)
   {
      Func<double, double> findRoot = Math.Sqrt;

      return findRoot(d);
   }
   
   public static double FindRootUsingFuncReferringAnAnonymousMethod(double d)
   {
      Func<double, double> findRoot = delegate(double x)
      {
         return Math.Sqrt(x);
      };

      return findRoot(d);
   }

   public static double FindRootUsingFuncReferringALambdaExpression(double d)
   {
      Func<double, double> findRoot = x => Math.Sqrt(x);

      return findRoot(d);
   }
   
   public static int FindSumByInvokingFuncUsingInvoke(int x, int y)
   {
      Func<int, int, int> findSum = (x, y) => x + y;

      return findSum.Invoke(x, y);
   }
   
   public static List<int> GettingReturnValueOfIndividualFromAMulticastDelegate(int[] marks)
   {
      Func<int[], int> findMax = arr => arr.Max();
      Func<int[], int> findMin = arr => arr.Min();

      Func<int[], int> onClicked = findMax + findMin;

      var results = new List<int>();
      foreach (var @delegate in onClicked.GetInvocationList())
      {
         var func = (Func<int[], int>)@delegate;
         results.Add(func(marks));
      }

      return results;
   }
}