namespace SecretMgt
{
    public class Order
    {
        public string Product {  get; set; }
        public double Cost { get; set; }
        public bool PaymentComplete { get; set; } = false;
    }
}
