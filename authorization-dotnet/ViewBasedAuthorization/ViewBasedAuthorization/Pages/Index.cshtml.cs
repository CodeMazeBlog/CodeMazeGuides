using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ViewBasedAuthorization.Data;
using ViewBasedAuthorization.Models;

namespace ViewBasedAuthorization.Pages;
public class IndexModel : PageModel
{
    private readonly DocumentContext _context;

    public IndexModel(DocumentContext context, IAuthorizationService authorizationService)
    {
        _context = context;
    }

    public IList<Document> Documents { get; set; }

    public void OnGet()
    {
        Documents = _context.Documents.ToList();
    }
}
