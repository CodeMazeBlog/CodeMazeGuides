using System;

namespace ThrowVsThrowEx
{
    public class BusinessWorker
    {
        public void Work_Throw()
        {
            try
            {
                //lots of other business logic all around...
                new ThirdPartyComponent().DoInternalWork();
            }
            catch (Exception ex)
            {
                //here we would handle 'ex' in the BusinessWorker (clean up resources, log state, call 911 etc.)
                throw;
            }
        }
        
        public void Work_ThrowEx()
        {
            try
            {
                //lots of other business logic all around...
                new ThirdPartyComponent().DoInternalWork();
            }
            catch (Exception ex)
            {
                //here we would handle 'ex' in the BusinessWorker (clean up resources, log state, call 911 etc.)
                throw ex;
            }
        }

        public void Work_WrapAndThrowNewEx()
        {
            try
            {
                //lots of other business logic all around...
                new ThirdPartyComponent().DoInternalWork();
            }
            catch (Exception ex)
            {
                //here we would handle 'ex' in the BusinessWorker (clean up resources, log state, call 911 etc.)
                throw new BusinessException("I am a business domain wrapper for internal exceptions.", ex);
            }
        }

        class BusinessException : Exception
        {
            public BusinessException(string? message, Exception? innerException) : base(message, innerException)
            {
            }
        }

        
    }

    public class ThirdPartyComponent
    {
        public void DoInternalWork()
        {
            GoDeeper();
        }

        private void GoDeeper()
        {
            DoDangerousOperation();
            void DoDangerousOperation()
            {
                throw new InvalidOperationException("That's a nasty bug!");
            }
        }
    }
}