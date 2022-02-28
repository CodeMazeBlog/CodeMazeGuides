using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomAttributes
{
    [TaskDescriptor(Name = "The group's Name", Description = "Some descriptions for the task", NeedsManager = true, DeveloperCount = 5)]
    public class TaskGroup
    {
        [ManagerTask(Priority = Priorities.Mid, NeedsReport = true)]

        [DeveloperTask(Priority = Priorities.High, Description = "Some description for the developer")]
        public void Task1()
        {
        }
    }
}
