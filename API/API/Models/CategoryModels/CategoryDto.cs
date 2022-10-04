using API.Models.ProductModels;

namespace API.Models.CategoryModels
{
    public class CategoryDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;

        public string ShortDescription { get; set; } = string.Empty;

        public virtual ICollection<ProductWithoutCategoryDto> Products { get; set; } = new List<ProductWithoutCategoryDto>() { };
    }
}
