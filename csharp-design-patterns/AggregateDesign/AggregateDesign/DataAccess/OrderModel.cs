using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AggregateDesign.DataAccess;

[Table("Orders")]
public class OrderModel
{
    [Key]
    public long OrderId { get; set; }

    public DateTime CreationDate { get; set; }

    public decimal PaidAmount { get; set; }

    public DateTime? ShippingDate { get; set; }

    public OrderModelStatus Status { get; set; }

    public ICollection<OrderItemModel> Items { get; set; } = new List<OrderItemModel>();
}
