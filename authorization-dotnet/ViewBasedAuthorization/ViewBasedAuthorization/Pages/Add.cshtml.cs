using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using ViewBasedAuthorization.Data;
using ViewBasedAuthorization.Models;

namespace ViewBasedAuthorization.Pages;

public class AddModel : PageModel
{
    private readonly DocumentContext _context;

    public AddModel(DocumentContext context)
    {
        _context = context;
    }

    [BindProperty]
    public InputModel Input { get; set; }

    public class InputModel
    {
        [Required]
        public required string Title { get; set; }

        [Required]
        public required string Content { get; set; }
    }

    public IActionResult OnGet()
    {
        return Page();
    }

    public IActionResult OnPost()
    {
        if (ModelState.IsValid)
        {
            var document = new Document
            {
                Title = Input.Title,
                Content = Input.Content
            };

            _context.Documents.Add(document);
            _context.SaveChanges();

            return RedirectToPage("/Index");
        }

        return Page();
    }
}
