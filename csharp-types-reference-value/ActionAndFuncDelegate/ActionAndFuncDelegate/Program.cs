// See https://aka.ms/new-console-template for more information

using System;
namespace DelegateApplication;


public class DelegateExamples
{
  public static string DelegateMethod(int previousAmount, int currentAmount)
  {
        return $"Amount difference is {currentAmount - previousAmount}";
  }
}

public class FuncAndActionDelegateExamples
{
  public static string FuncDelegateMethod(int previousAmount, int currentAmount)
  {
        return  $"Amount difference is {currentAmount - previousAmount}";
  }

  public static void ActionDelegateMethod(int previousAmount, int currentAmount)
  {
       Console.WriteLine($"Amount difference is {currentAmount - previousAmount}");
  }
}


public delegate string OurDelegate(int previousAmount, int currentAmount);

public class Program
{
    static void Main(string[] args)
    {
      //DELEGATE
      // Creating an instance of OurDelegate 
      OurDelegate instanceOfOurDelegate = DelegateExamples.DelegateMethod; 
      instanceOfOurDelegate.Invoke(3000, 500); 


      // FUNC DELEGATE
      Func<int, int, string> instanceOfFuncDelegate = FuncAndActionDelegateExamples.FuncDelegateMethod;
      string returnValue = instanceOfFuncDelegate.Invoke(500, 540); 
      Console.WriteLine(returnValue);
       
      //  OR 

       // using arrow function approach 
      Func<int, int, string> instanceOfFuncDelegateArrowFunction = (int currentAmount, int previousAmount) 
          => $"Amount difference is {currentAmount - previousAmount}"; 
      string returnValueArrowFunction = instanceOfFuncDelegateArrowFunction.Invoke(500, 540); 
      Console.WriteLine(returnValueArrowFunction);


       // ACTION DELEGATES
       Action<int, int> instanceOfActionDelegate = FuncAndActionDelegateExamples.ActionDelegateMethod; 
       instanceOfActionDelegate.Invoke(500, 550);
    }
}