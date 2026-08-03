using ClientServerArchitecture.Models;
using ClientServerArchitecture.Services;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ClientServerArchitecture.Pages;

public class IndexModel : PageModel
{
    private readonly IProductService _productService;
    public List<Product> Products { get; set; }

    public IndexModel(IProductService productService)
    {
        _productService = productService;
    }

    public void OnGet()
    {
        Products = _productService.GetProducts();
    }
}
