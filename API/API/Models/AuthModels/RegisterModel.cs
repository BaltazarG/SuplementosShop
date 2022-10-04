using API.enums;
using System.ComponentModel.DataAnnotations;

namespace API.Models.AuthModels
{
    public class RegisterModel
    {
        [Required(ErrorMessage = "Username is required"), StringLength(100)]
        public string UserName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Name is required"), StringLength(100)]
        public string FirstName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Email is required"), EmailAddress]
        public string Email { get; set; } = string.Empty;
        [Required(ErrorMessage = "Password is required"), DataType(DataType.Password)]
        [StringLength(255, ErrorMessage = "Must be at least 5 characters", MinimumLength = 5)]
        public string Password { get; set; } = string.Empty;


        [Required(ErrorMessage = "Confirm Password is required")]
        [StringLength(255, ErrorMessage = "Must be at least 5 characters", MinimumLength = 5)]
        [DataType(DataType.Password)]
        [Compare("Password")]
        public string ConfirmPassword { get; set; } = string.Empty;

        [Required(ErrorMessage = "Role is required")]
        public RoleRegister RoleSelected { get; set; }
    }
}
