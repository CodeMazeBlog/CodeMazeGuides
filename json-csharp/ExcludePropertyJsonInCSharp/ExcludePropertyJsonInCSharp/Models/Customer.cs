using System.Runtime.Serialization;

namespace ExcludePropertyJsonInCSharp.Models
{
    [DataContract]
    public class Customer
    {
        public int Id { get; set; }

        [DataMember]
        public string Name { get; set; } = default!;

        [DataMember]
        public string LastName { get; set; } = default!;
    }
}
