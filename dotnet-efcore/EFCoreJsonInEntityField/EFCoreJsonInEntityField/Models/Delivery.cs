public class Delivery
{
    public string ReceiverName { get; set; }

    public DateTime DeliveryDate { get; set; }

    public string Signature { get; set; }

    public override bool Equals(object obj)
    {
        if (obj.GetType() != typeof(Delivery))
            return false;
        var delivery = (Delivery)obj;
        
        return ReceiverName == delivery.ReceiverName
            && DeliveryDate == delivery.DeliveryDate
            && Signature == delivery.Signature;
    }
}

