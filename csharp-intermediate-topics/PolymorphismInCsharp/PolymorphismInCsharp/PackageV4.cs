using System;

namespace Polymorphism_v4
{
    public class Package
    {
        public string Recipient { get; set; }
        public string Address { get; set; }
        public decimal Weight { get; set; }
        public DateTime SendDate { get; set; }

        public Package(string recipient, string address, decimal weight, DateTime sendDate)
        {
            Recipient = recipient;
            Address = address;
            Weight = weight;
            SendDate = sendDate;
        }

        public virtual decimal GetDeliveryCost()
        {
            return 3 * Weight;
        }

        public virtual DateTime GetDeliveryDate()
        {
            //two working days delivery
            if (SendDate.DayOfWeek == DayOfWeek.Friday)
                return SendDate.AddDays(4);
            if (SendDate.DayOfWeek == DayOfWeek.Thursday)
                return SendDate.AddDays(4);
            else
                return SendDate.AddDays(2);
        }
    }

    public class ExpeditedPackage : Package
    {
        public ExpeditedPackage(string recipient, string address, decimal weight, DateTime sendDate)
                    : base(recipient, address, weight, sendDate) 
        { }

        public sealed override decimal GetDeliveryCost()
        {
            return 4 * Weight + 2;
        }

        public sealed override DateTime GetDeliveryDate()
        {
            //always deliver on the next day
            return SendDate.AddDays(1);
        }
    }

    public class InternationalPackage : Package
    {
        public string CountryCode { get; set; }

        public InternationalPackage(string recipient, string address, decimal weight, DateTime sendDate, string countryCode)
                    : base(recipient, address, weight, sendDate)
        {
            CountryCode = countryCode;
        }

        public sealed override decimal GetDeliveryCost()
        {
            if (CountryCode == "US")
                return base.GetDeliveryCost();
            else if (CountryCode == "UK")
                return 5 * Weight + 4;
            else if (CountryCode == "DE")
                return 6 * Weight;
            else
                return 6 * Weight + 2;
        }

        public override DateTime GetDeliveryDate()
        {
            if (CountryCode == "US")
                return base.GetDeliveryDate();
            else if (CountryCode == "UK")
                return SendDate.AddDays(2);
            else if (CountryCode == "DE")
                return SendDate.AddDays(1);
            else
                return SendDate.AddDays(2);
        }
    }

    public class PremiumExpeditedPackage : ExpeditedPackage
    {
        public PremiumExpeditedPackage(string recipient, string address, decimal weight, DateTime sendDate)
                    : base(recipient, address, weight, sendDate)
        { }

        public new decimal GetDeliveryCost()
        {
            return 6 * Weight + 2;
        }

        public new DateTime GetDeliveryDate()
        {
            //always deliver on the same day
            return SendDate;
        }
    }
}
