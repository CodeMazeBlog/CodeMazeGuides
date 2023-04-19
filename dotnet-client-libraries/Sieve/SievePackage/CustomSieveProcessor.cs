using Microsoft.Extensions.Options;
using Sieve.Models;
using Sieve.Services;

namespace SievePackage
{
    public class CustomSieveProcessor : SieveProcessor
    {
        public CustomSieveProcessor(
            IOptions<SieveOptions> options) 
            : base(options)
        {
        }

        protected override SievePropertyMapper MapProperties(SievePropertyMapper mapper)
        {
            mapper.Property<Shoe>(p => p.Category)
                .CanFilter();

            mapper.Property<Shoe>(p => p.Brand)
                .CanFilter();

            mapper.Property<Shoe>(p => p.Price)
                .CanSort();

            mapper.Property<Shoe>(p => p.Rating)
                .CanSort()
                .CanFilter();

            return mapper;
        }
    }
}
