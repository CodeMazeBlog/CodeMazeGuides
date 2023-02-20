using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;

namespace Test
{
    [TestClass]
    public class UnitTest
    {
        //public delegate void ActionDelegate(int x);
        [TestMethod]
        public void Delegate_Display()
        {
            string expectedOutput = "Johm Abraham";
            StringWriter sw = new StringWriter();
            Console.SetOut(sw);

            //var obj = new DelegateProgram();
            //obj.displayDel("John", "Abraham");
        }
    }
}
