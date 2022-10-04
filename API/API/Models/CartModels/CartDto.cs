namespace API.Models.CartModels
{
    public class CartDto
    {
        public ICollection<CartItemDto> Items { get; set; }
        public int TotalQuantity { get; set; }
        public int TotalAmount { get; set; }
    }
}
