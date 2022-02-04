using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObserverPattern
{
    public class Application
    {
        public Application(int jobId, string applicantName)
        {
            JobId = jobId;
            ApplicantName = applicantName;
        }

        public int JobId { get; set; }
        public string ApplicantName { get; set; }
    }
}
