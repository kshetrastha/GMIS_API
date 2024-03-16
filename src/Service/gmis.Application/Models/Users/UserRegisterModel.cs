using System.ComponentModel.DataAnnotations;

namespace gmis.Application.Models.Users
{
    public class UserRegisterModel
    {
        [Required]
        public string FirstName { get; set; } = default!;
        public string MiddleName { get; set; } = default!;
        [Required]
        public string LastName { get; set; } = default!;
        [Required]
        public string UserName { get; set; } = default!;
        [Required]
        [EmailAddress]
        public string Email { get; set; } = default!;
        [Required]
        public string Organization { get; set; } = default!;
        [Required]
        public string Password { get; set; } = default!;
        [Required]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; } = default!;
        [Required]
        [MaxLength(16), MinLength(3)]
        public string? PhoneNumber { get; set; }
    }
}
