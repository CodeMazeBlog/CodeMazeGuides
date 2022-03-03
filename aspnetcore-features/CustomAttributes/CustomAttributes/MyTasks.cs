using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomAttributes
{
    [TaskDescriptor(Name = "The task's name",
        Description = "Some descriptions for the task",
        NeedsManager = true,
        DeveloperCount = 5)]
    public class MyTasks
    {
        [DeveloperTask(Priority = Priorities.Low,
           Description = "Low level description")]

        [DeveloperTask(Priority = Priorities.High,
            Description = "High level description")]
        public void ScheduleMeeting()
        {
        }

        [ManagerTask(Priority = Priorities.Mid,
            NeedsReport = true)]

        [DeveloperTask(Priority = Priorities.High,
            Description = "High level description")]
        public virtual void ScheduleInterview()
        {
        }
    }
}
