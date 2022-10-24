using CodeMazeShop.Web.Entities;
using CodeMazeShop.Web.Extensions;
using CodeMazeShop.Web.Models;
using CodeMazeShop.Web.Services;
using Microsoft.AspNetCore.Mvc;

namespace CodeMazeShop.Web.Controllers;

public class ProductCatalogController : Controller
{
    private readonly IProductCatalogService _productCatalogService;
    private readonly IShoppingCartService _shoppingCartService;
    private readonly CookieSettings _cookieSettings;

    public ProductCatalogController(IProductCatalogService productCatalogService, IShoppingCartService shoppingCartService, CookieSettings cookieSettings)
    {
        _productCatalogService = productCatalogService;
        _shoppingCartService = shoppingCartService;
        _cookieSettings = cookieSettings;
    }
    public async Task<IActionResult> Index(Guid categoryId)
    {
        var getCategories = _productCatalogService.GetCategories();

        var getProducts = categoryId == Guid.Empty ? _productCatalogService.GetAll() :
            _productCatalogService.GetByCategoryId(categoryId);

        var currentCartId = Request.Cookies.GetCurrentCartId(_cookieSettings);

        var getCart = currentCartId == Guid.Empty ? Task.FromResult<Cart>(null) :
               _shoppingCartService.GetShoppingCart(currentCartId);

        await Task.WhenAll(new Task[] { getCategories, getProducts, getCart });

        return View(new ProductListModel
        {
            Products = getProducts.Result,
            Categories = getCategories.Result,
            SelectedCategory = categoryId,
            NumberOfItems = getCart.Result?.NumberOfItems ?? 0
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
