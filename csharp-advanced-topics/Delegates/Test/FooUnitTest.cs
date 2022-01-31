using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;

namespace Tests
{
    [TestClass]
    public class FooUnitTest
    {
        private const string Fun_Del_Expected = "64.00";
        
        
        [TestMethod]
        public void call()
        {
            Func<int, int, decimal> Get_Percentage = Percentage_Calculation;
            decimal MarksPercent = Get_Percentage(320, 500);
            Console.WriteLine($"{MarksPercent }");

            //Action Delegate
            // Action<string, string> Concate = Action_Delegates.Action_Delegate_Class.GetCompleteName;
            Action<string, string> Concate = GetCompleteName;
            Concate("Ricky", "Martin ");
        }



        private const string Action_Del_Expected = "Ricky Martin";
        [TestMethod]
        public static void GetCompleteName(string FName, string LName)
        {
            string CompleteName = FName + " " + LName;

            Console.WriteLine($"{CompleteName }");
        }

        [TestMethod]
        public static decimal Percentage_Calculation(int marks, int total)
        {
            return (((decimal)marks / total) * 100);
        }
    }
}