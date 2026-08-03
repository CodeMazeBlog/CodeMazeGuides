using ProtoBuf;

namespace SerializationDemo.Common.Models
{
    [ProtoContract]
    public class Address
    {
        [ProtoMember(1)]
        public string AddressLine1 { get; set; }

        [ProtoMember(2)]
        public string? AddressLine2 { get; set; }

        [ProtoMember(3)]
        public string City { get; set; }

        [ProtoMember(4)]
        public string Country { get; set; }
    }
}
