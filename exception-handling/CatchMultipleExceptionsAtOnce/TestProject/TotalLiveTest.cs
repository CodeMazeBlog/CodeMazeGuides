using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject
{
    [TestClass]
    public class TotalLiveTest
    {
        [TestMethod]
        public void WhenCorrectAndInCorrectInput_ThenAllOutputs()
        {
            new TotalIntTest().WhenCorrectAndInCorrectInput_ThenAllOutputs();
        }
    }
}
