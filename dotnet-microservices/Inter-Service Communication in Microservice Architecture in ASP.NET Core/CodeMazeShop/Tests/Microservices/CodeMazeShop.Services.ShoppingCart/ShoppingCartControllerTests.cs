using AutoMapper;
using CodeMazeShop.Integration.Abstractions;
using CodeMazeShop.Integration.Messages;
using CodeMazeShop.Services.ShoppingCart.Controllers;
using CodeMazeShop.Services.ShoppingCart.Entities;
using CodeMazeShop.Services.ShoppingCart.Facade;
using CodeMazeShop.Services.ShoppingCart.Repositories;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;

namespace Tests.Microservices.CodeMazeShop.Services.ShoppingCart;

[TestFixture]
public class ShoppingCartControllerTests
{
    private Mock<IShoppingCartRepository> _shoppingCartRepositoryMock;
    private Mock<IProductCatalogFacade> _productCatalogFacadeMock;
    private Mock<IDiscountFacade> _discountFacadeMock;
    private Mock<IMapper> _mapperMock;
    private Mock<IMessageProducer<CartCheckoutMessage>> _producerMock;

    private ShoppingCartController _controller;

    [SetUp]
    public void SetUp()
    {
        _shoppingCartRepositoryMock = new Mock<IShoppingCartRepository>();
        _productCatalogFacadeMock = new Mock<IProductCatalogFacade>();
        _discountFacadeMock = new Mock<IDiscountFacade>();
        _mapperMock = new Mock<IMapper>();
        _producerMock = new Mock<IMessageProducer<CartCheckoutMessage>>();

        _controller = new ShoppingCartController(
            _shoppingCartRepositoryMock.Object,
            _productCatalogFacadeMock.Object,
            _discountFacadeMock.Object,
            _mapperMock.Object,
            _producerMock.Object);
    }

    [Test]
    public async Task WhenGetShoppingCartIsInvoked_NotFoundIsReturnedForNoMatchingCart()
    {        
        var cartId = "test_cart_id";
        _shoppingCartRepositoryMock.Setup(x => x.GetCart(cartId)).ReturnsAsync((Cart)null);
                
        var result = await _controller.GetShoppingCart(cartId);
        
        Assert.IsInstanceOf<NotFoundResult>(result.Result);
    }
}