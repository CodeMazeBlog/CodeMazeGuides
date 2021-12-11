using DoSomethingLibrary;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DoSomethingInTheWeb.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private int current = 0;
        private readonly int maxRepeat = 5;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
            DoSomething.LongProcess(ReportProgress);

            DoSomething.InteractiveProcess(KeepRepeating);
        }

        private bool KeepRepeating()
        {
            current++;
            _logger.LogInformation($"Keep repeating {current} of {maxRepeat} times");
            return current < maxRepeat;
        }

        private void ReportProgress() => _logger.LogInformation("Long Process report progress");
    }
}