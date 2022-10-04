using API.Models.ProductModels;

namespace API.Models.CartModels
{
    public class CartItemDto
    {
        public int Id { get; set; }


        public int ProductId { get; set; }

        public virtual ProductDto Product { get; set; }


        public int CartId { get; set; }

        public int Quantity { get; set; }
    }
}
