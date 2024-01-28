using ExpressiveAnnotations.Attributes;
using System.ComponentModel.DataAnnotations;

namespace ConditionalRequiredAttributeValidation.Models;

public class Order
{
    public bool IsExpressShipping { get; set; }

    [RequiredIf(nameof(IsExpressShipping), ErrorMessage = "Shipping address is required for express shipping.")]
    public string ShippingAddress { get; set; }

    [Required(ErrorMessage = "Customer name is required.")]
    public string CustomerName { get; set; }

    [AssertThat("IsExpressShipping == true", ErrorMessage = "Delivery date is required for express shipping.")]
    public DateTime? DeliveryDate { get; set; }

    [Range(1, int.MaxValue, ErrorMessage = "Please select a valid product.")]
    public int ProductId { get; set; }

    [RequiredIf("ProductId > 1", ErrorMessage = "Product description is required when product ID is provided.")]
    public string ProductDescription { get; set; }
}