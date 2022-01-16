using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;


namespace Tests
{
    [TestClass]
    public class FooUnitTest
    {
        [TestMethod]
         public void Main()
        {
            //Tests.FooUnitTest.GetCompleteName("Ricky", "Martin");
            //Tests.FooUnitTest.Percentage_Calculation(320, 500);



            //Func<int, int, decimal> Get_Percentage = Percentage_Calculation;
            //decimal MarksPercent = Get_Percentage(320, 500);
            //Console.WriteLine($"{MarksPercent }");

            //Action Delegate
            
            Action<string, string> Concate = GetCompleteName;
            Concate("Ricky", "Martin");
        }

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


        private const string Fun_Del_Expected = "64.00";
        [TestMethod]
        public static void Func_Delegate_TestMethod()
        {
            
            using (var sw = new StringWriter())
            {
                Console.SetOut(sw);
                var result = sw.ToString().Trim();
                Assert.AreEqual(Fun_Del_Expected, result);
            }
        }


        private const string Action_Del_Expected = "Ricky Martin";
        [TestMethod]
        public static void Action_Delegate_TestMethod()
        {
            using (var sw = new StringWriter())
            {
                Console.SetOut(sw);
                var result = sw.ToString().Trim();
                Assert.AreEqual(Action_Del_Expected, result);
            }
        }

    }
}