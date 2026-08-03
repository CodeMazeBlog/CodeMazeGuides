namespace CodeMazeShop.Services.ShoppingCart.Facade;

public interface IProductCatalogFacade
{
    Task<string> GetProductName(Guid id);
}
