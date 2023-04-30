public class Shipment
{
    public string TrackingNumber { get; set; }

    public DateTime ShipDate { get; set; }

    public string Carrier { get; set; }

    public override bool Equals(object obj)
    {
        if (obj.GetType() != typeof(Shipment))
            return false;
        var shipment = (Shipment)obj;
        
        return TrackingNumber == shipment.TrackingNumber
            && ShipDate == shipment.ShipDate
            && Carrier == shipment.Carrier;
    }
}

