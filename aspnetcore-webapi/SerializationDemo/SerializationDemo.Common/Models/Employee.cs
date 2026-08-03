using ProtoBuf;

namespace SerializationDemo.Common.Models
{
    [ProtoContract]
    public class Employee
    {
        [ProtoMember(1)]
        public Guid Id { get; set; }
        
        [ProtoMember(2)]
        public string Name { get; set; }
        
        [ProtoMember(3)]
        public Address? Address { get; set; }
    }
}