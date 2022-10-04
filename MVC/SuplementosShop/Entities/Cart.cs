using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace SuplementosShop.Entities
{
    public class Cart
    {
        public int Id { get; set; }

        public virtual ICollection<CartItem> CartItems { get; set; }


        [ForeignKey("IdentityUser")]
        public string UserId { get; set; }

        public virtual IdentityUser IdentityUser { get; set; }
    }
}
