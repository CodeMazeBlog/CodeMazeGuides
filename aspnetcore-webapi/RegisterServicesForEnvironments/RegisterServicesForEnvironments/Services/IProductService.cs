using RegisterServicesForEnvironments.Models;

namespace RegisterServicesForEnvironments.Services
{
    public interface IProductService
    {
        public List<Product> GetAll(); 
    }
}
