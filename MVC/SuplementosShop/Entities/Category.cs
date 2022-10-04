using System.ComponentModel.DataAnnotations;

namespace SuplementosShop.Entities
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; } = string.Empty;

        [Required, MaxLength(200)]
        public string ShortDescription { get; set; } = string.Empty;


        public virtual ICollection<Product> Products { get; set; } = new List<Product>() { };
    }
}
