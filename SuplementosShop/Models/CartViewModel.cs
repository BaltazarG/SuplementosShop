﻿using SuplementosShop.Entities;

namespace SuplementosShop.Models
{
    public class CartViewModel
    {
        public IEnumerable<CartItem> CartItems { get; set; }
        public string UserId { get; set; }
        public int CurrentCartItemId { get; set; }
        public int CartQuantity { get; set; }
        public int TotalPrice { get; set; }
    }
}