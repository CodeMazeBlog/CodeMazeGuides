using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polymorphism_v5
{
    public class Package
    {
        public string Type { get; set; }
        public string Recipient { get; set; }
        public string Address { get; set; }
        public decimal Weight { get; set; }
        public DateTime SendDate { get; set; }
        public string CountryCode { get; set; }

        public Package(string type, string recipient, string address, decimal weight, DateTime sendDate, string countryCode)
        {
            Type = type;
            Recipient = recipient;
            Address = address;
            Weight = weight;
            SendDate = sendDate;
            CountryCode = countryCode;
        }

        public decimal GetDeliveryCost()
        {
            if (Type == "Expedited")
                return 4 * Weight + 2;
            if (Type == "International")
            {
                if (CountryCode == "US")
                    return 6 * Weight + 3;
                else if (CountryCode == "UK")
                    return 5 * Weight + 4;
                else if (CountryCode == "DE")
                    return 6 * Weight;
                else
                    return 6 * Weight + 2;
            }
            else
                return 3 * Weight;
        }
        public DateTime GetDeliveryDate()
        {
            if (Type == "Expedited")
                return SendDate.AddDays(1);
            if (Type == "International")
            {
                if (CountryCode == "US")
                    return SendDate.AddDays(3);
                else if (CountryCode == "UK")
                    return SendDate.AddDays(2);
                else if (CountryCode == "DE")
                    return SendDate.AddDays(1);
                else
                    return SendDate.AddDays(2);
            }
            else
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
    }
}
