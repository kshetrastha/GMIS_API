using Microsoft.AspNetCore.Identity;
using gmis.Shared.Enumerations;
using System.ComponentModel.DataAnnotations;

namespace gmis.Application.Models.Users
{
    public class ApplicationUser : IdentityUser
    {
        public required string FirstName { get; set; }
        public string? MiddleName { get; set; }
        public required string LastName { get; set; }
        public required string Organization { get; set; }
        public bool IsActive { get; set; }
        public string? ImageUrl { get; set; }
        public string? ImageType { get; set; }
        #region Need to remove and add to different schema
        public string? RefreshToken { get; set; }
        public DateTime RefreshTokenExpiryTime { get; set; }
        #endregion
        public Status Status { get; set; }
    }
}
