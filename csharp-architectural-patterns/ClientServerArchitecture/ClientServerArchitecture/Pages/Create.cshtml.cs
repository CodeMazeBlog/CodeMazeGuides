using ClientServerArchitecture.Models;
using ClientServerArchitecture.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ClientServerArchitecture.Pages;

public class CreateModel : PageModel
{
    private readonly IProductService _productService;

    [BindProperty]
    public Product Product { get; set; }

    public CreateModel(IProductService productService)
    {
        _productService = productService;
    }

    public void OnGet() { }

    public IActionResult OnPost()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        _productService.AddProduct(Product);

        return RedirectToPage("/Index");
    }
}
