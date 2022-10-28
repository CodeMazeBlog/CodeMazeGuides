using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuncDelegate
{
    [TestFixture]
 
    public class FuncDelegateTest
    {
        public void TestProduct(int i, int j)
        {
            Func<int, int, int> prod = Program.Product;
            int result = prod(12, 10);
            Assert.AreEqual(120, result);
                
              
        }
    }

}
