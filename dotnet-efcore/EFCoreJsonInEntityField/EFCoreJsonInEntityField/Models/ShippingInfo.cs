public class ShippingInfo
{
    public string Address { get; set; }

    public string City { get; set; }

    public string State { get; set; }
    
    public string PostalCode { get; set; }

    public List<Shipment> Shipments { get; set; } = new();
    
    public List<Delivery> Deliveries { get; set; } = new();
    
    public override bool Equals(object obj)
    {
        if (obj.GetType() != typeof(ShippingInfo))
            return false;
        var input = (ShippingInfo)obj;
        if (input.Shipments.Count != Shipments.Count)
            return false;
        if (input.Deliveries.Count != Deliveries.Count)
            return false;
        bool andRes =Address == input.Address
            && City == input.City
            && State == input.State
            && PostalCode == input.PostalCode;
        if (!andRes) return false;
        
        for (int i = 0; i < input.Shipments.Count; i++)
        {
            andRes=andRes && (Shipments[i].Equals(input.Shipments[i]));
            if (!andRes) return false;
        }        
        for (int i = 0; i < input.Deliveries.Count; i++)
        {
            andRes = andRes && (Deliveries[i].Equals(input.Deliveries[i]));
            if (!andRes) return false;
        }

        return andRes;
    }
}