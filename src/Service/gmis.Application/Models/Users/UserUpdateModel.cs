namespace gmis.Application.Models.Users
{
    public class UserUpdateModel
    {
        public Guid Id { get; set; }
        public string AspNetUserId { get; set; }
        public string? FirstName { get; set; }
        public string? MiddleName { get; set; }
        public string? LastName { get; set; }
        public string Email { get; set; } = null!;
    }
}
