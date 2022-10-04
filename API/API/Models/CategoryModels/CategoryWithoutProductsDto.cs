namespace API.Models.CategoryModels
{
    public class CategoryWithoutProductsDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;

        public string ShortDescription { get; set; } = string.Empty;
    }
}
