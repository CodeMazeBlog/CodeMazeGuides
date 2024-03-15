using CodeMazeShop.WebClient.Extensions;
using CodeMazeShop.WebClient.Models;
using CodeMazeShop.WebClient.Services;
using Microsoft.AspNetCore.Mvc;

namespace CodeMazeShop.WebClient.Controllers;

public class ProductCatalogController : Controller
{
    private readonly IProductCatalogService _productCatalogService;    
    private readonly CookieSettings _cookieSettings;
    private readonly IShoppingCartService _shoppingCartService;

    public ProductCatalogController(IProductCatalogService productCatalogService, IShoppingCartService shoppingCartService, CookieSettings cookieSettings)
    {
        _productCatalogService = productCatalogService;        
        _cookieSettings = cookieSettings;
        _shoppingCartService= shoppingCartService;
        
    }
    public async Task<IActionResult> Index(Guid categoryId)
    {
        var getCategories = _productCatalogService.GetCategories();

        var getProducts = categoryId == Guid.Empty ? _productCatalogService.GetAll() :
            _productCatalogService.GetByCategoryId(categoryId);

        var currentCartId = Request.Cookies.GetCurrentCartId(_cookieSettings);

        var getCart = currentCartId == Guid.Empty ? Task.FromResult<DataContracts.ShoppingCart.Cart>(null) :
                _shoppingCartService.GetShoppingCart(currentCartId);

        await Task.WhenAll(new Task[] { getCategories, getProducts, getCart });

        return View(new ProductListModel
        {
            Products = getProducts.Result,
            Categories = getCategories.Result,
            SelectedCategory = categoryId,
            NumberOfItems = getCart.Result?.LineItems?.Count ?? 0
        });
    }

    [HttpPost]
    public IActionResult SelectCategory([FromForm] Guid selectedCategory)
    {
        return RedirectToAction("Index", new { categoryId = selectedCategory });
    }

    public async Task<IActionResult> Detail(Guid productId)
    {
        var product = await _productCatalogService.GetProduct(productId);
        return View(product);
    }
}