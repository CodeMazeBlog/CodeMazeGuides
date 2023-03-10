using System.Runtime.Serialization;

namespace DeepCopyInCSharp
{
    [DataContract]
    [Serializable]
    public class Person : ICloneable
    {
        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public int Age { get; set; }

        [DataMember]
        public Address Address { get; set; }

        public object Clone()
        {
            var clonedPerson = new Person
            {
                Name = this.Name,
                Age = this.Age,
                Address = (Address)this.Address.Clone()
            };

            return clonedPerson;
        }
    }
}
