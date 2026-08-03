using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ViewBasedAuthorization.Data;
using ViewBasedAuthorization.Models;

namespace ViewBasedAuthorization.Pages;

[Authorize(Policy = "EditDocument")]
public class EditModel : PageModel
{
    private readonly DocumentContext _context;

    [BindProperty]
    public Document Document { get; set; }

    public EditModel(DocumentContext context)
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
        if (!ModelState.IsValid)
        {
            return Page();
        }

        var existingDocument = _context.Documents.Find(Document.Id);

        if (existingDocument == null)
        {
            return NotFound();
        }

        existingDocument.Title = Document.Title;
        existingDocument.Content = Document.Content;

        _context.Update(existingDocument);
        _context.SaveChanges();

        return RedirectToPage("/Index");
    }
}
