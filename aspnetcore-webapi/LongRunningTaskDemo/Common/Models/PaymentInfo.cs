namespace Common.Models
{
    public class PaymentInfo
    {
        public string? CreditCardNumber { get; set; }
                
        public CreditCardType CreditCardType { get; set; }

        public int Cvv { get; set; }
    }
}