using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ContentSecurityPolicySample.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
            Response.Headers.Add("Content-Security-Policy", "default-src 'self'; script-src 'self' 'unsafe-inline' scripts.ourdomain.com; style-src 'self' 'unsafe-inline' styles.ourdomain; img-src 'self' 'unsafe-inline' images.ourdomain.com; frame-ancestors 'none'; report-uri /csp-violations");
        }
    }
}