using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuncAndActionDelegatesInCsharp
{
    public class StateResult 
    { 
        public string? result { get; set; }
        public string? LastFailedOperationName { get; set; }
        public bool HasErrors { get; set; } }

    public class ContinueExecutionUsingFunc
    {
        #region "Operation"
        public static StateResult Operation1(string u)
        {
            var result = new StateResult(); try
            {
                //Do some work on object u 
                u += !string.IsNullOrEmpty(u) ? "_" : "";
                u += nameof(Operation1);

                //call next operation
                result = Operation2(u); 

            } catch(Exception e) 
            { 
                Console.WriteLine(e.Message);
                result.HasErrors = true;
                result.LastFailedOperationName = nameof(Operation1); 
            } 
            return result; 
        }

        public static StateResult Operation2(string u)
        {
            var result = new StateResult(); try
            {
                //Do some work on object u 
                u += !string.IsNullOrEmpty(u) ? "_" : "";
                u += nameof(Operation2);

                //call next operation
                result = Operation3(u);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                result.HasErrors = true;
                result.LastFailedOperationName = nameof(Operation2);
            }
            return result;
        }

        public static StateResult Operation3(string u)
        {
            var result = new StateResult(); try
            {
                //Do some work on object u 
                u += !string.IsNullOrEmpty(u) ? "_" : "";
                u += nameof(Operation3);

                //call next operation
                result = Operation4(u);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                result.HasErrors = true;
                result.LastFailedOperationName = nameof(Operation3);
            }
            return result;
        }

        public static StateResult Operation4(string u)
        {
            var result = new StateResult(); try
            {
                //Do some work on object u 
                u += !string.IsNullOrEmpty(u) ? "_" : "";
                u += nameof(Operation4);

                //Last Operation
                result.result = u;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                result.HasErrors = true;
                result.LastFailedOperationName = nameof(Operation4);
            }
            return result;
        }

        #endregion 

        public static StateResult ContinueExcution(string lastFailedPperationName, string u)
        { 
            Dictionary<string, Func<string, StateResult>> operations 
                = new Dictionary<string, Func<string, StateResult>> 
                    { 
                        { nameof(Operation1), Operation1 },
                        { nameof(Operation2), Operation2 },
                        { nameof(Operation3), Operation3 },
                        { nameof(Operation4), Operation4 }
                    };
            var stateResult = new StateResult();
            foreach (var pair in operations) 
            { 
                if (pair.Key != lastFailedPperationName)
                    continue; stateResult = pair.Value.Invoke(u); 
            } 
            return stateResult; 
        }

    }
}
