using HowToUseMapster.Data;

namespace HowToUseMapster.Data
{
    public static partial class PersonMapper
    {
        public static PersonModel AdaptToModel(this Person p1)
        {
            return p1 == null ? null : new PersonModel()
            {
                Title = p1.Title,
                FirstName = p1.FirstName,
                LastName = p1.LastName,
                DateOfBirth = p1.DateOfBirth,
                Address = p1.Address == null ? null : new AddressModel()
                {
                    Street = p1.Address.Street,
                    City = p1.Address.City,
                    PostCode = p1.Address.PostCode,
                    Country = p1.Address.Country
                }
            };
        }
        public static PersonModel AdaptTo(this Person p2, PersonModel p3)
        {
            if (p2 == null)
            {
                return null;
            }
            PersonModel result = p3 ?? new PersonModel();
            
            result.Title = p2.Title;
            result.FirstName = p2.FirstName;
            result.LastName = p2.LastName;
            result.DateOfBirth = p2.DateOfBirth;
            result.Address = funcMain1(p2.Address, result.Address);
            return result;
            
        }
        
        private static AddressModel funcMain1(Address p4, AddressModel p5)
        {
            if (p4 == null)
            {
                return null;
            }
            AddressModel result = p5 ?? new AddressModel();
            
            result.Street = p4.Street;
            result.City = p4.City;
            result.PostCode = p4.PostCode;
            result.Country = p4.Country;
            return result;
            
        }
    }
}