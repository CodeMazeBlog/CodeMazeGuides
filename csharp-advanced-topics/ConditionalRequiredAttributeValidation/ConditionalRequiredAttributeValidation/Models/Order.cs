using ConditionalRequiredAttributeValidation.Validators;
using System.ComponentModel.DataAnnotations;

namespace ConditionalRequiredAttributeValidation.Models;

public class Order
{
    public bool IsExpressShipping { get; set; }

    [RequiredIf(nameof(IsExpressShipping), true, ErrorMessage = "Shipping address is required for express shipping.")]
    public string ShippingAddress { get; set; }

    [Required(ErrorMessage = "Customer name is required.")]
    public string CustomerName { get; set; }

    public DateTime? DeliveryDate { get; set; }

    [RequiredIf(nameof(IsExpressShipping), true, ErrorMessage = "Product ID is required for express shipping.")]
    public int ProductId { get; set; }

    [RequiredIf(nameof(ProductId), 0, ErrorMessage = "Product description is required when product ID is provided.")]
    public string ProductDescription { get; set; }
}