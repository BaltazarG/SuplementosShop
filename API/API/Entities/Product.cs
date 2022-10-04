using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Entities
{
    public class Product
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = string.Empty;

        [Required]
        public string Description { get; set; } = string.Empty;

        [Required]
        public int Price { get; set; }

        [Required]
        public string ImageUrl { get; set; } = string.Empty;

        [ForeignKey("Category")]
        public int CategoryId { get; set; }

        public virtual Category Category { get; set; }


    }
}
