using Microsoft.AspNetCore.Identity;

namespace SuplementosShop.Models
{
    public class ApproveUsersViewModel
    {
        public ICollection<IdentityUser> UsersWaitingForApproval { get; set; }
        public string CurrentUserId { get; set; }
    }
}
