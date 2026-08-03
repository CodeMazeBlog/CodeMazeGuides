
namespace ObserverPattern
{
    public class Application
    {
        public int JobId { get; set; }
        public string ApplicantName { get; set; }

        public Application(int jobId, string applicantName)
        {
            JobId = jobId;
            ApplicantName = applicantName;
        }
    }
}
