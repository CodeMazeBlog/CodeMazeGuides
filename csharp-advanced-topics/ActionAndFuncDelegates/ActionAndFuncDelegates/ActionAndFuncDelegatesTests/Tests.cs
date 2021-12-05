using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;

namespace ActionAndFuncDelegatesTests
{
    [TestClass]
    public class Tests
    {
        public static int Sum(int num1, int num2)
        {
            return num1 + num2;
        }

        public static void Add(int num1, int num2)
        {
            Console.WriteLine(num1 + num2);
        }


        [TestMethod]
        public void GivenAFunctionIsAssignedToFunc_WhenFuncDelegateIsCalled_AssignedFunctionIsexecuted()
        {
            Func<int, int, int> func = Sum;
            int result = func(3, 4);
            
            Assert.AreEqual(result, 7);
        }

        [TestMethod]
        public void GivenAFunctionIsAssignedToAction_WhenActionDelegateIsCalled_AssignedFunctionIsexecuted()
        {
            Action<int, int> action = Add;
            using (var sw = new StringWriter())
            {
                Console.SetOut(sw);
                action(3, 4);

                var result = sw.ToString().Trim();
                
                Assert.AreEqual("7", result);
            }
        }

        [TestMethod]
        public void GivenAnonymousFunctionnIsAssignedToFunc_WhenFuncDelegateIsCalled_AssignedFunctionIsexecuted()
        {
            Func<int, int> func = delegate (int num)
            {
                return num * num;
            };

            int result = func(3);
            
            Assert.AreEqual(result, 9);
        }

        [TestMethod]
        public void GivenAnonymousFunctionIsAssignedToAction_WhenActionDelegateIsCalled_AssignedFunctionIsexecuted()
        {
            Action<int> action = delegate(int num)
            {
                Console.WriteLine(num * num);
            };

            using (var sw = new StringWriter())
            {
                Console.SetOut(sw);
                action(3);

                var result = sw.ToString().Trim();
                
                Assert.AreEqual("9", result);
            }
        }

        [TestMethod]
        public void GivenLambdaIsAssignedToAction_WhenActionDelegateIsCalled_AssignedFunctionIsexecuted()
        {
            Action<int> action = (int num) => Console.WriteLine(num * num);


            using (var sw = new StringWriter())
            {
                Console.SetOut(sw);
                action(3);

                var result = sw.ToString().Trim();
                
                Assert.AreEqual("9", result);
            }
        }

        [TestMethod]
        public void GivenLambdaIsAssignedToFunc_WhenFuncDelegateIsCalled_AssignedFunctionIsexecuted()
        {
            Func<int, int> func = (int num) => num * num;

            int result = func(3);
            
            Assert.AreEqual(result, 9);
        }
    }
}
