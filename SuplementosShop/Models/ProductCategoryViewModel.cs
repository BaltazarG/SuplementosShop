using SuplementosShop.Entities;

namespace SuplementosShop.Models
{
    public class ProductCategoryViewModel
    {
        public IEnumerable<Product?> Products { get; set; }
        public IEnumerable<Category?> Categories { get; set; }
        public string UserId { get; set; }
        public int CurrentProductId { get; set; }
        public int ProductQuantity { get; set; }
    }
}
