using SuplementosShop.Entities;

namespace SuplementosShop.Models
{
    public class SingleProductCategoryViewModel
    {
        public Product? Product { get; set; }
        public IEnumerable<Category?> Categories { get; set; }
    }
}
