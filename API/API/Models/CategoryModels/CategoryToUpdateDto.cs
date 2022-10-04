using System.ComponentModel.DataAnnotations;

namespace API.Models.CategoryModels
{
    public class CategoryToUpdateDto
    {
        [Required]
        public string Name { get; set; } = string.Empty;

        [Required, MaxLength(200)]
        public string ShortDescription { get; set; } = string.Empty;
    }
}
