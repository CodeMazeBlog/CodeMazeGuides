using HowToUseMapster.Data;

namespace HowToUseMapster.Data
{
    public static partial class AddressMapper
    {
        public static AddressModel AdaptToModel(this Address p1)
        {
            return p1 == null ? null : new AddressModel()
            {
                Street = p1.Street,
                City = p1.City,
                PostCode = p1.PostCode,
                Country = p1.Country
            };
        }
        public static AddressModel AdaptTo(this Address p2, AddressModel p3)
        {
            if (p2 == null)
            {
                return null;
            }
            AddressModel result = p3 ?? new AddressModel();
            
            result.Street = p2.Street;
            result.City = p2.City;
            result.PostCode = p2.PostCode;
            result.Country = p2.Country;
            return result;
            
        }
    }
}