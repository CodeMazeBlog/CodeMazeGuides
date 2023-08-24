using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Threading.Channels;
using NUnit.Framework;

namespace ThrowVsThrowEx
{
    public class ThrowVsThrowExSamples
    {
        [Test]
        public void ThrowBehaviour_KeepsProperStackTrace()
        {
            try
            {
                new BusinessWorker().Work_Throw();
            }
            catch (Exception ex)
            {
                Assert.AreEqual(
                    @"System.InvalidOperationException: That's a nasty bug!
   at ThrowVsThrowEx.ThirdPartyComponent.<GoDeeper>g__DoDangerousOperation|1_0()
   at ThrowVsThrowEx.ThirdPartyComponent.GoDeeper()
   at ThrowVsThrowEx.ThirdPartyComponent.DoInternalWork()
   at ThrowVsThrowEx.BusinessWorker.Work_Throw()
   at ThrowVsThrowEx.ThrowVsThrowExSamples.ThrowBehaviour_KeepsProperStackTrace()",
                    ex.ToString());

            }
        }

        [Test]
        public void ThrowEx_DropsTheStackTrace()
        {
            try
            {
                new BusinessWorker().Work_ThrowEx();
            }
            catch (Exception ex)
            {
                Assert.AreEqual(
                    @"System.InvalidOperationException: That's a nasty bug!
   at ThrowVsThrowEx.BusinessWorker.Work_ThrowEx()
   at ThrowVsThrowEx.ThrowVsThrowExSamples.ThrowEx_DropsTheStackTrace()",
                    ex.ToString());
            }
        }

        [Test]
        public void WrapAndThrowNewEx_KeepsTheStackTraceInTheInnerException()
        {
            try
            {
                new BusinessWorker().Work_WrapAndThrowNewEx();
            }
            catch (Exception ex)
            {
                //the stack trace of the top level exception is short
                Assert.AreEqual(@"   at ThrowVsThrowEx.BusinessWorker.Work_WrapAndThrowNewEx()
   at ThrowVsThrowEx.ThrowVsThrowExSamples.WrapAndThrowNewEx_KeepsTheStackTraceInTheInnerException()", ex.StackTrace);
                //however, the actual exception and it's stack trace is visible within the ex.InnerException property
                //the full exception string also reveals all the layers of inner exceptions
                Assert.AreEqual(
                    @"ThrowVsThrowEx.BusinessWorker+BusinessException: I am a business domain wrapper for internal exceptions.
 ---> System.InvalidOperationException: That's a nasty bug!
   at ThrowVsThrowEx.ThirdPartyComponent.<GoDeeper>g__DoDangerousOperation|1_0()
   at ThrowVsThrowEx.ThirdPartyComponent.GoDeeper()
   at ThrowVsThrowEx.ThirdPartyComponent.DoInternalWork()
   at ThrowVsThrowEx.BusinessWorker.Work_WrapAndThrowNewEx()
   --- End of inner exception stack trace ---
   at ThrowVsThrowEx.BusinessWorker.Work_WrapAndThrowNewEx()
   at ThrowVsThrowEx.ThrowVsThrowExSamples.WrapAndThrowNewEx_KeepsTheStackTraceInTheInnerException()",
                    ex.ToString());
            }
        }
    }
}