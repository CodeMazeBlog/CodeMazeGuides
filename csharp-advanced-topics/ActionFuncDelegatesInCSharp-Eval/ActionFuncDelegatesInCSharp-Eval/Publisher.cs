using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActionFuncDelegatesCSharp
{
    public class Publisher
    {
        public Func<Tuple<string, int>> GetMemberDetails { get; set; }
        private Dictionary<string, int> GetMembershipReport()
        {
            // uncomment this line to see how we know at compile-time that this 
            // won't work.
            // return GetMembershipNumber.Invoke().ToDictionary(tup => tup.Item1, tup => tup.Item2);

            var result = new Dictionary<string, int>();
            var member = GetMemberDetails();
            result.Add(member.Item1, member.Item2);
            return result;
        }

        public Dictionary<string, int> GetMembershipReport(bool useReflection)
        {
            var result = new Dictionary<string, int>();
            if (useReflection)
            {
                foreach(Delegate member in GetMemberDetails.GetInvocationList()) {
                   var detail = (Tuple<string, int>)member.DynamicInvoke();
                    result.Add(detail.Item1, detail.Item2);
                }

                return result;
            }

            return GetMembershipReport();
        }
    }
}
