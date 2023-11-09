using System.Runtime.Serialization;

namespace DeepCopyInCSharp
{
    [DataContract]
    [Serializable]
    public class Person : ICloneable
    {
        [DataMember]
        public required string Name { get; set; }

        [DataMember]
        public required int Age { get; set; }

        [DataMember]
        public required Address Address { get; set; }

        public Person ShallowCopy() => (Person)this.MemberwiseClone();

        public object Clone()
        {
            var clonedPerson = new Person
            {
                Name = Name,
                Age = Age,
                Address = (Address)Address.Clone()
            };

            return clonedPerson;
        }
    }
}
