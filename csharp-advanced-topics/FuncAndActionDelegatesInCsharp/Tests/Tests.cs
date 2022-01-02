using FuncAndActionDelegatesInCsharp;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;


namespace Tests
{
    [TestClass]
    public class Tests
    {
        StringWriter printWriter = new StringWriter();
        public static double calculatePercentage(int value, int total) { return (double)value / total * 100; }
        public static void printPercentage(double value, int total) { Console.WriteLine(String.Format("{0}% out {1}.", value, total)); }

        [TestMethod]
        public void getPercentageResultAndPrint_FuncAndActionExecuteTheReferenceMethod()
        {

            Func<int, int, double> getpercentageResult = calculatePercentage;
            var percentageResult = getpercentageResult(75, 80);
            Assert.AreEqual(93.75, percentageResult);

            Action<double, int> printPercentageresult = printPercentage;
            Console.SetOut(printWriter);
            printPercentageresult(percentageResult, 80);
            var printResult = printWriter.ToString().Trim();
            Assert.AreEqual("93.75% out 80.", printResult);
        }

        [TestMethod]
        public void getPercentageResultAndPrint_FuncAndActionByAnonymousMethod()
        {

            Func<int, int, double> percentageByAnonymous = delegate (int value, int total)
            {
                return (double)value / total * 100;
            };
            var percentageResultByAnonymous = percentageByAnonymous(75, 80);
            Assert.AreEqual(93.75, percentageResultByAnonymous);

            Action<double, int> printPercentageByAnonymous = delegate (double result, int total)
            {
                Console.WriteLine(String.Format("{0}% out {1} by Anonymous.", result, total));
            };
            Console.SetOut(printWriter);
            printPercentageByAnonymous(percentageResultByAnonymous, 80);
            var printResult = printWriter.ToString().Trim();
            Assert.AreEqual("93.75% out 80 by Anonymous.", printResult);
        }

        [TestMethod]
        public void getPercentageResultAndPrint_FuncAndActionByLambda()
        {

            Func<int, int, double> calculatePercentageByLamda = (value, total) => (double)value / total * 100;
            Action<double, int> printPercentageByLamda = (result, total) => Console.WriteLine(String.Format("{0}% out {1} by lambda.", result, total));
            var percentageResultBylambda = calculatePercentageByLamda(75, 80);
            Assert.AreEqual(93.75, percentageResultBylambda);

            Console.SetOut(printWriter);
            printPercentageByLamda(percentageResultBylambda, 80);
            var printResult = printWriter.ToString().Trim();
            Assert.AreEqual("93.75% out 80 by lambda.", printResult);
        }

        [TestMethod]
        public void searchByName_FuncExpressionEvaluateWhereWithName()
        {
            var search1 = Employee.searchByNameOrAge(Employee.getEmployeeList(), name: "Jac");
            Assert.AreEqual(2, search1.Count);
        }

        [TestMethod]
        public void searchByAgeGreaterThan_FuncExpressionEvaluateWhereWithName()
        {
            var search2 = Employee.searchByNameOrAge(Employee.getEmployeeList(), age: 35);
            Assert.AreEqual(4, search2.Count);
        }

        [TestMethod]
        public void searchByNameAndAgeGreaterThan_FuncExpressionEvaluateWhereWithName()
        {
            var search3 = Employee.searchByNameOrAge(Employee.getEmployeeList(), "Jac", 35);
            Assert.AreEqual(1, search3.Count);
        }


    }
}
