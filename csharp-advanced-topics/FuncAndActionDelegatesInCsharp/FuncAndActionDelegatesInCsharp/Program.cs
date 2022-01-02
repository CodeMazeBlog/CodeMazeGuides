using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace FuncAndActionDelegatesInCsharp
{
    public class Program
    {

        public static double calculatePercentage(int value, int total) { return (double)value / total * 100; }
        public static void printPercentage(double value, int total) { Console.WriteLine(String.Format("{0}% out {1}.", value, total)); }

        static void Main(string[] args)
        {


            //case1 : Func and Action delegates
            Func<int, int, double> getpercentageResult = calculatePercentage;
            Action<double, int> printPercentageresult = printPercentage;
            var percentageResult = getpercentageResult(75, 80);

            printPercentageresult(percentageResult, 80);


            //case2 : Func and Action delegates with anonymous function
            Func<int, int, double> percentageByAnonymous = delegate (int value, int total) { return (double)value / total * 100; };
            Action<double, int> printPercentageByAnonymous = delegate (double result, int total) { Console.WriteLine(String.Format("{0}% out {1} by Anonymous.", result, total)); };
            var percentageResultByAnonymous = percentageByAnonymous(75, 80);
            printPercentageByAnonymous(percentageResultByAnonymous, 75);


            //case3 : Func and Action delegateswith lambda expression
            Func<int, int, double> calculatePercentageByLamda = (value, total) => (double)value / total * 100;
            Action<double, int> printPercentageByLamda = (result, total) => Console.WriteLine(String.Format("{0}% out {1} by lambda.", result, total));
            var percentageResultBylambda = calculatePercentageByLamda(75, 80);
            printPercentageByLamda(percentageResultBylambda, 80);


            //case 4 :  Func in Linq Expression  for creating Dynamic Where clauses 
            var search1 = Employee.searchByNameOrAge(Employee.getEmployeeList(), name: "Jac");
            var search2 = Employee.searchByNameOrAge(Employee.getEmployeeList(), age: 35);
            var search3 = Employee.searchByNameOrAge(Employee.getEmployeeList(), "Jac", 35);
            Console.WriteLine(String.Format("List Contain {0} employee whose name start with \"Jac\".", search1.Count()));
            Console.WriteLine(String.Format("List Contain {0} employee age greater than 35.", search2.Count()));
            Console.WriteLine(String.Format("List Contain {0} employee age greater than 35 and whose name start with \"Jac\".", search3.Count()));
            Console.ReadLine();
        }

     
    }

}
