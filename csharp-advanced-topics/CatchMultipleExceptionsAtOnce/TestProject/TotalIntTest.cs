using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject
{
    [TestClass]
    public class TotalIntTest
    {
        [TestMethod]
        public void WhenCorrectAndInCorrectInput_ThenAllOutputs()
        {
            TryCatchUnitTest test = new TryCatchUnitTest();
            test.WhenCorrectInput_ThenCorrectOutput();
            test.WhenIncorrectInputFormat_ThenInCorrectOutput();
            test.WhenInvalidRangeError_ThenInCorrectOutput();
            test.WhenDivisionByZeroError_ThenInCorrectOutput();
            test.WhenOverflowError_ThenInCorrectOutput();
        }
    }
}
