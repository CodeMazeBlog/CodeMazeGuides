using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomAttributes
{
    public class YourTasks : MyTasks
    {
        [DeveloperTask(Priorities.Mid, Description = "Mid level description")]
        public override void ScheduleInterview()
        {
        }
    }
}
