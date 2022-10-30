using Microsoft.AspNetCore.Mvc.Rendering;

namespace SelectTagHelper.Models
{
    public class ProductViewModel
    {
        public string Product { get; set; }
        public List<SelectListItem> Products { get; set; }
    }
}