namespace LogLevelsWithSerilog.Models
{
    public class BasketModel
    {
        public int BasketId { get; set; }
        public int ItemCount { get; set; }
        public DateTime CreateDate { get; set; }
        public int? OrderId { get; set; }
        public decimal Amount { get; set; }
    }
}
