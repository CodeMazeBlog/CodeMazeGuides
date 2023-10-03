using DynamicFormInASPNetCore.Data;
using DynamicFormInASPNetCore.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DynamicFormInASPNetCore.Pages;

public class IndexModel : PageModel
{
    private readonly DataContext _dataContext;

    public IndexModel(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    [BindProperty]
    public Product Product { get; set; }
    public List<Product> Products { get; set; }

    public void OnGet()
    {
        Products = _dataContext.Products.ToList();
    }

    public IActionResult OnPostAddRow()
    {
        if (ModelState.IsValid)
        {
            _dataContext.Products.Add(Product);
            _dataContext.SaveChanges();

            return RedirectToPage();
        }

        Products = _dataContext.Products.ToList();

        return Page();
    }

    public IActionResult OnPostRemoveRow(int id)
    {
        var product = _dataContext.Products.Find(id);

        if (product != null)
        {
            _dataContext.Products.Remove(product);
            _dataContext.SaveChanges();
        }

        return RedirectToPage();
    }
}