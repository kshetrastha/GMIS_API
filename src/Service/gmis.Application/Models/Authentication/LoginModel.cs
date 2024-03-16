using System.ComponentModel.DataAnnotations;

namespace gmis.Application.Models.Authentication
{
    public class LoginModel
    {
        [Required(ErrorMessage = "User Name is required")]
        public required string UserName { get; set; } // Will be userName or Email

        [Required(ErrorMessage = "Password is required")]
        public required string Password { get; set; }
        public bool RememberMe { get; set; }

    }
}
