using ExecutingPowerShellScript;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests
{
    public  class PSCustomRunspaceTest
    {
        private PSCustomRunspace customRunspace;
        public PSCustomRunspaceTest()
        {
            customRunspace = new PSCustomRunspace();
        }

        [Fact]
        public void GivenNameWhenInvokedDoesntStartAProcess()
        {
            var result = customRunspace.StartAProcess("notepad");
            var expectedResult = false;

            Assert.Equal(expectedResult, result);
        }
    }
}
