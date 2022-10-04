using System.ComponentModel.DataAnnotations;

namespace API.Models.CartModels
{
    public class CartItemToCreationDto
    {

        [Required]
        public int ProductId { get; set; }

        [Required]
        public int Quantity { get; set; }
    }
}
