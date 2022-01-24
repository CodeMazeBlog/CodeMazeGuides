using System;
using Xunit;
using ActionDelegates;
using System.IO;
using System.Text;

namespace Tests
{
    public class ActionDelegate_Test
    {
        [Fact]
        public void WhenInvoke_ThenPrintParametr()
        {
            var actual = 0 ;
            var aClass = new ActionDelegates.Program.Action_Delegate((s)=> { actual = s; });
            aClass(10);
            Assert.Equal(10, actual);
            
            
            
        }
        
    }
}
