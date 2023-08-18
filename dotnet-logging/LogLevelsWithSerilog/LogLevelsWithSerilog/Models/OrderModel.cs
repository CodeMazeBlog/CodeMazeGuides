namespace LogLevelsWithSerilog.Models
{
    public class OrderModel
    {
        public int Id { get; set; }
        public int BasketId { get; set; }
        public int UserId { get; set; }
        public int ItemCount { get; set; }
        public DateTime CreateDate { get; set; }
        public int Status { get; set; }
        public decimal OrderAmount { get; set; }
    }
}
