using System.ComponentModel.DataAnnotations;

namespace API.Models.ProductModels
{
    public class ProductToCreationDto
    {

        [Required]
        public string Name { get; set; } = string.Empty;

        [Required]
        public string Description { get; set; } = string.Empty;

        [Required]
        public int Price { get; set; }

        [Required]
        public string ImageUrl { get; set; } = string.Empty;

        [Required]
        public int CategoryId { get; set; }

    }
}
