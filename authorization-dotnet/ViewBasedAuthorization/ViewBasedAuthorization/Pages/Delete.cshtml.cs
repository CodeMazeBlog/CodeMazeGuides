using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ViewBasedAuthorization.Data;
using ViewBasedAuthorization.Models;

namespace ViewBasedAuthorization.Pages;

[Authorize(Policy = "DeleteDocument")]
public class DeleteModel : PageModel
{
    private readonly DocumentContext _context;

    [BindProperty]
    public Document Document { get; set; }

    public DeleteModel(DocumentContext context)
    {
        _context = context;
    }

    public IActionResult OnGet(int id)
    {
        Document = _context.Documents.Find(id);

        if (Document == null)
        {
            return NotFound();
        }

        return Page();
    }

    public IActionResult OnPost()
    {
        var document = _context.Documents.Find(Document.Id);

        if (document == null)
        {
            return NotFound();
        }

        _context.Documents.Remove(document);
        _context.SaveChanges();

        return RedirectToPage("/Index");
    }
}
