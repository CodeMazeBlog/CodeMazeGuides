using AutoMapper;
using CodeMazeShop.Integration.Abstractions;
using CodeMazeShop.Integration.Messages;
using CodeMazeShop.DataContracts.ShoppingCart;
using CodeMazeShop.Services.ShoppingCart.Facade;
using CodeMazeShop.Services.ShoppingCart.Repositories;
using Microsoft.AspNetCore.Mvc;
using DataContract = CodeMazeShop.DataContracts.ShoppingCart;

namespace CodeMazeShop.Services.ShoppingCart.Controllers;

[Route("api/shoppingcart")]
[ApiController]
public class ShoppingCartController : ControllerBase
{
    private readonly IShoppingCartRepository _shoppingCartRepository;
    private readonly IProductCatalogFacade _productCatalogFacade;
    private readonly IDiscountFacade _discountFacade;
    private readonly IMapper _mapper;
    private readonly IMessageProducer<CartCheckoutMessage> _producer;

    public ShoppingCartController(IShoppingCartRepository shoppingCartRepository, 
                                  IProductCatalogFacade productCatalogFacade, 
                                  IDiscountFacade discountFacade, 
                                  IMapper mapper,
                                  IMessageProducer<CartCheckoutMessage> producer)
    {
        _shoppingCartRepository = shoppingCartRepository;
        _productCatalogFacade = productCatalogFacade;
        _discountFacade = discountFacade;
        _mapper = mapper;
        _producer = producer;
    }

    [HttpGet("{cartId}")]
    public async Task<ActionResult<DataContract.Cart>> GetShoppingCart(string cartId)
    {
        var result = await _shoppingCartRepository.GetCart(cartId);
        if(result is null)
        {
            return NotFound();
        }

        var cart = _mapper.Map<DataContract.Cart>(result);

        Entities.PromotionCoupon coupon = null;
        if (!string.IsNullOrEmpty(result.PromotionCouponId))
        {
            coupon = await _discountFacade.GetPromotionCouponById(result.PromotionCouponId);
        }
        if(coupon != null)
        {
            cart.Code = coupon.Code;
            cart.Discount = coupon.Amount;
        }

        cart.ShoppingCartTotal = cart.LineItems.Sum(cli => cli.Price * cli.Quantity);

        if (cart.ShoppingCartTotal > 0)
        {
            cart.ShoppingCartTotal -= cart.Discount;
        }

        return Ok(cart);
    }

    [HttpPost("add")]
    public async Task<IActionResult> AddToCart(CartLineItemForCreation cartLineItem)
    {
        if(cartLineItem.CartId == Guid.Empty)
        {
            cartLineItem.CartId = Guid.NewGuid();
        }        
        
        var cartLineItemEntity = _mapper.Map<Entities.CartLineItem>(cartLineItem);
        cartLineItemEntity.CartLineItemId = Guid.NewGuid().ToString();
        cartLineItemEntity.Product = new Entities.Product
        {
            ProductId = cartLineItem.ProductId.ToString(),
            Name = await GetProductName(cartLineItem.ProductId)
        };

        await _shoppingCartRepository.AddCartLineItem(cartLineItem.CartId.ToString(), cartLineItemEntity);
        return Ok(cartLineItem.CartId);  

    }

    [HttpPut]
    public async Task<IActionResult> UpdateLineItem(CartLineItemForUpdate cartLineItem)
    {
        var cartLineItemEntity = _mapper.Map<Entities.CartLineItem>(cartLineItem);
       
        var result = await _shoppingCartRepository.UpdateLineItem(cartLineItem.CartId.ToString(), cartLineItemEntity);
        if (result is false)
        {
            return NotFound();
        }

        return NoContent();
    }

    [HttpDelete("{cartId}/remove/{cartLineItemId}")]
    public async Task<IActionResult> RemoveLineItem(string cartId, string cartLineItemId)
    {
        var result = await _shoppingCartRepository.RemoveLineItem(cartId, cartLineItemId);
        if (result is false)
        {
            return NotFound();
        }

        return NoContent();
    }

    [HttpPost("apply-discount")]
    public async Task<ActionResult<DiscountCodeResponse>> ApplyDiscountCode(DiscountCodeRequest request)
    {
        var coupon = await _discountFacade.GetPromotionCouponByCode(request.Code);

        if(coupon == null || coupon.IsAlreadyUsed)
        {
            return Ok(new DiscountCodeResponse { IsSuccessful = false });
        }

        await _shoppingCartRepository.ApplyPromotionCouponToCart(request.CartId.ToString(), coupon.PromotionCouponId);
        await _discountFacade.UpdatePromotionCodeSatus(coupon.PromotionCouponId);

        return Ok(new DiscountCodeResponse { IsSuccessful = true });
    }

    [HttpPost("checkout")]
    public async Task<IActionResult> Checkout(CheckoutRequest request)
    {        
        var checkoutMessage = _mapper.Map<CartCheckoutMessage>(request);
                
        var cart = await _shoppingCartRepository.GetCart(request.CartId.ToString());

        if (cart is null)
        {
            return NotFound();
        }

        checkoutMessage.OrderTotal = cart.LineItems.Sum(cli => cli.Price * cli.Quantity);

        Entities.PromotionCoupon coupon = null;
        if (!string.IsNullOrEmpty(cart.PromotionCouponId))
        {
            coupon = await _discountFacade.GetPromotionCouponById(cart.PromotionCouponId);
        }
        if (checkoutMessage.OrderTotal > 0 && coupon is not null)
        {
            checkoutMessage.OrderTotal -= coupon.Amount;
        }
        
        foreach(var lineItem in cart.LineItems) 
        {
            checkoutMessage.LineItems.Add(new LineItem 
            { 
                Price= lineItem.Price, 
                ProductId = new Guid(lineItem.Product.ProductId), 
                Quantity = lineItem.Quantity 
            });
        }

        try
        {
            await _producer.SendMessage(checkoutMessage);
            await _shoppingCartRepository.RemoveCartFromRedisStore(request.CartId.ToString());
        }
        catch(Exception ex)
        {
            Console.WriteLine(ex);
            throw;
        }

        return Accepted();
    }

    private async Task<string> GetProductName(Guid productId) 
        => await _productCatalogFacade.GetProductName(productId);
   
}