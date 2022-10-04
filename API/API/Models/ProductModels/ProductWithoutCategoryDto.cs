namespace API.Models.ProductModels
{
    public class ProductWithoutCategoryDto
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public int Price { get; set; }

        public string ImageUrl { get; set; } = string.Empty;

        public int CategoryId { get; set; }
    }
}
